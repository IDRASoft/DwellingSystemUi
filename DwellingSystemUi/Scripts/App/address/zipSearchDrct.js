app.directive('zipSearch', function ($http, $timeout) {
    return function (scope, elem) {

        var currentTimeout = null;

        var ajaxConf = {
            method: 'POST',
            url: '/Catalog/LocationsByZipCode',
        };

        elem.on('keyup change blur', function () {
            if (scope.ZipCode == undefined || scope.ZipCode.length < 4 || scope.ZipCode.length > 5)
                return;

            ajaxConf.data = { 'zipCode': scope.ZipCode };

            if (currentTimeout) {
                $timeout.cancel(currentTimeout);
            }

            currentTimeout = $timeout(function() {
                $http(ajaxConf)
                    .success(function (data) {
                        if (data.Locations == undefined || data.Locations.length === 0) {
                            scope.clear();    
                            return;
                        }

                        scope.LocZipCodeLst = data.Locations;

                        /*
                        for (var i = 0; i < data.Locations.length; i++) {
                            var location = data.Locations[i];
                            scope.LocZipCodeLst[location] = location;
                        }*/

                        scope.fill(data.Locations[0]);
                        scope.selectedLocation = data.Locations[0];

                    });
            }, 200);
        });
    };
});