angular.module('pitchApp')
    .factory('Songs', ['$resource', function ($resource) {
        return $resource('/api/Songs/:id');
    }]);