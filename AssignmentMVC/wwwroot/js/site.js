

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

///// ContactFormValidation END /////

    const menu = document.querySelector("#menu");
    const toggleBtn = document.querySelector(".btn-toggle");

    toggleBtn.addEventListener("click", () => {
        menu.classList.toggle("open");
    });



// Validation on my contactoforms. Adds error messeges when the input field is empty, and remove when the feild is populated.
const submitButton = document.getElementById('submit-button');
submitButton.addEventListener('click', function (event) {
    const nameInput = document.getElementById('ContactNameId');
    const phoneInput = document.getElementById('ContactPhoneId');
    const emailInput = document.getElementById('ContactEmailId');
    const companyInput = document.getElementById('ContactCompanyId');
    const commentInput = document.getElementById('ContactCommentId');

    const nameValue = nameInput.value.trim();
    const phoneValue = phoneInput.value.trim();
    const emailValue = emailInput.value.trim();
    const companyValue = companyInput.value.trim();
    const commentValue = commentInput.value.trim();

    if (nameValue === '') {
        event.preventDefault();
        const errorMessage = nameInput.nextElementSibling;
        errorMessage.textContent = 'Please enter your name.';
    } else {
        const errorMessage = nameInput.nextElementSibling;
        errorMessage.textContent = '';
    }

    if (phoneValue === '') {
        event.preventDefault();
        const errorMessage = phoneInput.nextElementSibling;
        errorMessage.textContent = 'Please enter your phone number.';
    } else {
        const errorMessage = phoneInput.nextElementSibling;
        errorMessage.textContent = '';
    }

    if (emailValue === '') {
        event.preventDefault();
        const errorMessage = emailInput.nextElementSibling;
        errorMessage.textContent = 'Please enter your email.';
    } else {
        const errorMessage = emailInput.nextElementSibling;
        errorMessage.textContent = '';
    }

    if (companyValue === '') {
        event.preventDefault();
        const errorMessage = companyInput.nextElementSibling;
        errorMessage.textContent = 'Please enter your company name.';
    } else {
        const errorMessage = companyInput.nextElementSibling;
        errorMessage.textContent = '';
    }

    if (commentValue === '') {
        event.preventDefault();
        const errorMessage = commentInput.nextElementSibling;
        errorMessage.textContent = 'Please enter your comment.';
    } else {
        const errorMessage = commentInput.nextElementSibling;
        errorMessage.textContent = '';
    }
});

const nameInput = document.getElementById('ContactNameId');
nameInput.addEventListener('input', function () {
    const errorMessage = nameInput.nextElementSibling;
    if (nameInput.value.trim() === '') {
        errorMessage.textContent = 'Please enter your name.';
    } else {
        errorMessage.textContent = '';
    }
});

const phoneInput = document.getElementById('ContactPhoneId');
phoneInput.addEventListener('input', function () {
    const errorMessage = phoneInput.nextElementSibling;
    if (phoneInput.value.trim() === '') {
        errorMessage.textContent = 'Please enter your phone number.';
    } else {
        errorMessage.textContent = '';
    }
});

const emailInput = document.getElementById('ContactEmailId');
emailInput.addEventListener('input', function () {
    const errorMessage = emailInput.nextElementSibling;
    if (emailInput.value.trim() === '') {
        errorMessage.textContent = 'Please enter your email.';
    } else {
        errorMessage.textContent = '';
    }
});

const companyInput = document.getElementById('ContactCompanyId');
companyInput.addEventListener('input', function () {
    const errorMessage = companyInput.nextElementSibling;
    if (companyInput.value.trim() === '') {
        errorMessage.textContent = 'Please enter your company name.';
    } else {
        errorMessage.textContent = '';
    }
});

const commentInput = document.getElementById('ContactCommentId');
commentInput.addEventListener('input', function () {
    const errorMessage = commentInput.nextElementSibling;
    if (commentInput.value.trim() === '') {
        errorMessage.textContent = 'Please enter your comment.';
    } else {
        errorMessage.textContent = '';
    }
});
