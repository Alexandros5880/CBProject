





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

function doPaynment(user, package, callback) {
    var payment = {
        Auth: {
            UserName: btoa("SB-Mid-server-XhC6ozM7V3n8334ljomw2aS5"),
            Password: ""
        },
        TransactionDetails: {
            OrderId: package.id,
            GrossAmount: package.price
        },
        User: {
            FirstName: user.firstName,
            LastName: user.lastName,
            Email: user.email
        },
        Method: "CreaditCard",
        Secure: true
    }

    $.ajax({
        type: "POST",
        url: "/api/products/payment/frame",
        data: payment,
        success: function (response) {
            if (response) {
                callback(response);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}