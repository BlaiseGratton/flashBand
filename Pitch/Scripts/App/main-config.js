'use strict';
var app = angular.module('pitchApp');
angular.module('pitchApp')
    .config(function($routeProvider){
        $routeProvider
        .when('/prof', {
            templateUrl: '/Static/Views/profile.html',
            controller: 'ProfileController',
            controllerAs: 'profCtrl'
        })
        .when('/signup', {
            templateUrl: '/Static/Views/signup.html',
            controller: 'SignupController'
        })
        .when('/login', {
            templateUrl: '/Static/Views/login.html',
            controller: 'LoginController'
        })
        .when('/home', {
            templateUrl: '/Static/Views/home.html',
            controller: 'HomeController'
        })
        .when('/flashes', {
            templateUrl: '/Static/Views/flashes.html',
            controller: 'FlashesController'
        })
        .otherwise({ redirectTo: '/home' });
    })
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });

angular.module('pitchApp')
    .run(['authService', function (authService) {
        authService.fillAuthData();
    }]);
        