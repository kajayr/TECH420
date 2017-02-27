using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace NodeOrders
{
    public partial class BuyCD : Page
    {
        private readonly SqlAccess mySqlAccess = new SqlAccess();
        private MongoAccess mongo;
        protected void Page_Load(object sender, EventArgs e)
        {

            var CdDataSet = mySqlAccess.GetCustData();

            CdDataList.DataSource = CdDataSet;
            // CdDataList.DataMember = "CDs";
            CdDataList.DataBind();
        }

        protected void CdDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            var x = 16;


            if (e.CommandName != "Buy") return;

  
            try
            {
                var creditCardNumber = long.Parse(TextBoxCC.Text.Trim().Replace(" ", ""));
                var phonenum = long.Parse(TextBoxPhone.Text.Trim().Replace(" ", ""));
                var name = TextBoxName.Text;
                LabelResults.Text = mySqlAccess.Buy(e.CommandArgument.ToString(), creditCardNumber, phonenum, name );
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void CdDataList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}