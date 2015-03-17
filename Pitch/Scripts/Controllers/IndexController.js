'use strict';
angular.module('pitchApp')
    .controller('IndexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
        $scope.logOut = function(){
            authService.logOut();
            $location.path('/');
        };
        $scope.authentication = authService.authentication;
    }])