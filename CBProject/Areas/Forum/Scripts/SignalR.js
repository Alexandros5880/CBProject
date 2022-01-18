

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





    // Create Subject
    forumHub.client.createSubject = function () {

    };

    // Delete Subject
    forumHub.client.deleteSubject = function () {

    };


    // Create Question
    forumHub.client.createQuestion = function () {

    };

    // Delete Question
    forumHub.client.deleteQuestion = function () {

    };

    // Create Answer
    forumHub.client.createAnswer = function () {

    };

    // Delete Answer
    forumHub.client.deleteAnswer = function () {

    };

}) ();

