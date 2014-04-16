app.controller('serviceController', function ($scope) {
    $scope.WaitFor = false;
    $scope.MsgError = "";
    $scope.Model = {};

    $scope.submit = function (formId, urlToPost) {
        if ($(formId).valid() == false) {
            $scope.Invalid = true;
            return false;
        }
        $scope.WaitFor = true;
        $.post(urlToPost, $(formId).serialize())
            .success($scope.handleSuccess)
            .error($scope.handleError);

        return true;
    };
    $scope.handleSuccess = function (resp) {
        $scope.WaitFor = false;
        try {
            if (resp.HasError == true) {
                $scope.MsgError = resp.Message;
                $scope.MsgSuccess = "";
            } else {
                $scope.MsgError = "";
                $scope.MsgSuccess = resp.Message;

            }
            $scope.$apply();

        } catch (e) {
            $scope.MsgSuccess = "";
            $scope.MsgError = "Error inesperado de datos. Por favor intente más tarde.";
        }
    };

    $scope.handleError = function () {
        $scope.WaitFor = false;
        $scope.MsgSuccess = "";
        $scope.MsgError = "Error de red. Por favor intente más tarde.";
        $scope.$apply();
    };
});