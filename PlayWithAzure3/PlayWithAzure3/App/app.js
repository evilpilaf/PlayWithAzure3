
    var app = angular.module('app', []);
    app.controller('newsletterController', function($scope, $http, $location) {
        $scope.sendEmail = function() {

            var headers = [{ 'Content-Type': 'application/json' }];
            var port = '';
            if ($location.port() !== 80)
                port = ':' + $location.port();
            var url = $location.protocol() + '://' + $location.host() + port + '/api/subscribe';
            var requestBody = {
                email: $scope.userEmail
            };
            $http.post(url, requestBody, headers)
                .success()
                .error();
        }
    });