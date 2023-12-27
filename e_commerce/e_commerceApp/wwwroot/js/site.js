var picture = document.querySelector('#pic');

var picture1 = document.querySelector('#pic1');
var picture2 = document.querySelector('#pic2');
var picture3 = document.querySelector('#pic3');
var picture4 = document.querySelector('#pic4');
var picture5 = document.querySelector('#pic5');
var picture6 = document.querySelector('#pic6');


var mainContainer = document.querySelector('#picture');





picList = [picture1, picture2, picture3, picture4, picture5, picture6]


let picActive = 1;


picture1.classList.add('img-active');


function changeImage(imgSrc, n) {
    
    picture.src = imgSrc;

    var img = document.getElementById('myImage');

// Resmin üzerine gelindiğinde veya tıklandığında çağrılacak fonksiyon
img.addEventListener('mouseenter', function() {
    img.style.transform = 'scale(1.5)';
});

// Fare resmin üzerinden çekildiğinde çağrılacak fonksiyon
img.addEventListener('mouseleave', function() {
    img.style.transform = 'scale(1)';
});
    
    
}