

// PayPal
function payPayPal(user, package) {
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
                    var order = JSON.parse(localStorage.getItem('order'));
                    order.isClose = true;
                    var myorder = {
                        id: order.id,
                        userEmail: order.user.email,
                        subscriptionId: order.package.id,
                        isClose: order.isClose
                    }
                    updateOrder(myorder, function (responseOrder) {
                        var payment = {
                            userEmail: responseOrder.userEmail,
                            price: responseOrder.price,
                            tax: 24.00,
                            discount: 0.33
                        };
                        createPayment(payment, function (responsePayment) {
                            alert("Payment OK");
                        });
                    });
                });
            },

            // On Payment Canceled
            onCancel: function (data) {
                var order = JSON.parse(localStorage.getItem('order'));
                localStorage.removeItem('order');
                deleteOrder(order.id, function (response) {
                    console.log("Delete Ok.");
                });
                //window.location.href = "/SubscriptionPackages/Subscribe";
            },

            // On Transactions Error
            onError: function (err) {
                var order = JSON.parse(localStorage.getItem('order'));
                localStorage.removeItem('order');
                deleteOrder(order.id, function (response) {
                    console.log("Delete Ok.");
                });
                //window.location.href = "/SubscriptionPackages/Subscribe";
            },

            onInit: function (data, actions) {
                
            },

            onClick: function (data, actions) {
                createNewOrder(user, package);
            },

        }).render('.payment-window');
    });
}




// Create Order
function createNewOrder(user, package) {
    addNewOrder(user, package, function (order) {
        localStorage.setItem('order', JSON.stringify(order));
    });
}

