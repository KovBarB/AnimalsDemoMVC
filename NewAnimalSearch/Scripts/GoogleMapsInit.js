    function initializeMap() {

        google.maps.visualRefresh = true; 
        
        var latitude = 47.494525;
        var longitude = 19.030332;

        var latlng = new google.maps.LatLng(latitude, longitude);
        var options = {
        zoom: 15,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("map_canvas"), options);

        var marker = new google.maps.Marker({
        position: new google.maps.LatLng(latitude, longitude),
            map: map
        });

        // Make the marker-pin green 
        marker.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png') 
    }

    $(function () {
        initializeMap();
    });