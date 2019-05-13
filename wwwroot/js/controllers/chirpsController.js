(function () {
    "use strict";

    //Getting the existing module
    angular.module("app-TwitterClone")
        .controller("TwitterClonesController", TwitterClonesController);

    function TwitterClonesController($http, $scope, TwitterClonePostHub) {
        var vm = this;
        vm.TwitterClonePosts = [];
        vm.newTwitterClonePost = {};
        vm.errorMessage = "";
        vm.firstLoad = false;

        vm.getTwitterClones = function () {
            vm.isBusy = true;
            $http.get("/api/TwitterCloneposts")
            .then(function (response) {
                //Success
                vm.firstLoad = true;
                angular.copy(response.data, vm.TwitterClonePosts);
            }, function (error) {
                //Failure
                vm.errorMessage = "Failed to get TwitterClones: " + error.data.message;
            })
            .finally(function () {
                vm.isBusy = false;
            });
        };

        vm.getTwitterClones();
        
        vm.addTwitterClonePost = function () {
            vm.errorMessage = "";
            vm.isBusy = true;

            $http.post("/api/TwitterCloneposts", vm.newTwitterClonePost)
                .then(function (response) {
                    //Success
                    vm.getTwitterClones();
                    vm.newTwitterClonePost.message = "";
                }, function (error) {
                    //Failure
                    vm.errorMessage = "Failed to post TwitterClone: " + error.data.message;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        // Method which receives data.
        TwitterClonePostHub.client.refreshTwitterClones = function () {
            // Method which handles messages.
            vm.getTwitterClones();
            $scope.$apply();
        };
    }
})();