;(function(){
    'use strict';
    
    angular.module('pitchApp')
        .controller('LandingController', ['players', '$scope', function(players, $scope) {

            var vm = this;

            players.query(function(data) {
                $scope.testModel = angular.fromJson(data);
                console.log($scope.testModel[0].userName);

            });


        }])
}());