using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using MigratioWeb.DAL;
using MigratioWeb.DAL.Models;
using MigratioWeb.DAL.Models.ViewModels;

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
            if (!IsPostBack)
            {
                FillGovernorates();
            }
        }

        public void FillGovernorates()
        {
            var list = TestDataAccess.GetGovernorates();
            ddlGovernorate.DataTextField = "Name";
            ddlGovernorate.DataValueField = "ID";
            ddlGovernorate.DataSource = list;
            ddlGovernorate.DataBind();

        }

        public void FillDistricts(int governorateId)
        {
            var list = TestDataAccess.GetDistrictsByGovernorate(governorateId);
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "ID";
            ddlDistrict.DataSource = list;
            ddlDistrict.DataBind();
        }

        public void FillPlaces()
        {

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

        [AjaxMethod]
        public List<GovDistPlaceVM> GetFullPlacesList()
        {
            var list = TestDataAccess.GetFullPlacesList();
            return list;
        }

        protected void ddlDistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            FillDistricts(Convert.ToInt32(ddlGovernorate.SelectedValue));
        }
    }
}