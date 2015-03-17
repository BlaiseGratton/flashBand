'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['players', '$scope', function(players, $scope) {
            var vm = this;

            vm.loadPlayer = function(id){
                console.log(id);
                $scope.user = players.get({ id: id });
                console.log($scope.user);
            };

            vm.postPlayer = function(){
                vm.playerInfo = new players();
                players.save(vm.playerInfo, function () { });
            };

        }])