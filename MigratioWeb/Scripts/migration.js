﻿var map;
var markers = [];

function loadMap() {
    //L.mapbox.accessToken = 'pk.eyJ1Ijoic2ltc2VrYm8iLCJhIjoiY2lpMDN2ODUyMDRuYXQzbTF4Z3FqNnR3diJ9.lNEjQ2Yb3mrtvOFFwz5B_Q';
    //// Create a map in the div #map
    //map = L.mapbox.map('map', 'mapbox.streets');

    L.mapbox.accessToken = 'pk.eyJ1Ijoic2ltc2VrYm8iLCJhIjoiY2lpMDN2ODUyMDRuYXQzbTF4Z3FqNnR3diJ9.lNEjQ2Yb3mrtvOFFwz5B_Q';
    map = L.mapbox.map('map', 'mapbox.streets')
        .setView([39, 33.50], 7);
    map.on("click", function(ev) {
        addMarkerOnClick(ev);
    });
}

function getMessage() {
    getPlaces();
    return false;
}


function addMarkerOnClick(ev) {
    var marker = L.marker([ev.latlng.lat, ev.latlng.lng]).addTo(map);
    markers.push(marker);
    $("#txtMessage").val(markers.length);
}

function getPlaces() {
    var clusterGroup = new L.MarkerClusterGroup();
    
    var res = AjaxDeneme.GetPlaces();
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

function addPlace(lat, lng, name) {
    L.mapbox.featureLayer({
        type: 'Feature',
        geometry: {
            type: 'Point',
            coordinates: [
              lat,
              lng
            ]
        },
        properties: {
            title: name,
            description: '',
            'marker-size': 'large',
            'marker-color': '#BE9A6B'
        }
    }).addTo(map);
}

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
