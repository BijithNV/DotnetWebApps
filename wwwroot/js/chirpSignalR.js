(function () {
    "use strict";

    // SignalR's hub object.
    var TwitterClonePostHub = $.connection.TwitterClonePostHub;

    $(function () {
        $.connection.hub.logging = true;
        $.connection.hub.start();
    });

    angular.module('app-TwitterClone').value('TwitterClonePostHub', TwitterClonePostHub);
})();