// Request To All Api Controllers Service

function getContentsByCategoryId(categoryId, callback) {
    $.ajax({
        type: "GET",
        url: "/api/products/contenst/bycategory?id=" + categoryId,
        success: function (data) {
            if (data) {
                callback(data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getContentsByCategoryName(categoryName, callback) {
    $.ajax({
        type: "GET",
        url: "/api/products/contenst/bycategory?name=" + categoryName,
        success: function (data) {
            if (data) {
                callback(data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getProductsByFilters(sendData, callback) {
    $.ajax({
        type: "POST",
        url: "/api/products/search/filters",
        data: sendData,
        success: function (data) {
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
        },
        error: function (error) {
            console.log('error:');
            console.log(error);
        }
    });
}

function getSubscriptionPackage(packageId, callback) {
    return $.ajax({
        type: "GET",
        url: `/api/packages?id=${packageId}`,
        success: function (data) {
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
        },
        error: function (error) {
            return error;
        }
    });
}

function getCategories(callback) {
    $.ajax({
        type: "GET",
        url: "/api/categories",
        success: function (data) {
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getUsersByRoleName(roleName, callback) {
    $.ajax({
        type: "GET",
        url: "/api/users/role?rolename=" + roleName,
        success: function (data) {
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getVideos(callback) {
    $.ajax({
        type: "GET",
        url: "/api/videos",
        success: function (data) {
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getContentTypes(callback) {
    $.ajax({
        type: "GET",
        url: "/api/contenttypes",
        success: function (data) {
            if (data) {
                callback(data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getContentType(id, callback) {
    $.ajax({
        type: "GET",
        url: "/api/contenttype?id=" + id,
        success: function (data) {
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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
            if (data) {
                callback(data);
            }
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

function createOrder(user, package, callback) {
    var today = new Date();
    $.ajax({
        type: "POST",
        url: `/api/order/new`,
        data: {
            user: user,
            subscriptionPackage: package,
            isClose: false,
            createdDate: today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate(),
            lastUpdateDate: today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate()
        },
        success: function (data) {
            callback(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}






// Other Functions
function redirectToGuestDetails(categoryId, contentId, contentType) {
    console.log(contentType);
    if (contentType === "ebook") {
        window.location.href = '/Ebooks/PublicDetails/' + contentId;
    } else if (contentType === "video") {
        window.location.href = '/Videos/PublicDetails/' + contentId;
    }
}

function createOrder(packageId) {
    getSubscriptionPackage(packageId, function (package) {
        getLogedUser(function (user) {
            if (user !== "null") {
                //doPayment(user, package);
                payPayPal(user, package);
            } else {
                window.location.href = "/Account/Register";
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