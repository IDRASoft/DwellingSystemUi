app.controller('UpsertDwellingCtrl', function($scope, $timeout) {

    $scope.streetList = [];

    $scope.documentTypeList = [];
    
    $scope.streetModel = "";

    $scope.documentTypeModel = "";

    function initStreet() {
        if ($scope.StreetId > 0) {
            for (var a = 0; a < $scope.streetList.length; a++) {
                if ($scope.StreetId == $scope.streetList[a].KeyId) {
                    $scope.streetModel = $scope.streetList[a];
                }
            }
        } else {
            $scope.streetModel = $scope.streetList[0];
            $scope.StreetId = $scope.streetModel.KeyId;
        }
    };
    
    function initDocumentType() {
        /*if ($scope.DocumentTypeId > 0) {
            for (var a = 0; a < $scope.documentTypeList.length; a++) {
                if ($scope.DocumentTypeId == $scope.documentTypeList[a].KeyId) {
                    $scope.documentTypeModel = $scope.documentTypeList[a];
                }
            }
        } else {*/
            $scope.documentTypeModel = $scope.documentTypeList[0];
            $scope.DocumentTypeId = $scope.documentTypeModel.KeyId;
      //  }
    };

    $scope.onChangeStreet = function() {
        $scope.StreetId = $scope.streetModel.KeyId;
    };
    
    $scope.onChangeDocumentType= function () {
        $scope.DocumentTypeId = $scope.documentTypeModel.KeyId;
    };


    $timeout(function() {
        if ($scope.streetList.length > 0)
            initStreet();

        if ($scope.documentTypeList.length > 0)
            initDocumentType();
    }, 1);
});