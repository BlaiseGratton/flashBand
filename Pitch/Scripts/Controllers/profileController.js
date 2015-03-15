;(function(){
    'use strict';
    angular.module('pitchApp')
        .controller('ProfileController', ['players', '$scope', function(players, $scope) {
            var vm = this;
            vm.loadPlayer = function(id){
                $scope.user = players.get({id: id});
                console.log($scope.user);
            }
            players.query(function(data) {
                $scope.user = data;
                $scope.testModel = $scope.user[0].userName;
            });
        }])
}());