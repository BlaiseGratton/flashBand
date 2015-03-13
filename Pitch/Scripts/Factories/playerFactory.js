; (function () {
    angular.module('pitchApp')
        .factory('players', ['$resource', function($resource){
            return $resource('/api/Players/:id');
        }])
}());