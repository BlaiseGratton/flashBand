'use strict';
angular.module('pitchApp')
    .factory('songFactory', ['Songs', '$http', 'localStorageService', '$rootScope', function(Songs, $http, localStorageService, $rootScope){
        var userId = localStorageService.get('authorizationData').userId;

        var songFactory = {};

        songFactory.userSongs = [];

        //$http.get("/api/Users/" + userId + "/Songs").then(
        //    function(data){
        //        songFactory.userSongs = data.data;
        //        $rootScope.$broadcast("valuesUpdated");
        //    }, function(err){
        //        console.log(err.message);
        //    }
        //);

        songFactory.updateSongs = function(songs){
            this.userSongs = songs;
            $rootScope.$broadcast("valuesUpdated");
        };

        return songFactory;
    }])