var map;
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
    //var res = AjaxDeneme.GetMessage();
    //$("#txtMessage").val(res.value);
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
        //addPlace(place.Longitude, place.Latitude, place.Name);
        var resJson = testAddPlace(place.Longitude, place.Latitude, place.Name);
        geoJson.features.push(resJson);
    });
    //var geoJson = {
    //    type: 'FeatureCollection',
    //    features: [{
    //        type: 'Feature',
    //        geometry: {
    //            type: 'Point',
    //            coordinates: [-19.512555, 63.530581666667]
    //        },
    //        properties: {
    //            title: 'Skógafoss from Below',
    //            'marker-size': 'small',
    //            'marker-color': '#ffcc11',
    //            'marker-symbol': 'camera',
    //            url: 'http://phototastic.world/photo/skogafoss-from-below/'
    //        }
    //    }, {
    //        type: 'Feature',
    //        geometry: {
    //            type: 'Point',
    //            coordinates: [-23.31073, 64.92612]
    //        },
    //        properties: {
    //            title: 'Kirkjufellsfoss on a Cloudy Day',
    //            'marker-size': 'small',
    //            'marker-color': '#ffcc11',
    //            'marker-symbol': 'camera',
    //            url: 'http://phototastic.world/photo/kirkjufellsfoss-on-a-cloudy-day/'
    //        }
    //    }
    //      /* more Features in the same format ... */
    //    ]
    //};
    myLayer.setGeoJSON(geoJson);
    clusterGroup.addLayer(myLayer);
    map.addLayer(clusterGroup);
    map.fitBounds(myLayer.getBounds());


}

function addPlace(lat, lng, name) {
    L.mapbox.featureLayer({
        // this feature is in the GeoJSON format: see geojson.org
        // for the full specification
        type: 'Feature',
        geometry: {
            type: 'Point',
            // coordinates here are in longitude, latitude order because
            // x, y is the standard for GeoJSON and many formats
            coordinates: [
              lat,
              lng
            ]
        },
        properties: {
            title: name,
            description: '',
            // one can customize markers by adding simplestyle properties
            // https://www.mapbox.com/guides/an-open-platform/#simplestyle
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
    //var res = "type: 'Feature', " +
    //    "geometry: {" +
    //    "type: 'Point', " +
    //    " coordinates: [" +
    //    lat + "," +
    //    lng +
    //    "]" +
    //    "}," +
    //    "properties: {" +
    //    "       title: " + name + ", " +
    //    "       description: '', " +
    //    "'marker-size': 'large', " +
    //    "'marker-color': '#BE9A6B' " +
    //    "}";
    return res;
}
