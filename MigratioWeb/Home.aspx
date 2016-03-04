<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MigratioWeb.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Migration Map</title>
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
<form id="form1" runat="server"></form>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" runat="server" href="#">Migration Map</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <%--                    <li><a runat="server" href="~/">Home</a></li>
                    <li><a runat="server" href="~/About">About</a></li>
                    <li><a runat="server" href="#">Contact</a></li>--%>
                </ul>
                <%--                <asp:LoginView runat="server" ViewStateMode="Disabled">
                    <AnonymousTemplate>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a runat="server" href="~/Account/Register">Register</a></li>
                            <li><a runat="server" href="~/Account/Login">Log in</a></li>
                        </ul>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a runat="server" href="~/Account/Manage" title="Manage your account">Hello, <%: Context.User.Identity.GetUserName()  %> !</a></li>
                            <li>
                                <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
                            </li>
                        </ul>
                    </LoggedInTemplate>
                </asp:LoginView>--%>
            </div>
        </div>
    </div>

    <div class="container body-content" style="margin-top: 10%;">
        <div class="row">
            <%--<div class="col-lg-1">
                
            </div>--%>
            
            <div class="col-lg-12">
                <div id="map" style="height: 700px;">
                    
                </div>
            </div>

          <%--  <div class="col-lg-1">
                
            </div>--%>
        </div>
<%--        <div class="modal-footer">
            <p>&copy; <%: DateTime.Now.Year %> - My ASP.NET Application</p>
        </div>--%>
    </div>
    
    <script type="text/javascript">
        $(document).ready(function () {
            loadMap();
        });
    </script>
</body>
</html>
