using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace NodeOrders
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        private IDataAccess mongo;
        const string server = @"mongodb://user2:password@ds054619.mlab.com:54619/isit420";
        const string database = "isit420";


        protected void Page_Load(object sender, EventArgs e)
        {
            mongo = new MongoAccess(server, database);
            var  orderDetailList = mongo.GetAllOrders();

            rptrOrders.DataSource = orderDetailList;
            rptrOrders.DataBind();
            lblStatus.Text = "There have been " + orderDetailList.Count.ToString() + " orders.";



        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            mongo.ClearHistory();
            Response.Redirect(Request.RawUrl);
        }
    }
}