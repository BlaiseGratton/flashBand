'use strict';
angular.module('pitchApp')
    .controller('IndexController', ['$rootScope', '$scope', '$location', 'authService', function($rootScope, $scope, $location, authService) {
        var vm = this;

        $scope.logOut = function () {
            authService.logOut();
            $location.path('/');
        };

        $scope.authentication = authService.authentication;

        $(document).on('click', '.navbar-collapse.in', function (e) {
            if ($(e.target).is('a')) {
                $(this).collapse('hide');
            }
        });

        $scope.evaluateExpanded = function () {
            setTimeout(function () {
                if ($scope.navbarExpanded === true) {
                    $scope.navbarExpanded = false;
                }
            }, 10);
        };
    }]);