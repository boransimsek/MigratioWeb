using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using MigratioWeb.DAL;
using MigratioWeb.DAL.Models;

namespace MigratioWeb
{
    [AjaxNamespace("AjaxDeneme")]
    public partial class AjaxDeneme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxDeneme));
            Label1.Text = DateTime.Now.ToLongTimeString();
            //Label1.Text = TestDataAccess.GetGovernorateCount().ToString();
        }

        [AjaxMethod]
        public string GetMessage()
        {
            return "Hello";
        }

        [AjaxMethod]
        public List<Place> GetPlaces()
        {
            return TestDataAccess.GetPlaces();
        }
    }
}