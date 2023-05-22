

/////// Fixed footer START /////

//function SetHeight() {
//    var offsetHeight = document.getElementById('footer').offsetHeight;
//    var screenHeight = window.innerHeight;
//    var contentHeight = document.body.scrollHeight;

//    if (contentHeight < screenHeight) {
//        document.getElementById("footer").style.position = "fixed";
//        document.getElementById("footer").style.right = "0";
//        document.getElementById("footer").style.bottom = "0";
//        document.getElementById("footer").style.left = "0";
//    } else {
//        document.getElementById("footer").style.position = "static";
//    }
//}

//window.addEventListener('resize', SetHeight);
//SetHeight();

/////// Fixed footer END /////

/////// ContactFormValidation END /////

//    const menu = document.querySelector("#menu");
//    const toggleBtn = document.querySelector(".btn-toggle");

//    toggleBtn.addEventListener("click", () => {
//        menu.classList.toggle("open");
//    });



//// Validation on my contactoforms. Adds error messeges when the input field is empty, and remove when the feild is populated.
//document.addEventListener('DOMContentLoaded', function () {
//    const submitButton = document.getElementById('submit-button');
//    submitButton.addEventListener('click', function (event) {
//        const nameInput = document.getElementById('ContactNameId');
//        const phoneInput = document.getElementById('ContactPhoneId');
//        const emailInput = document.getElementById('ContactEmailId');
//        const companyInput = document.getElementById('ContactCompanyId');
//        const commentInput = document.getElementById('ContactCommentId');

//        const nameValue = nameInput.value.trim();
//        const phoneValue = phoneInput.value.trim();
//        const emailValue = emailInput.value.trim();
//        const companyValue = companyInput.value.trim();
//        const commentValue = commentInput.value.trim();

//        if (nameValue === '') {
//            event.preventDefault();
//            const errorMessage = nameInput.nextElementSibling;
//            errorMessage.textContent = 'Please enter your name.';
//        } else {
//            const errorMessage = nameInput.nextElementSibling;
//            errorMessage.textContent = '';
//        }

//        if (phoneValue === '') {
//            event.preventDefault();
//            const errorMessage = phoneInput.nextElementSibling;
//            errorMessage.textContent = 'Please enter your phone number.';
//        } else {
//            const errorMessage = phoneInput.nextElementSibling;
//            errorMessage.textContent = '';
//        }

//        if (emailValue === '') {
//            event.preventDefault();
//            const errorMessage = emailInput.nextElementSibling;
//            errorMessage.textContent = 'Please enter your email.';
//        } else {
//            const errorMessage = emailInput.nextElementSibling;
//            errorMessage.textContent = '';
//        }

//        if (companyValue === '') {
//            event.preventDefault();
//            const errorMessage = companyInput.nextElementSibling;
//            errorMessage.textContent = 'Please enter your company name.';
//        } else {
//            const errorMessage = companyInput.nextElementSibling;
//            errorMessage.textContent = '';
//        }

//        if (commentValue === '') {
//            event.preventDefault();
//            const errorMessage = commentInput.nextElementSibling;
//            errorMessage.textContent = 'Please enter your comment.';
//        } else {
//            const errorMessage = commentInput.nextElementSibling;
//            errorMessage.textContent = '';
//        }
//    });

//    const nameInput = document.getElementById('ContactNameId');
//    nameInput.addEventListener('input', function () {
//        const errorMessage = nameInput.nextElementSibling;
//        if (nameInput.value.trim() === '') {
//            errorMessage.textContent = 'Please enter your name.';
//        } else {
//            errorMessage.textContent = '';
//        }
//    });

//    const phoneInput = document.getElementById('ContactPhoneId');
//    phoneInput.addEventListener('input', function () {
//        const errorMessage = phoneInput.nextElementSibling;
//        if (phoneInput.value.trim() === '') {
//            errorMessage.textContent = 'Please enter your phone number.';
//        } else {
//            errorMessage.textContent = '';
//        }
//    });

//    const emailInput = document.getElementById('ContactEmailId');
//    emailInput.addEventListener('input', function () {
//        const errorMessage = emailInput.nextElementSibling;
//        if (emailInput.value.trim() === '') {
//            errorMessage.textContent = 'Please enter your email.';
//        } else {
//            errorMessage.textContent = '';
//        }
//    });

//    const companyInput = document.getElementById('ContactCompanyId');
//    companyInput.addEventListener('input', function () {
//        const errorMessage = companyInput.nextElementSibling;
//        if (companyInput.value.trim() === '') {
//            errorMessage.textContent = 'Please enter your company name.';
//        } else {
//            errorMessage.textContent = '';
//        }
//    });

