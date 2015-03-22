angular.module('pitchApp')
    .factory('Flashes', ['$resource', function ($resource) {
        return $resource('/api/Flashes/:instrumentIDs/:songIDs',
                        {
                            instrumentIDs: '@instrumentIDs',
                            songIDs: '@songIDs'
                        },
                        {   
                            getFlashes: {
                                method: 'GET'
                            }
                        });
    }]);