using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace MigratioWeb
{
    [AjaxNamespace("AjaxTest")]
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Test));
            Label1.Text = DateTime.Now.ToLongTimeString();
        }

        [AjaxMethod]
        public string GetMessage()
        {
            return "Hello";
        }
    }
}