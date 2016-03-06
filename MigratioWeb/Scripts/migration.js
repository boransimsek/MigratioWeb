var map;
var markers = [];

function init() {
    fillGovernorates();
    //fillDistricts();
    $("#ddlGovernorate").on("change", function() {
        //getSelected();
        getDistrictsByGovernorate();
    });
    loadMap();
}

function loadMap() {
    //L.mapbox.accessToken = 'pk.eyJ1Ijoic2ltc2VrYm8iLCJhIjoiY2lpMDN2ODUyMDRuYXQzbTF4Z3FqNnR3diJ9.lNEjQ2Yb3mrtvOFFwz5B_Q';
    //// Create a map in the div #map
    //map = L.mapbox.map('map', 'mapbox.streets');

    L.mapbox.accessToken = 'pk.eyJ1Ijoic2ltc2VrYm8iLCJhIjoiY2lpMDN2ODUyMDRuYXQzbTF4Z3FqNnR3diJ9.lNEjQ2Yb3mrtvOFFwz5B_Q';
    map = L.mapbox.map('map', 'mapbox.streets')
        .setView([39, 35.50], 5);
    map.on("click", function(ev) {
        //addMarkerOnClick(ev);
    });
    loadFullPlacesList();
}

//function getMessage() {
//    getFullPlacesList();
//    return false;
//}


function addMarkerOnClick(ev) {
    var marker = L.marker([ev.latlng.lat, ev.latlng.lng]).addTo(map);
    markers.push(marker);
    $("#txtMessage").val(markers.length);
}

function getPlaces() {
    var clusterGroup = new L.MarkerClusterGroup();
    
    var res = AjaxHome.GetPlaces();
    var list = res.value;
    var myLayer = L.mapbox.featureLayer();
    var geoJson = {
        type: 'FeatureCollection',
        features: []
    };

    list.forEach(function(place) {
        var resJson = testAddPlace(place.Longitude, place.Latitude, place.Name);
        geoJson.features.push(resJson);
    });

    myLayer.setGeoJSON(geoJson);
    clusterGroup.addLayer(myLayer);
    map.addLayer(clusterGroup);
    map.fitBounds(myLayer.getBounds());


}

function loadFullPlacesList() {
    var clusterGroup = new L.MarkerClusterGroup();
    
    var res = AjaxHome.GetFullPlacesList();
    var list = res.value;
    var myLayer = L.mapbox.featureLayer();
    var geoJson = {
        type: 'FeatureCollection',
        features: []
    };

    list.forEach(function (place) {
        var resJson = addPlaceWithGovernorateDistrict(place);
        geoJson.features.push(resJson);
    });

    myLayer.setGeoJSON(geoJson);
    clusterGroup.addLayer(myLayer);
    map.addLayer(clusterGroup);
    map.fitBounds(myLayer.getBounds());

}

//function addPlace(lat, lng, name) {
//    L.mapbox.featureLayer({
//        type: 'Feature',
//        geometry: {
//            type: 'Point',
//            coordinates: [
//              lat,
//              lng
//            ]
//        },
//        properties: {
//            title: name,
//            description: '',
//            'marker-size': 'large',
//            'marker-color': '#BE9A6B'
//        }
//    }).addTo(map);
//}

function testAddPlace(lat, lng, name) {
    var res = {};
    res.type = 'Feature';
    res.geometry = {};
    res.geometry.type = 'Point';
    res.geometry.coordinates = [];
    res.geometry.coordinates.push(lat);
    res.geometry.coordinates.push(lng);
    res.properties = {};
    res.properties.title = name;
    res.properties.description = '';
    res.properties['marker-size'] = 'large';
    res.properties['marker-color'] = '#BE9A6B';
    return res;
}

function addPlaceWithGovernorateDistrict(item) {
    var res = {};
    res.type = 'Feature';
    res.geometry = {};
    res.geometry.type = 'Point';
    res.geometry.coordinates = [];
    res.geometry.coordinates.push(item.Place.Longitude);
    res.geometry.coordinates.push(item.Place.Latitude);
    res.properties = {};
    res.properties.title = item.Governorate.Name;
    res.properties.description = item.District.Name + " - " + item.Place.Name;
    res.properties['marker-size'] = 'large';
    res.properties['marker-color'] = '#BE9A6B';
    return res;
}

function fillGovernorates() {
    var res = AjaxHome.GetGovernorates();
    var list = res.value;
    list.forEach(function(item) {
        //var itemHtml = "<li><a href='#' id='" + item.ID + "'>" + item.Name + "</a></li>";
        var itemHtml = "<option value='" + item.ID + "'>" + item.Name + "</option>";
        $("#ddlGovernorate").append(itemHtml);
    });

    //<a class="dropdown-item" href="#">Separated link</a>
    //$("#ddlGovernorate");
}

function getSelected() {
    alert($("#ddlGovernorate").val());
    return false;
}

function getDistrictsByGovernorate() {
    var ids = $("#ddlGovernorate").val();
    var res = AjaxHome.GetDistrictsByGovernorate(ids);
    var list = res.value;
    $("#ddlDistrict").html('');
    list.forEach(function(item) {
        //addDistrict(item);
        var itemHtml = "<option value='" + item.ID + "'>" + item.Name + "</option>";
        $("#ddlDistrict").append(itemHtml);
    });
    $("#ddlDistrict").selectpicker("refresh");
    //$("#ddlDistrict").val("0");
    //$("#divDistrict").hide().fadeIn('fast');
}

function addDistrict() {

}

function fillDistricts() {
    var res = AjaxHome.GetDistrictsByGovernorate("2");
    var list = res.value;
    
    list.forEach(function (item) {
        //addDistrict(item);
        var itemHtml = "<option value='" + item.ID + "'>" + item.Name + "</option>";
        $("#ddlDistrict").append(itemHtml);
    });
}
