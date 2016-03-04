using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using MigratioWeb.DAL;
using MigratioWeb.DAL.Models.ViewModels;

namespace MigratioWeb
{
    [AjaxNamespace("AjaxTest")]
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Home));
        }

        [AjaxMethod]
        public List<GovDistPlaceVM> GetFullPlacesList()
        {
            var list = PlacesDataAccess.GetFullPlacesList();
            return list;
        }
    }
}