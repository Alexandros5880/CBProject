

(function () {

    var forumHub = $.connection.forumHub;

    // Connect To SignalR
    $.connection.hub.start()
    .done(function (responce) {
        $.connection.hub.logging = true;
        $.connection.hub.log("Connected");

        var connectionId = responce.id;
        var messageId = responce.messageId;
        var token = responce.token;

        // Invoce Server side methods
        //forumHub.server.announce("Hello World !!!");

        
    })
    .fail(function (responce) {
        console.log("SignalR Faild !!!");
    });



    // Test Hub Method
    //forumHub.client.announce = function (message) {
    //    alert(message);
    //};





    forumHub.client.createSubject = function () {

    };

    forumHub.client.deleteSubject = function () {

    };

    forumHub.client.createQuestion = function () {

    };

    forumHub.client.deleteQuestion = function () {

    };

    forumHub.client.createAnswer = function () {

    };

    forumHub.client.deleteAnswer = function () {

    };

}) ();

