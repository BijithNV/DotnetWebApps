(function () {
    "use strict";

    //Getting the existing module
    angular.module("app-TwitterClone")
        .controller("userController", userController);

    function userController($http, $scope, TwitterClonePostHub) {
        var vm = this;
        vm.user = {};
        
        vm.TwitterClonePosts = [];
        vm.errorMessage = "";
        vm.pageReady = false;

        vm.gotUser = false;
        vm.gotTwitterClones = false;

        vm.init = function (userName) {
            vm.pageUserName = userName;
            vm.getUser();
            vm.getTwitterClones();
        };

        vm.getUser = function () {
            vm.isBusyUser = true;
            var userUrl = "/api/user/";
            userUrl = userUrl.concat(vm.pageUserName);
            $http.get(userUrl)
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.user);
                vm.gotUser = true;
            }, function (error) {
                //Failure
                vm.errorMessage = "Failed to get User Info: " + error;
            })
            .finally(function () {
                vm.isBusyUser = false;
            });
        };

        vm.getTwitterClones = function () {
            vm.isBusyTwitterClones = true;
            var userUrl = "/api/TwitterCloneposts/";
            userUrl = userUrl.concat(vm.pageUserName);
            $http.get(userUrl)
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.TwitterClonePosts);
                vm.gotTwitterClones = true;
            }, function (error) {
                //Failure
                vm.errorMessage = "Failed to get TwitterClones: " + error;
            })
            .finally(function () {
                vm.isBusyTwitterClones = false;
            });
        };

        $scope.$watch("vm.gotTwitterClones", function () {
            if (vm.gotUser === true) {
                vm.pageReady = true;
            }
        });

        $scope.$watch("vm.gotUser", function () {
            if (vm.gotTwitterClones === true) {
                vm.pageReady = true;
            }
        });

        vm.hasTwitterClones = function () {
            if (vm.TwitterClonePosts.length > 0) {
                return true;
            }
            return false;
        };

        // Method which receives data.
        TwitterClonePostHub.client.refreshTwitterClones = function () {
            // Method which handles messages.
            vm.getTwitterClones();
            $scope.$apply();
        };
    }
})();