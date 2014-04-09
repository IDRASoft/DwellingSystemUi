app.controller('addressController', function ($scope) {

    $scope.LocZipCodeLst = [];

    $scope.changeLocation = function() {
        this.fill($scope.selectedLocation);
        $scope.ZipCode = $scope.selectedLocation.ZipCode;
    };

    $scope.clear = function () {
        $scope.LocationId = "";
        $scope.StateName = "";
        $scope.MunicipalityName = "";
        $scope.LocationName = "";
    };
    
    $scope.fill = function (data) {
        $scope.LocationId = data.LocationId;
        $scope.StateName = data.StateName;
        $scope.MunicipalityName = data.MunicipalityName;
        $scope.LocationName = data.LocationName;
    };
    
    $scope.updateFields = function (pInfo) {
        $scope.ZipCode = pInfo.ZipCode;
        $scope.LocationId = pInfo.LocationId;
        $scope.StateName = pInfo.StateName;
        $scope.CountryName = pInfo.CountryName;
        $scope.MunicipalityName = pInfo.MunicipalityName;
        $scope.LocationName = pInfo.LocationName;
        $scope.Phone = pInfo.Phone;
        $scope.StreetAddress = pInfo.MainAddress;
        $scope.ExtNumber = pInfo.ExternalNumber;
        $scope.IntNumber = pInfo.InternalNumber;
        $scope.$apply();
    };

});