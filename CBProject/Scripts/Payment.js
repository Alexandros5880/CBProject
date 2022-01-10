

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
                    //localStorage.removeItem('order');
                    order.isClose = true;
                    var myorder = {
                        id: order.id,
                        userId: order.userId,
                        subscriptionId: order.subscriptionPackageId,
                        isClose: order.isClose,
                        isCanceled: order.isCanceled,
                        isCanceledByError: order.isCanceledByError
                    }
                    updateOrder(myorder, function (responseOrder) {
                        var payment = {
                            userId: responseOrder.userId,
                            price: responseOrder.price,
                            tax: 24.00,
                            discount: 0.33
                        };
                        createPayment(payment, function (responsePayment) {
                            var order = JSON.parse(localStorage.getItem('order'));
                            localStorage.removeItem('order');
                            alert("Payment is Done!");
                            window.location = `/SubscriptionPackages/AfterPayment?paymentId=${responsePayment.id}&orderId=${order.id}`;
                        });
                    });
                });
            },

            // On Payment Canceled
            onCancel: function (data) {
                var order = JSON.parse(localStorage.getItem('order'));
                localStorage.removeItem('order');
                order.isCanceled = true;
                console.log("Before Update Order");
                console.log(order);
                var myorder = {
                    id: order.id,
                    userId: order.userId,
                    subscriptionId: order.subscriptionPackageId,
                    isClose: order.isClose,
                    isCanceled: order.isCanceled,
                    isCanceledByError: order.isCanceledByError
                }
                updateOrder(myorder, function (responseOrder) {
                    window.location.href = "/SubscriptionPackages/Subscribe";
                });
            },

            // On Transactions Error
            onError: function (err) {
                var order = JSON.parse(localStorage.getItem('order'));
                localStorage.removeItem('order');
                //deleteOrder(order.id, function (response) {
                //    console.log("Delete Ok.");
                //});
                order.isCanseledByError = true;
                var myorder = {
                    id: order.id,
                    userId: order.userId,
                    subscriptionId: order.subscriptionPackageId,
                    isClose: order.isClose,
                    isCanceled: order.isCanceled,
                    isCanceledByError: order.isCanceledByError
                }
                updateOrder(myorder, function (responseOrder) {
                    //console.log("Order Canceled By Error.");
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
        //console.log(order);
        localStorage.setItem('order', JSON.stringify(order));
    });
}


$(document).ready(function () {

    // When close payment modal
    $('.paymentModal').on('hidden.bs.modal', function () {
        var order = JSON.parse(localStorage.getItem('order'));
        localStorage.removeItem('order');
        order.isCanceled = true;
        console.log("Before Update Order");
        console.log(order);
        var myorder = {
            id: order.id,
            userId: order.userId,
            subscriptionId: order.subscriptionPackageId,
            isClose: order.isClose,
            isCanceled: order.isCanceled,
            isCanceledByError: order.isCanceledByError
        }
        updateOrder(myorder, function (responseOrder) {
            window.location.href = "/SubscriptionPackages/Subscribe";
        });
    });

});