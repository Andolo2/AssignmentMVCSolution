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

const form = document.querySelector('.contactform'); // select the form element
const inputs = document.querySelectorAll('.contactform input, .contactform textarea'); // select all input and textarea elements in the form
const saveInfoCheckbox = document.querySelector('#save-info');
const submitButton = document.querySelector('#submit-button');

form.addEventListener('submit', function (event) {
    event.preventDefault(); // prevent the form from submitting

    inputs.forEach(input => { // loop through each input and textarea element
        const errorMessage = input.parentElement.querySelector('.error-message'); // select the error message element that corresponds to the input

        if (!input.value) { // check if the input value is empty
            errorMessage.textContent = `Please enter your ${input.name}.`; // set the error message text
        } else {
            errorMessage.textContent = ''; // clear the error message text
        }
    });

    if (!saveInfoCheckbox.checked) { // check if the save info checkbox is not checked
        document.querySelector('.radio .error-message').textContent = 'Please agree to our terms and conditions.'; // set the error message text for the save info checkbox
    } else {
        document.querySelector('.radio .error-message').textContent = ''; // clear the error message text for the save info checkbox
    }

    if (Array.from(inputs).some(input => !input.value) || !saveInfoCheckbox.checked) { // check if any input is empty or if the save info checkbox is not checked
        submitButton.disabled = true; // disable the submit button
    } else {
        submitButton.disabled = false; // enable the submit button
    }
});

///// ContactFormValidation END /////

