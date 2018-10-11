window.maps = (function () {
    function buildKey(element) {
        var key = "";
        var parentElem = element;
        while (parentElem != null) {
            nodeKey = parentElem.localName;
            if (parentElem.id !== "") {
                nodeKey += "#" + parentElem.id;
            }
            else if (parentElem.className !== "") {
                nodeKey += "." + parentElem.className;
            }

            key = nodeKey + " " + key;

            parentElem = parentElem.parentElement;
        }

        return key;
    }

    function addPushpin(map, detail) {
        var color = detail.color;
        var lat = detail.latitude;
        var lng = detail.longitude;

        var loc = new Microsoft.Maps.Location(lat, lng);
        var pushpin = new Microsoft.Maps.Pushpin(loc, { color: color });
        map.entities.push(pushpin);

        return loc;
    }

    function registerPushpinsInternal(mapElement, details) {
        var key = buildKey(mapElement);
        var map = window.maps[key];

        if (map === undefined || map === null) {
            throw new Error("No map exists for element " + key);
        }

        map.entities.clear();

        var locs = []
        for (var i = 0, len = details.length; i < len; i++) {
            locs[i] = addPushpin(map, details[i]);
        }

        var rect = Microsoft.Maps.LocationRect.fromLocations(locs);
        map.setView({ bounds: rect, padding: 80 });
    }

    return {
        initializeMapElement: function (element, pushpins) {
            var key = buildKey(element);

            if (window.maps[key] === undefined) {
                var map = new Microsoft.Maps.Map(element, {});
                window.maps[key] = map;
            }

            if (pushpins) registerPushpinsInternal(element, pushpins);
        },
        registerPushpins: function (mapElement, details) {
            registerPushpinsInternal(mapElement, details);
        }
    }
})();