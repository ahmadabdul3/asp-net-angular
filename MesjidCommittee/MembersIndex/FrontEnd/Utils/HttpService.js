angular.module("HttpUtil", [])
.factory('HttpService', HttpService);

HttpService.$inject = ['$http', '$q'];

function HttpService($http, $q) {
    
    return {
        getMethod: 'GET',
        postMethod: 'POST',

        basicGet: function (url) {
            return $http.get(url).then(
                function (result) {
                    return result.data;
                },
                function (result) {
                    $q.reject(result.data);
                }
            );
        },
        httpWithParams: function (url, method, params) {
            return $http({
                url: url,
                method: method,
                params: params
            }).then(
                function (result) {
                    return result.data;
                },
                function (result) {
                    return $q.reject(result.data);
                }
            );
        },
        handleHttpError: function (error) {
            console.log(error);
        }
        

    }
}