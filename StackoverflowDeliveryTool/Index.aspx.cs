using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackoverflowDeliveryTool
{
    public partial class Index : System.Web.UI.Page
    {
        public string userName = string.Empty;
        public string alias = string.Empty;
        public string initialTodate = string.Empty;
        public string initialFromdate = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            userName = System.Web.HttpContext.Current.User.Identity.Name;
            alias = userName.Substring(userName.IndexOf("\\") + 1);
            initialFromdate = DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy");
            initialTodate = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}