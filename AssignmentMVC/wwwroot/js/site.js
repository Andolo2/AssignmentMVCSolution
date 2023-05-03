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

// Select all the input fields and the submit button
const nameInput = document.querySelector('#name-input');
const phoneInput = document.querySelector('#phone-input');
const emailInput = document.querySelector('#email-input');
const companyInput = document.querySelector('#company-input');
const commentInput = document.querySelector('#comment-input');
const submitButton = document.querySelector('#submit-button');

// Define a function to validate the form
function validateForm(event) {
    event.preventDefault(); // Prevent the form from being submitted

    let isValid = true;

    // Check if the name field is empty
    if (nameInput.value.trim() === '') {
        nameInput.nextElementSibling.textContent = 'Field can not be empty';
        isValid = false;
    } else {
        nameInput.nextElementSibling.textContent = '';
    }

    // Check if the phone field is empty
    if (phoneInput.value.trim() === '') {
        phoneInput.nextElementSibling.textContent = 'Field can not be empty';
        isValid = false;
    } else {
        phoneInput.nextElementSibling.textContent = '';
    }

    // Check if the email field is empty
    if (emailInput.value.trim() === '') {
        emailInput.nextElementSibling.textContent = 'Field can not be empty';
        isValid = false;
    } else {
        emailInput.nextElementSibling.textContent = '';
    }

    // Check if the company field is empty
    if (companyInput.value.trim() === '') {
        companyInput.nextElementSibling.textContent = 'Field can not be empty';
        isValid = false;
    } else {
        companyInput.nextElementSibling.textContent = '';
    }

    // Check if the comment field is empty
    if (commentInput.value.trim() === '') {
        commentInput.nextElementSibling.textContent = 'Field can not be empty';
        isValid = false;
    } else {
        commentInput.nextElementSibling.textContent = '';
    }

    // Enable or disable the submit button based on the form validation
    submitButton.disabled = !isValid;

    // Return the validation result
    return isValid;
}

// Validate the form when it's submitted
document.querySelector('.contactform').addEventListener('submit', validateForm);

// Validate the form when the user changes the input fields
nameInput.addEventListener('input', validateForm);
phoneInput.addEventListener('input', validateForm);
emailInput.addEventListener('input', validateForm);
companyInput.addEventListener('input', validateForm);
commentInput.addEventListener('input', validateForm);


///// ContactFormValidation END /////

///// LOgin form validation /////

const form = document.querySelector('.signupform');
const emailInput = document.querySelector('input[name="Email"]');
const passwordInput = document.querySelector('input[name="Password"]');

form.addEventListener('submit', (event) => {
    event.preventDefault();
    if (emailInput.value.trim() === '') {
        document.querySelector('#Login-Email + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('#Login-Email + span').textContent = '';
    }

    if (passwordInput.value.trim() === '') {
        document.querySelector('#Login-password + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('#Login-password + span').textContent = '';
    }

    if (emailInput.value.trim() !== '' && passwordInput.value.trim() !== '') {
        form.submit();
    }
});


        // Register account validation

const form = document.querySelector('.form-registration');
const firstNameInput = document.querySelector('#register-firstname');
const lastNameInput = document.querySelector('#register-lastname');
const streetNameInput = document.querySelector('#register-streetname');
const postalCodeInput = document.querySelector('#register-postalcode');
const mobileInput = document.querySelector('#register-mobile');
const cityInput = document.querySelector('#register-city');
const companyInput = document.querySelector('#register-company');
const emailInput = document.querySelector('#register-emial');
const passwordInput = document.querySelector('#register-password');
const confirmPasswordInput = document.querySelector('#register-confirm');
const imageFileInput = document.querySelector('input[type="file"]');
const termsAndAgreementInput = document.querySelector('#flexCheckDefault');

form.addEventListener('submit', (event) => {
    event.preventDefault();

    // Validate first name
    if (firstNameInput.value.trim() === '') {
        document.querySelector('label[for="FirstName"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="FirstName"] + span').textContent = '';
    }

    // Validate last name
    if (lastNameInput.value.trim() === '') {
        document.querySelector('label[for="LastName"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="LastName"] + span').textContent = '';
    }

    // Validate street name
    if (streetNameInput.value.trim() === '') {
        document.querySelector('label[for="StreetName"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="StreetName"] + span').textContent = '';
    }

    // Validate postal code
    if (postalCodeInput.value.trim() === '') {
        document.querySelector('label[for="PostalCode"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="PostalCode"] + span').textContent = '';
    }

    // Validate mobile
    if (mobileInput.value.trim() === '') {
        document.querySelector('label[for="Mobile"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="Mobile"] + span').textContent = '';
    }

    // Validate city
    if (cityInput.value.trim() === '') {
        document.querySelector('label[for="City"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="City"] + span').textContent = '';
    }

    // Validate company
    if (companyInput.value.trim() === '') {
        document.querySelector('label[for="Company"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="Company"] + span').textContent = '';
    }

    // Validate email
    if (emailInput.value.trim() === '') {
        document.querySelector('label[for="Email"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="Email"] + span').textContent = '';
    }

    // Validate password
    if (passwordInput.value.trim() === '') {
        document.querySelector('label[for="Password"] + span').textContent = 'Field cannot be empty';
    } else {
        document.querySelector('label[for="Password"] + span').textContent = '';
    }

    // Validate confirm password
    if (confirmPasswordInput.value.trim() === '') {
        document.querySelector('label[for="ConfirmPassword"] + span').textContent = 'Field cannot be empty';
    } else if
