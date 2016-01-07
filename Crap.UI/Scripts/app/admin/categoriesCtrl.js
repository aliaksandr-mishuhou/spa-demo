(function (app) {
    'use strict';

    app.controller('categoriesCtrl', categoriesCtrl);
    categoriesCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function categoriesCtrl($scope, apiService, notificationService) {
        $scope.isLoading = true;
        $scope.pageClass = 'page-categories';
        $scope.categories = [];

        apiService.get('/api/categories', null, onCategoriesLoadCompleted, onCategoriesLoadFailed);

        function onCategoriesLoadCompleted(result) {
            $scope.isLoading = false;
            $scope.categories = result.data;
        }

        function onCategoriesLoadFailed(response) {
            $scope.isLoading = false;
            notificationService.displayError(response.data);
        }

    }

})(angular.module('crapShopAdmin'));