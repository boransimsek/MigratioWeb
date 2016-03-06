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
    [AjaxNamespace("AjaxHome")]
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(_Default));
            InitPage();
        }

        private void InitPage()
        {
            lblTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        [AjaxMethod]
        public string TestAjax()
        {
            return "Hello";
        }

        [AjaxMethod]
        public List<GovDistPlaceVM> GetFullPlacesList()
        {
            var list = PlacesDataAccess.GetFullPlacesList();
            return list;
        }

        [AjaxMethod]
        public List<Governorate> GetGovernorates()
        {
            var result = new List<Governorate>();
            Governorate empty = new Governorate();
            empty.ID = 0;
            empty.Name = "Select Governorate";
            result.Add(empty);
            result.AddRange(GovernorateDataAccess.GetGovernorates());
            
            return result;
        }

        [AjaxMethod]
        public List<District> GetDistrictsByGovernorate(string idList)
        {
            var result = new List<District>();
            result.Add(new District()
            {
                ID = 0,
                Name = "Select District"
            });
            string[] idParts = idList.Split(',');
            if (idParts.Length == 1 && idParts[0] == "0")
            {
                
            }
            else
            {
                List<int> paramID = new List<int>();
                for (int i = 0; i < idParts.Length; i++)
                {
                    paramID.Add(Convert.ToInt32(idParts[i]));
                }
                result.AddRange(DistrictDataAccess.GetDistrictsByGovernorate(paramID));
            }

            return result;
        }
    }
}