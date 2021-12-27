

// PayPal
function payPayPal(user, package) {
    function loadScript(url, callback) {
        const el = document.querySelector(`script[src="${url}"]`);
        if (!el) {
            const s = document.createElement('script');
            s.setAttribute('src', url); s.onload = callback;
            document.head.insertBefore(s, document.head.firstElementChild);
        }
    }

    loadScript('https://www.paypal.com/sdk/js?client-id=AaPpA83J5kFL7jquL9JPPjBM6H7_Pc6DYw3h5TSUhlbpHxKJ5Au7S7XvjcZBzOjtuBXDLQZiIQ70f7yO&currency=EUR', () => {
        paypal.Buttons({
            // Set up the transaction
            createOrder(data, actions) {
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: package.price,
                        },
                    }],
                });
            },

            // Finalize the transaction
            onApprove(data, actions) {
                return actions.order.capture().then(details => {
                    // Show a success message to the buyer
                    alert(`Transaction completed by ${details.payer.name.given_name}`);
                });
            },

        }).render('.payment-window');
    });
}







