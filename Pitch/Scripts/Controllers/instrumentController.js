'use strict';
angular.module('pitchApp')
    .controller('InstrumentController', ['$http', '$scope', 'Users', 'Instruments', 'localStorageService', function($http, $scope, Users, Instruments, localStorageService){
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.user = Users.get({ id: vm.userId });

        $http.get("api/Users/" + vm.userId + "/Instruments")
            .success(function (data) {
                $scope.instruments = data;
            })
            .error(function (err) { console.log(err.message); })
    }]);