



// Connect To SignalR
$.connection.hub.start()
    .done(function (responce) {
        console.log("SignalR Connected !!!");

        // Invoce Server side method
        $.connection.forumHub.server.announce("Hello World !!!");
    })
    .fail(function (responce) {
        console.log("SignalR Faild !!!");
    });



// Test Hub Method
$.connection.forumHub.client.announce = function (message) {
    alert(message);
};







// Create Subject
$.connection.forumHub.client.createSubject = function () {
    
};

// Delete Subject
$.connection.forumHub.client.deleteSubject = function () {

};


// Create Question
$.connection.forumHub.client.createQuestion = function () {

};

// Delete Question
$.connection.forumHub.client.deleteQuestion = function () {

};

// Create Answer
$.connection.forumHub.client.createAnswer = function () {

};

// Delete Answer
$.connection.forumHub.client.deleteAnswer = function () {

};