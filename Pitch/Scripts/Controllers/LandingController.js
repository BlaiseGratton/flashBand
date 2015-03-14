;(function(){
    'use strict';
    
    angular.module('pitchApp')
        .controller('LandingController', ['players', '$scope', function(players, $scope) {

            var vm = this;

            players.query(function(data) {
                $scope.user = data;
                $scope.testModel = $scope.user[0].userName;
            });
        }])
}());