//    const commentInput = document.getElementById('ContactCommentId');
//    commentInput.addEventListener('input', function () {
//        const errorMessage = commentInput.nextElementSibling;
//        if (commentInput.value.trim() === '') {
//            errorMessage.textContent = 'Please enter your comment.';
//        } else {
//            errorMessage.textContent = '';
//        }
//    });
//});

///// Register account validation

//document.addEventListener('DOMContentLoaded', function () {
//    const form = document.querySelector('.form-registration');

//    form.addEventListener('submit', (event) => {
//        event.preventDefault(); // Add this line to prevent form submission

//        const firstName = document.getElementById('register-firstname').value;
//        const lastName = document.getElementById('register-lastname').value;
//        const streetname = document.getElementById('register-streetname').value;
//        const postalcode = document.getElementById('register-postalcode').value;
//        const mobile = document.getElementById('register-mobile').value;
//        const city = document.getElementById('register-city').value;
//        const email = document.getElementById('register-email').value;
//        const password = document.getElementById('register-password').value;

//        const errorMessageFirstName = document.getElementById('firstname-error-message');
//        const errorMessageLastName = document.getElementById('lastname-error-message');
//        const errorMessageStreetName = document.getElementById('streetname-error-message');
//        const errorMessagePostalCode = document.getElementById('postalcode-error-message');
//        const errorMessageMobile = document.getElementById('mobile-error-message');
//        const errorMessageCity = document.getElementById('city-error-message');
//        const errorMessageEmail = document.getElementById('email-error-message');
//        const errorMessagePassword = document.getElementById('password-error-message');

//        if (firstName.length < 2) {
//            errorMessageFirstName.textContent = 'First name must be minimum 2 characters';
//        } else {
//            errorMessageFirstName.textContent = '';
//        }

//        if (lastName.length < 2) {
//            errorMessageLastName.textContent = 'Last name must be minimum 2 characters';
//        } else {
//            errorMessageLastName.textContent = '';
//        }

//        if (streetname.length < 2) {
//            errorMessageStreetName.textContent = 'Street name must be minimum 2 characters';
//        } else {
//            errorMessageStreetName.textContent = '';
//        }

//        if (postalcode.length !== 6) {
//            errorMessagePostalCode.textContent = 'Postal code must be 6 characters';
//        } else {
//            errorMessagePostalCode.textContent = '';
//        }

//        if (mobile.length < 6) {
//            errorMessageMobile.textContent = 'Mobile number code must be 6 characters';
//        } else {
//            errorMessageMobile.textContent = '';
//        }

//        if (city.length < 2) {
//            errorMessageCity.textContent = 'City name must be minimum 2 characters';
//        } else {
//            errorMessageCity.textContent = '';
//        }

//        if (email.length < 4) {
//            errorMessageEmail.textContent = 'Email must be minimum 4 characters';
//        } else {
//            errorMessageEmail.textContent = '';
//        }

//        if (password.length < 8) {
//            errorMessagePassword.textContent = 'Password must be minimum 8 characters';
//        } else {
//            errorMessagePassword.textContent = '';
//        }

//        // Check if all error messages are empty before submitting the form
//        if (errorMessageFirstName.textContent === '' && errorMessageLastName.textContent === '' && errorMessageStreetName.textContent === '' && errorMessagePostalCode.textContent === '' && errorMessageMobile.textContent === '' && errorMessageCity.textContent === '' && errorMessageEmail.textContent === '' && errorMessagePassword.textContent === '') {
//            form.submit();
//        }
//    });
//});


///// Login form validation

//document.addEventListener('DOMContentLoaded', function () {
//    const form = document.querySelector('.signupform');

//    form.addEventListener('submit', function (event) {
//        const loginEmail = document.getElementById('Login-Email').value;
//        const loginPassword = document.getElementById('Login-password').value;

//        const LoginErrorEmail = document.getElementById('login-error-message-email');
//        const LoginErrorPassword = document.getElementById('login-error-message-password')

//        if (loginEmail.length < 4) {
//            LoginErrorEmail.textContent = 'Email is too short';
//            event.preventDefault();
//        } else {
//            LoginErrorEmail.textContent = '';
//        }

//        if (loginPassword.length < 6) {
//            LoginErrorPassword.textContent = 'Password is too short';
//            event.preventDefault();
//        } else {
//            LoginErrorPassword.textContent = '';
//        }
//    });
//});
