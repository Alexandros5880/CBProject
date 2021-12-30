

// PayPal
function payPayPal(user, package) {
    // Create Order
    createNewOrder(user, package);
    // Create PayPall Function
    function loadPayPalScript(url, callback) {
        const el = document.querySelector(`script[src="${url}"]`);
        if (!el) {
            const s = document.createElement('script');
            s.setAttribute('src', url); s.onload = callback;
            document.head.insertBefore(s, document.head.firstElementChild);
        }
    }
    // Call PayPal Function
    loadPayPalScript('https://www.paypal.com/sdk/js?client-id=AaPpA83J5kFL7jquL9JPPjBM6H7_Pc6DYw3h5TSUhlbpHxKJ5Au7S7XvjcZBzOjtuBXDLQZiIQ70f7yO&currency=EUR', () => {
        paypal.Buttons({

            // Setup Transaction
            createOrder(data, actions) {
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: package.price,
                        },
                    }],
                });
            },

            // On Payment Done
            onApprove(data, actions) {
                return actions.order.capture().then(details => {
                    // Show a success message to the buyer
                    alert(`Transaction completed by ${details.payer.name.given_name}`);
                    // TODO: 2). Get The Last Orde Of This User, Update it to CLOSE, create Payment ans connect this user with the subscription package
                    console.log(details.payer.email);
                });
            },

            // On Payment Canceled
            onCancel: function (data) {
                alert("You Cansele your Order.");
            },

            // On Transactions Error
            onError: function (err) {
                window.location.href = "/SubscriptionPackages/Subscribe";
            }

        }).render('.payment-window');
    });
}




// Create Order
function createNewOrder(user, package) {
    // TODO: 1). Create new Order here with this user and this subscription package
    //console.log(user);
    //console.log(package);
    createOrder(user, package, function (response) {
        console.log(response);
    });
}

