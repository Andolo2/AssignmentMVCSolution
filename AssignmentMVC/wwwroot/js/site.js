

///// Fixed footer START /////

function SetHeight() {
    var offsetHeight = document.getElementById('footer').offsetHeight;
    var screenHeight = window.innerHeight;
    var contentHeight = document.body.scrollHeight;

    if (contentHeight < screenHeight) {
        document.getElementById("footer").style.position = "fixed";
        document.getElementById("footer").style.right = "0";
        document.getElementById("footer").style.bottom = "0";
        document.getElementById("footer").style.left = "0";
    } else {
        document.getElementById("footer").style.position = "static";
    }
}

window.addEventListener('resize', SetHeight);
SetHeight();

///// Fixed footer END /////

///// ContactFormValidation START /////

///// ContactFormValidation END /////

    const menu = document.querySelector("#menu");
    const toggleBtn = document.querySelector(".btn-toggle");

    toggleBtn.addEventListener("click", () => {
        menu.classList.toggle("open");
    });