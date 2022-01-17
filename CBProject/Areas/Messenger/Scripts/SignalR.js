



// Connect To SignalR
$.connection.hub.start()
    .done(function (responce) {
        console.log("SignalR Connected !!!");
    })
    .fail(function (responce) {
        console.log("SignalR Faild !!!");
    });








// Create Group
$.connection.messengerHub.client.createGroup = function () {

};

// Delete Group
$.connection.messengerHub.client.deleteGroup = function () {

};


// Create Message
$.connection.messengerHub.client.createMessage = function () {

};

// Delete Message
$.connection.messengerHub.client.deleteMessage = function () {

};