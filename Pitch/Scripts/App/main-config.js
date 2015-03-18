'use strict';
angular.module('pitchApp')
    .config(function ($routeProvider) {
        $routeProvider
        .when('/prof', {
            templateUrl: '/Static/Views/profile.html',
            controller: 'ProfileController',
            controllerAs: 'profCtrl'
        })
        /*.when('/prof/edit', {
            templateUrl: '/Static/Views/edit-profile.html',
            controller: 'EditProfileController',
            controllerAs: 'profCtrl',
        })*/
        .when('/signup', {
            templateUrl: '/Static/Views/signup.html',
            controller: 'SignupController'
            //controllerAs: 'signCtrl'
        })
        .when('/login', {
            templateUrl: '/Static/Views/login.html',
            controller: 'LoginController'
            //controllerAs: 'loginCtrl'
        })
        .when('/home', {
            templateUrl: '/Static/Views/home.html',
            controller: 'HomeController'
            //controllerAs: 'homeCtrl'
        })
        .when('/', {
            templateUrl: '/Views/Home/index.cshtml'
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
        