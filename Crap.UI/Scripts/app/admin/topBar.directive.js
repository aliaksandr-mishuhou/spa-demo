(function (app) {
    'use strict';

    app.directive('topBar', topBar);

    function topBar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/Views/Layout/AdminTopBar.html'
        };
    }

})(angular.module('common.ui'));