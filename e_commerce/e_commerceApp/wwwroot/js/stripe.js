function formatInput(input) {
    // Girilen değerden boşlukları kaldır
    var value = input.value.replace(/\s/g, '');

    // Sadece sayısal karakterleri al
    var numericValue = value.replace(/\D/g, '');

    // Maksimum 16 karakter sınırlamasını kontrol et
    if (numericValue.length > 16) {
        numericValue = numericValue.substring(0, 16);
    }

    // Sayıları dört haneli gruplara ayır
    var formattedValue = numericValue.replace(/(\d{1,4})(\d{1,4})?(\d{1,4})?(\d{1,4})?/, function (match, p1, p2, p3, p4) {
        return (p1 ? p1 + ' ' : '') + (p2 ? p2 + ' ' : '') + (p3 ? p3 + ' ' : '') + (p4 ? p4 : '');
    });

    // Formatlanmış değeri input'a geri yaz
    input.value = formattedValue;
}

var stripe = Stripe('pk_test_51OT7KlG4ohSFXRN6pCYjy1HT6JaxWPRYLX5KbwFXiqUlHkcQAxJkXQhBJjGwyLUcexWdWuJtZDUp6R5Wkd4jzebF00qDsDu6ol');
var elements = stripe.elements();

var card = elements.create('card');
card.mount('#card-element');

var cardholderName = document.getElementById('cardholder-name');

document.getElementById('payment-form').addEventListener('submit', function (event) {
    event.preventDefault();
    
    stripe.createPaymentMethod({
        type: 'card',
        card: card,
        billing_details: {
            name: cardholderName.value,
        },
    }).then(function (result) {
        if (result.error) {
            // Hata durumunda kullanıcıya bildirin
            console.error(result.error.message);
        } else {
            // Başarılı durumda ödeme yöntemi kimliğini sunucuya gönderin
            var paymentMethodId = result.paymentMethod.id;

            // Sunucuya göndermek için ödeme yöntemi kimliğini kullanabilirsiniz
            // Örneğin, fetch veya başka bir AJAX yöntemiyle sunucuya POST isteği gönderin
            fetch('/your-server-endpoint', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    paymentMethodId: paymentMethodId,
                    cardholderName: cardholderName.value,
                }),
            }).then(function (response) {
                return response.json();
            }).then(function (result) {
                // Sunucudan gelen sonucu işle
                if (result.success) {
                    // Başarılı sayfasına yönlendir veya gerekli işlemleri gerçekleştir
                } else {
                    // Hata mesajını göster veya hata sayfasına yönlendir
                }
            });
        }
    });
});