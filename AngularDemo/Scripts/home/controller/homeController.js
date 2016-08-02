(function () {
    'use strict';

    angular
        .module('angularDemoApp')
        .controller('homeController', homeController);

    homeController.$inject = ['criminalFactory'];

    function homeController(criminalFactory) {
        /* jshint validthis:true */
        var vm = this;
        vm.getAll = getAll;
        vm.getById = getById;
        vm.deleteById = deleteById;
        vm.title = 'homeController';

        activate();

        function activate() {
        }

        function getAll() {
            criminalFactory.getAll()
                .success(function (result) {
                    vm.collectionCriminals = result;
                })
                .catch(function (exception) {
                    var ex = exception;
                });
        };
        function getById(id) {
            criminalFactory.getById(id)
                .success(function (result) {
                    vm.criminal = result;
                })
                .catch(function (exception) {
                    var ex = exception;
                });
        };
        function deleteById(id) {
            criminalFactory.deleteById(id)
                .success(function (result) {
                    angular.forEach(vm.collectionCriminals, function (item, key) {
                        if (item.ID === id) {
                            var idx = vm.collectionCriminals.indexOf(item);
                            if (idx !== -1) {
                                vm.collectionCriminals.splice(idx, 1);
                            }
                        }
                    });

                })
                .catch(function (exception) {
                    var ex = exception;
                });
        };
    }
})();
