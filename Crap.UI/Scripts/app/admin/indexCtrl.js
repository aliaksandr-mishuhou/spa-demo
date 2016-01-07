(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);
    indexCtrl.$inject = ['$scope', 'apiService', 'notificationService'];


    function indexCtrl($scope, apiService, notificationService) {
        $scope.isLoading = true;

        apiService.get('/api/stats/summary', null, onSummaryLoadCompleted, onSummaryLoadFailed);

        function onSummaryLoadCompleted(result) {
            $scope.isLoading = false;
            console.log(result.data);
            $scope.totalCategories = result.data.TotalCategories;
            $scope.totalProducts = result.data.TotalProducts;
            $scope.totalOrders = result.data.TotalOrders;
        }

        function onSummaryLoadFailed(response) {
            $scope.isLoading = false;
            notificationService.displayError(response.data);
        }

    }

})(angular.module('crapShopAdmin'));