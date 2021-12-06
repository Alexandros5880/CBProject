﻿$(document).ready(function () {
    var table = $("#videos").DataTable({
        ajax: {
            url: "/api/videos",
            dataSrc: ""
        },
        columns: [
            {
                title: "Video Title",
                data: "title",
                render: function (data, type, video) {
                    return video.title;
                }

            },
            {
                title: "Description",
                data: "description",
                render: function (data, type, video) {
                    return video.description;
                }
            },
            {
                title: "Uplaod Date",
                data: "uploadDate",
                render: function (data, type, video) {
                    return video.uploadDate;
                }
            },
            {
                data: "id",
                render: function (data, type, video) {
                    return "<a href='#'>Details </a> | <button class='btn-link js-delete' data-artist-id=" + video.id + ">Delete</button>";
                }
            }

        ]
    });
});