﻿// Request To All Api Controllers Service

function getContentsByCategoryId(categoryId, subscriptionPackageId = null, callback) {
    $.ajax({
        type: "POST",
        data: {
            categoryId: categoryId,
            sabscriptionPackageId: subscriptionPackageId
        },
        url: `/api/products/contenst/bycategoryid`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getContentsByCategoryName(categoryName, subscriptionPackageId = null, callback) {
    $.ajax({
        type: "POST",
        data: {
            categoryName: categoryName,
            sabscriptionPackageId: subscriptionPackageId
        },
        url: `/api/products/contenst/bycategoryname`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getProductsByFilters(sendData, callback) {
    //console.log(JSON.stringify(sendData));
    $.ajax({
        type: "POST",
        url: "/api/products/search/filters",
        data: sendData,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getPageSize(callback) {
    $.ajax({
        type: "GET",
        url: "/api/pagesize",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getSubscriptionPackages(callback) {
    $.ajax({
        type: "GET",
        url: "/api/products/packages",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log('error:');
            console.log(error);
        }
    });
}
function getSubscriptionPackage(id, callback) {
    return $.ajax({
        type: "GET",
        url: `/api/packages/${id}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log('error:');
            console.log(error);
        }
    });
}

function getUserById(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/user?userId=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            return error;
        }
    });
}
function getUserByIdSync(id, callback) {
    $.ajax({
        type: "GET",
        async: false,
        url: "/api/user?userId=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            return error;
        }
    });
}
function getLogedUser(callback) {
    $.ajax({
        type: "GET",
        url: "/api/logged/user",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            return error;
        }
    });
}
function getLogedUserSync(callback) {
    $.ajax({
        type: "GET",
        async: false,
        url: "/api/logged/user",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            return error;
        }
    });
}
function getUsersByRoleName(roleName, callback) {
    $.ajax({
        type: "GET",
        url: "/api/users/role?rolename=" + roleName,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getRole(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/role?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getRoleSync(id, callback) {
    $.ajax({
        type: "GET",
        async: false,
        url: "/api/role?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getCategories(callback) {
    $.ajax({
        type: "GET",
        url: "/api/categories",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getCategory(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/category?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getCategorySync(id, callback) {
    $.ajax({
        type: "GET",
        async: false,
        url: "/api/category?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getCategoriesMaster(callback) {
    $.ajax({
        type: "GET",
        url: "/api/categories/masters",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getCategoriesNoMaster(callback) {
    $.ajax({
        type: "GET",
        url: "/api/categories/nomasters",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getTags(callback) {
    $.ajax({
        type: "GET",
        url: "/api/tags",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getTag(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/tag?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getReviews(callback) {
    $.ajax({
        type: "GET",
        url: "/api/reviews",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getReview(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/review?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getReviewsByVideo(id, callback) {
    $.ajax({
        type: "GET",
        url: `/api/Review/video/${id}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getReviewsByEbook(id, callback) {
    $.ajax({
        type: "GET",
        url: `/api/Review/ebook/${id}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getEbooks(callback) {
    $.ajax({
        type: "GET",
        url: "/api/ebooks",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getEbooksPage(page, callback) {
    $.ajax({
        type: "GET",
        url: `/api/Ebook/Page/${page}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getEbooksPages(callback) {
    $.ajax({
        type: "GET",
        url: `/api/Ebook/Pages`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getEbook(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/ebook?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function ebookAddRate(id, rate, callback) {
    $.ajax({
        type: "GET",
        url: `/api/Ebook/AddRate/${id}/${rate}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getPDF(file, callback) {
    $.ajax({
        type: "POST",
        url: `/api/ebook/pdf`,
        data: {
            file: file
        },
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
};
function getPDFSync(file, callback) {
    $.ajax({
        type: "POST",
        url: `/api/ebook/pdf`,
        async: false,
        data: {
            file: file
        },
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
};

function getVideos(callback) {
    $.ajax({
        type: "GET",
        url: "/api/videos",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getVideosPage(page, callback) {
    $.ajax({
        type: "GET",
        url: `/api/Video/Page/${page}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getVideosPages(callback) {
    $.ajax({
        type: "GET",
        url: `/api/Video/Pages`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getVideo(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/video?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function videoAddRate(id, rate, callback) {
    $.ajax({
        type: "GET",
        url: `/api/Video/AddRate/${id}/${rate}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getPayments(callback) {
    $.ajax({
        type: "GET",
        url: "/api/payments",
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getPayment(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/payment?id=" + id,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function addEbookRequarement(id, content, callback) {
    $.ajax({
        type: "POST",
        url: `/api/ebook/requarements/add/${id}`,
        data: {
            content: content
        },
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function removeEbookRequarement(id, contentId, callback) {
    $.ajax({
        type: "GET",
        url: `/api/ebook/requarements/remove/${id}/${contentId}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function addVideoRequarement(id, content, callback) {
    $.ajax({
        type: "POST",
        url: `/api/video/requarements/add/{id}`,
        data: {
            content: content
        },
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function removeVideoRequarement(id, contentId, callback) {
    $.ajax({
        type: "GET",
        url: `/api/video/requarements/remove/${id}/${contentIdt}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function addNewOrder(user, package, callback) {
    var today = new Date();
    $.ajax({
        type: "POST",
        url: `/api/order/new`,
        data: {
            userId: user.id,
            subscriptionId: package.id,
            isClose: false,
            isCanceled: false,
            isCanceledByError: false
        },
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function updateOrder(order, callback) {
    $.ajax({
        type: "PUT",
        url: `/api/order/update`,
        data: order,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function deleteOrder(id, callback) {
    $.ajax({
        type: "DELETE",
        url: `/api/order/delete/${id}`,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function createPayment(payment, callback) {
    var today = new Date();
    $.ajax({
        type: "POST",
        url: `/api/payment/create`,
        data: payment,
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}





// Other Functions

// Redirect or to Video PublicDetails or to Ebook PublicDetails
function redirectToGuestDetails(ccontentId, contentType) {
    console.log("Details Pressed.");
    console.log(`contentId: ${contentId}   contentType: ${contentType}`);
    if (contentType === "ebook") {
        window.location.href = '/Ebooks/PublicDetails/' + contentId;
    } else if (contentType === "video") {
        window.location.href = '/Videos/PublicDetails/' + contentId;
    }
}

// First When You Buy Package If You are not logged gor to login else to buy a package
function createOrder(packageId) {
    getSubscriptionPackage(packageId, function (package) {
        getLogedUser(function (user) {
            if (user !== "null") {
                payPayPal(user, package);
            } else {
                window.location.href = `/Account/Login?returnUrl=/SubscriptionPackages/Subscribe`;
            }
        });
    });
}

function addRequirements(modelId, content, type) {
    if (type === 'ebook') {
        addEbookRequarement(modelId, content, function (response) {
            location.reload();
        });
    } else if (type == 'video') {
        addVideoRequarement(modelId, content, function (response) {
            location.reload();
        });
    }
}

function removeRequarements(modelId, contentId, type) {
    if (type === 'ebook') {
        removeEbookRequarement(modelId, contentId, function (response) {
            location.reload();
        });
    } else if (type == 'video') {
        removeVideoRequarement(modelId, contentId, function (response) {
            location.reload();
        });
    }
}

function parseDateTime(date) {
    var Y = date.split("T")[0].split("-")[0];
    var M = date.split("T")[0].split("-")[1];
    var D = date.split("T")[0].split("-")[2];
    var h = date.split("T")[1].split(".")[0].split(":")[0];
    var m = date.split("T")[1].split(".")[0].split(":")[1];
    var s = date.split("T")[1].split(".")[0].split(":")[2];
    var ms = date.split("T")[1].split(".")[1];
    return new Date(Y, M, D, h, m, s, ms);
}

function compaire(a, b) {
    if (a == b) return 0;
    if (a < b) return -1;
    if (a > b) return 1;
}

// Function displays if subscribed or not
function isSubscribed(bool, package = null) {
    if (bool && package != null) {
        return `
                <b>${package.description}<b/>
                <img src="/img/checked.jpg" alt="subscribed" class="rounded" style="height:17px;">`;
    } else {
        return ``;
    }
}
// Function displays if subscribed or not
function getPackages(bool, packages = null) {
    if (bool && packages.length > 0) {
        var html = `<ul>`;
        packages.forEach(function (package) {
            html += `<li>${package.description}</li>`;
        });
        html += `</ul>`
        return html;
    } else {
        return ``;
    }
}
