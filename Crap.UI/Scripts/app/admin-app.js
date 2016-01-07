(function () {
    'use strict';

    angular.module('crapShopAdmin', ['common.core', 'common.ui'])
        .config(config);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "/Views/Admin/Index.html",
                controller: "indexCtrl"
            })
            .when("/category/edit", {
                templateUrl: "/Views/Admin/CategoryEdit.html",
                controller: "categoryEditCtrl"
            })
            .when("/category/list", {
                templateUrl: "/Views/Admin/CategoryList.html",
                controller: "categoryListCtrl"
            })
            .when("/product/edit", {
                templateUrl: "/Views/Admin/ProductEdit.html",
                controller: "productEditCtrl"
            })
            .when("/product/list", {
                templateUrl: "/Views/Admin/ProductList.html",
                controller: "productListCtrl"
            })
            .otherwise({ redirectTo: "/" });
    }

})();