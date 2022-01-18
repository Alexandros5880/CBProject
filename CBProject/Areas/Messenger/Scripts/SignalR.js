


(function () {

    var messengerHub = $.connection.messengerHub;

    // Connect To SignalR
    $.connection.hub.start()
        .done(function (responce) {
            $.connection.hub.logging = true;
        })
        .fail(function (responce) {
            console.log("SignalR Faild !!!");
        });


    // Create Group
    messengerHub.client.createGroup = function () {

    };

    // Delete Group
    messengerHub.client.deleteGroup = function () {

    };


    // Create Message
    messengerHub.client.createMessage = function () {

    };

    // Delete Message
    messengerHub.client.deleteMessage = function () {

    };

})();

