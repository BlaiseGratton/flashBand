angular.module('pitchApp')
    .factory('Users', ['$resource', function ($resource) {
        return $resource('/api/Users/:id/:songId');
    }]);