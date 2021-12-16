$(document).ready(function () {

    var username = '@User.Identity.Name.Replace("'", @"\'")';
    var url = "https://localhost:44300/api/Users/" + username;
    console.log(url);

    $.ajax({
        url: "https://localhost:44300/api/Users/40804d32-7d1a-4c7c-b4b3-8650b086d24c",
        method: "GET"
    }).done(function (data) {
        console.log(data);
    }).fail(function (error) {
        console.log("Error: " + error);
    });







})