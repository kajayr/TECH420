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
             mongo = new MongoAccess("mongodb://user2:password@ds054619.mlab.com:54619/isit420");

            var CdDataSet = mySqlAccess.GetCustData();

            CdDataList.DataSource = CdDataSet;
            // CdDataList.DataMember = "CDs";
            CdDataList.DataBind();
        }

        protected void CdDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Buy")
            {
                var tempString = TextBoxCC.Text;
                var newstring = tempString.Trim(); // get rid of leading and trailing spaces
                var noSpaceString = newstring.Replace(" ", ""); // get rid of inner spaces
                var CC = Convert.ToInt64(noSpaceString);

                tempString = TextBoxPhone.Text;
                newstring = tempString.Trim(); // get rid of leading and trailing spaces
                noSpaceString = newstring.Replace(" ", ""); // get rid of inner spaces
                var phonenum = Convert.ToInt64(noSpaceString);
                LabelResults.Text = mySqlAccess.Buy(e.CommandArgument.ToString(), CC, phonenum);
            }
        }
    }
}