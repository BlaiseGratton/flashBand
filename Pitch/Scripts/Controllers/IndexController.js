'use strict';
angular.module('pitchApp')
    .controller('IndexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
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
    }]);