﻿'use strict';
angular.module('pitchApp')
	.factory('authService', ['$http', '$q', 'localStorageService', '$rootScope', function($http, $q, localStorageService, $rootScope){
		// var serviceBase = 'http://localhost:49328/';
		var serviceBase = '';
		var authServiceFactory = {};
		var _authentication = {
			isAuth: false,
			userName: ""
		};
		var _saveRegistration = function (registration) {
			_logOut();
			return $http.post(serviceBase + 'api/account/register', registration).then(function(response){
				return response;
			});
		};
		var _login = function (loginData) {
			var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
			var deferred= $q.defer();
			$http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function(response){
				$http.get('api/Account/User/' + loginData.userName)
					.success(function(data){
						localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, userId: data });
						_authentication.isAuth = true;
						_authentication.userName = loginData.userName;
						deferred.resolve(response);
					})
					.error(function(err){
						console.log(err.message);
					});
				
			}).error(function(err, status){
				_logOut();
				deferred.reject(err);
			});
			return deferred.promise;
		};
		var _logOut = function(){
			localStorageService.remove('authorizationData');
			_authentication.isAuth = false;
			_authentication.userName = "";
			$rootScope.$broadcast('logout');
		};
		var _fillAuthData = function(){
			var authData = localStorageService.get('authorizationData');
			if(authData){
				_authentication.isAuth = true;
				_authentication.userName = authData.userName;
			}
		}
		authServiceFactory.saveRegistration = _saveRegistration;
		authServiceFactory.login = _login;
		authServiceFactory.logOut = _logOut;
		authServiceFactory.fillAuthData = _fillAuthData;
		authServiceFactory.authentication = _authentication;
		return authServiceFactory;
	}]);