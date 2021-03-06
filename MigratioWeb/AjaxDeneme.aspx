﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDeneme.aspx.cs" Inherits="MigratioWeb.AjaxDeneme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://api.mapbox.com/mapbox.js/v2.3.0/mapbox.css" rel="stylesheet" />
    <link href='https://api.mapbox.com/mapbox.js/plugins/leaflet-markercluster/v0.4.0/MarkerCluster.css' rel='stylesheet' />
    <link href='https://api.mapbox.com/mapbox.js/plugins/leaflet-markercluster/v0.4.0/MarkerCluster.Default.css' rel='stylesheet' />

    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="https://api.mapbox.com/mapbox.js/v2.3.0/mapbox.js"></script>
    <script src="Scripts/migration.js"></script>
    <script src='https://api.mapbox.com/mapbox.js/plugins/leaflet-markercluster/v0.4.0/leaflet.markercluster.js'></script>

</head>
<body>

    <form id="form1" runat="server">
        <div>
            <input type="text" id="txtMessage">
            <button id="btnTest" onclick="return getMessage();">Test</button>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />


        <div class="row">
            <div class="col-lg-1">
            </div>
            <div class="col-lg-2">
                <label class="label-default" text="asdasdas">Governorate: </label>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:DropDownList ID="ddlGovernorate" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlGovernorate" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-1">
            </div>
            <div class="col-lg-2">
                <label class="label-default">District: </label>
                <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_OnSelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-lg-1">
            </div>
            <div class="col-lg-2">
                <label class="label-default">Place: </label>
                <asp:DropDownList ID="ddlPlace" runat="server"></asp:DropDownList>
            </div>
            <div class="col-lg-2">
                <input type="button" id="btnFilter" value="Filter" />
            </div>
            <div class="col-lg-1">
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div id="map" style="height: 700px; margin-top: 5%;">
                </div>
            </div>
            <div class="col-lg-1"></div>
        </div>

    </form>

    <script type="text/javascript">

        $(document).ready(function () {
            loadMap();
        });

    </script>
</body>
</html>
