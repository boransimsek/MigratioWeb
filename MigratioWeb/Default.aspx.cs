﻿using System;
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
    [AjaxNamespace("AjaxHome")]
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(_Default));
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
    }
}