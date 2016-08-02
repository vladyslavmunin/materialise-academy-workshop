(function () {
    'use strict';

    angular
        .module('angularDemoApp')
        .factory('criminalFactory', criminalFactory);

    criminalFactory.$inject = ['$http'];

    function criminalFactory($http) {
        var service = {
            getAll: getAll,
            deleteByID: deleteByID
        };

        return service;

        function getAll() {
            return $http.get("/api/criminals");
        }

        function deleteByID(id) {
            return $http.delete("/api/criminals", { params: { id: id } });
        }
    }
})();