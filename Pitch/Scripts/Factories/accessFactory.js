angular.module('pitchApp')
    .factory('accessFactory', ['$rootScope', '$http', function($rootScope, $http){
        var _getUserId = function($http, $rootScope, userName){
            $http.get('api/Account/User/' + userName)
					.success(function(data){
						$rootScope.userId = data;
					})
					.error(function(err){
						console.log(err.message);
					});
        };

        var _checkLogin = function($rootScope){
            if($rootScope.userId === null){
                return false;
            }
        };

        accessFactory.getUserId = _getUserId;
        accessFactory.checkLogin = _checkLogin;
        return accessFactory;
    }]);