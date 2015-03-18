'use strict';
angular.module('pitchApp')
    .controller('LoginController', ['$http', '$rootScope', '$scope', '$location', 'authService', function($http, $rootScope, $scope, $location, authService) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {

            authService.login($scope.loginData).then(function(response){
                $location.path('/home');
            },
            function (err) {
                $scope.message = err.error_description;
            });
        };

    }]);