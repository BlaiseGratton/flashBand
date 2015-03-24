'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Users', 'Instruments', 'Songs', '$scope', '$http', function (localStorageService, Users, Instruments, Songs, $scope, $http) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.user = Users.get({ id: vm.userId });

        $scope.postInstrument = function(){
            Instruments.save($scope.newInstrument);
        };

        $http.get("api/Users/" + vm.userId + "/Songs")
            .success(function (data) {
                $scope.songs = data;
            })
            .error(function (err) { console.log(err.message); });

        $http.get("api/Users/" + vm.userId + "/Instruments")
            .success(function (data) {
                $scope.instruments = data;
            })
            .error(function (err) { console.log(err.message); })

        $scope.addInstrumentToUser = function(instrumentId){
            $scope.user.userId = vm.userId;
            $scope.user.itemId = instrumentId;
            $scope.user.collection = "instruments";
            $scope.user.$addInstrument();
        };

    }]);