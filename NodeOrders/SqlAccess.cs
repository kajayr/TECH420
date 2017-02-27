using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Models;

namespace NodeOrders
{
    public class MyData
    {
        public long Cc { get; set; }
        public long phoneNum { get; set; }
        public bool CardOK { get; set; }
        public decimal Price { get; set; }
    }

    public class SqlAccess
    {
        const string server = @"mongodb://user2:password@ds054619.mlab.com:54619/isit420";
        const string db = " foo";

        public DataSet GetCustData()
        {
            //instantiate the data adapter
            var nodeOrdersAdapter = new SqlDataAdapter();
            //instantiate the select command object
            nodeOrdersAdapter.SelectCommand = new SqlCommand();
            //instantiate the connection object
            nodeOrdersAdapter.SelectCommand.Connection = new SqlConnection();
            try
            {
                // set the connection string in the connection object
                nodeOrdersAdapter.SelectCommand.Connection.ConnectionString =
                    @"Server = localhost;Database=NodeOrders;Integrated Security=SSPI";
                //set the command text
                nodeOrdersAdapter.SelectCommand.CommandText =
                    "Select * from [CD-table] order by CDname";
                //instantiate the data set to be filled
                var CdDataSet = new DataSet("CdDataSet");
                //contact the database
                //includes the connect and the sending of the SQL
                //and fill 1 table in the dataset
                nodeOrdersAdapter.Fill(CdDataSet, "CDs");


                return CdDataSet;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Database operation failed.  Please contact your System Administrator "  + sqlEx.Message);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public string Buy(string pCDinfo, long pCc, long pPhone, string name)
        {
            // minimize the tx time, get as much setup down before starting Tx
            // 2nd thread to simulate a call to Visa/MC to verify and charge amount to CC

            var words = pCDinfo.Split(' ');
            var pCdId = Convert.ToInt32(words[0]);
            var pCdPrice = Convert.ToDecimal(words[1]);

            var t2 = new Thread(ValidateCC); // create second Thread, point it to the code (method) to execute
            var theData = new MyData
            {
                Cc = pCc,
                phoneNum = pPhone,
                CardOK = false,
                Price = pCdPrice
            };
            var othersNotDone = true; // whill use this to decide when we can proceed

            t2.Start(theData); // start the thread

            var connection = new SqlConnection(@"Server = localhost;Database=NodeOrders;Integrated Security=SSPI");
            var updateCommand = new SqlCommand("UPDATE Inventory  " +
                                               " SET ItemQuantity = (ItemQuantity - 1) " +
                                               " WHERE CdID = " + pCdId +
                                               " AND ItemQuantity > 0 ", connection);
            // this construction avoids concurrency issues (I think!)

            SqlTransaction InventoryTransaction; // declare a variable of type SqlTransaction 
            connection.Open(); // after we create the connection, we can start the Tx
            InventoryTransaction = connection.BeginTransaction(); //declare the beginning of the transaction (set)
            updateCommand.Transaction = InventoryTransaction; // assign a Transaction “master” to the SQL cmd

            // 2 parts of Tx are, deal with inventory table, and deal with VISA/MC

            var recChanged = updateCommand.ExecuteNonQuery(); // do the SQL


            while (othersNotDone) // waiting until thread 2 completes communication with VISA/MC
            {
                othersNotDone = false;
                Thread.Sleep(1000); // be a bit patient
                if (t2.IsAlive)
                {
                    othersNotDone = true;
                    Console.WriteLine("tick!");
                }
            }

            var returnMsg = "Thank you for your purchase.";
            //checked that invt returned 1 (we had a disc, and CC went thru ok)
            if (recChanged != 1 || theData.CardOK == false)
            {
                InventoryTransaction.Rollback(); // we had one or more problems, so roll back the changes
                if (theData.CardOK) // we charged the card, but had no inventory
                    returnMsg = "Sorry, we are out of stock for that CD.";
                else
                    returnMsg = "Sorry, your credit card was refused.";
            }
            else // all is well, 
            {
                InventoryTransaction.Commit();

                var logger  = new DataAccess.MongoAccess(server,db);
                logger.LogOrder(new OrderDetail());
            }
            connection.Close();


            return returnMsg;
        }

        private void ValidateCC(object inputObject) 
        {
            var localCopy = (MyData) inputObject; 
            Thread.Sleep(2000); 
            var myRandom = new Random();
            var ranNum = myRandom.Next(1, 4);
            localCopy.CardOK = ranNum <= 2;
        }
    }
}