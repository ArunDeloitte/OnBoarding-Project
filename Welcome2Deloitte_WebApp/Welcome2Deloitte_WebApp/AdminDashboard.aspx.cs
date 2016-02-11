using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welcome2Deloitte
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        string Count;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string dataFetch()
        {
            AdminDesignReport AdrObj = new AdminDesignReport();
            Count= AdrObj.dataFetch(Server.MapPath("~/dbase/Welcome2Deloitte.accdb"));
            return Count;

        }
    }
}