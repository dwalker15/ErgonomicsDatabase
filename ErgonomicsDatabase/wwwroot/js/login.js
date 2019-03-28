(function() {
    'use strict';
    window.addEventListener('load', function() {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function(form) {
            form.addEventListener('submit', function(event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
                let inputs = form.querySelectorAll('input');
                inputs.forEach(function(input) {
                    setValidationClasses(input, input.checkValidity());
                    input.addEventListener('input', function() {
                        setValidationClasses(input, input.checkValidity());
                    });
                });
            }, false);
        });
    }, false);

    const setValidationClasses = (input, valid) => {
        let iconID = input.id + 'Icon';
        let iconParent = document.getElementById(iconID);
        if (valid) {
            iconParent.classList.remove('invalid');
            iconParent.classList.add('valid');
        } else {
            iconParent.classList.remove('valid');
            iconParent.classList.add('invalid');
        }
    };
})();

$(function() {
    if(window.location.href.indexOf("Register") > -1) {
       $('#loginForm').hide();
        $('#registerForm').show();
    }

    $('.register').on('click', function(e) {
        e.preventDefault();
        $('#loginForm').slideUp();
        $('#registerForm').slideDown();
    });

    $('.login').on('click', function(e) {
        e.preventDefault();
        $('#registerForm').slideUp();
        $('#loginForm').slideDown();
    });
});
