(function () {
    'use strict';

    angular
        .module('angularDemoApp')
        .factory('criminalFactory', criminalFactory);

    criminalFactory.$inject = ['$http'];

    function criminalFactory($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            deleteById :deleteById
        };

        return service;

        function getAll() {
            return $http.get("/api/criminals/");
        }
        function getById(id) {
            return $http.get("/api/criminals/"+id);
        }
        function deleteById(id) {
            return $http.delete("/api/criminals/" + id);
        }
    }
})();