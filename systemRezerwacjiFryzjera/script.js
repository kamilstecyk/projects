var submit_btn = document.getElementById('reg_submit');

var header = document.querySelector(".reg_header");


var wherearewe = 1;


function change_bg(element,color)
{
    element.style.backgroundColor = color;
}


submit_btn.addEventListener('click', function(event)
    {
        

        event.preventDefault();   // prevent from submitting

        submit_btn.style.animation = "shake 0.5s ease-in-out";
        submit_btn.addEventListener("animationend",function()
        {
            this.style.animation =''; // we delete animation because we want have it always on click

        }
        );

        var name_reg = document.getElementById('reg_n');

        var surname_reg = document.getElementById('reg_sur');

        var mail_reg = document.getElementById('reg_m');
        var tel_reg = document.getElementById('reg_t');
        var login_reg = document.getElementById('reg_l');
        var password_reg = document.getElementById('reg_p');

        var body = document.querySelector("body");

        // regex expressions to check if it s validated
        
        let result_validation_name = /^[\s\p{L}]+$/u.test(document.getElementById('reg_n').value); // regex to validate name 
        let result_validation_surname = /^[\s\p{L}]+$/u.test(document.getElementById('reg_sur').value); 
        let result_validation_email = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('reg_m').value);
        let result_validation_login = /^[a-zA-Z0-9]+$/.test(document.getElementById('reg_l').value);
        let result_validation_password = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/.test(document.getElementById('reg_p').value);
        let result_validation_tel = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$/.test(document.getElementById('reg_t').value);


        // thanks to this construction if we input bad pattern we stay in this place until we have good and then we can input next data

        if((wherearewe == 1) && result_validation_name)
        {   


            next_input();
            change_bg(body,"green");  // moze warto zmienic kolory red i green na bardziej przyjkazne oczu
            body.addEventListener("transitionend",()=>{change_bg(body,"#6E5653");});  // on transition end we want to back to previous color

        }
        else if((wherearewe == 2) && result_validation_surname)
        {
            next_input();

            change_bg(body,"green");
            body.addEventListener("transitionend",()=>{change_bg(body,"#6E5653");});  // on transition end we want to back to previous color

        }
        else if(result_validation_email && (wherearewe == 3))
        {
            next_input();
            
            change_bg(body,"green");
            body.addEventListener("transitionend",()=>{change_bg(body,"#6E5653");});  // on transition end we want to back to previous color
            
        }
        else if(result_validation_login && (wherearewe == 4))
        {
            next_input();

            change_bg(body,"green");
            body.addEventListener("transitionend",()=>{change_bg(body,"#6E5653");});  // on transition end we want to back to previous color

        }
        else if(result_validation_password && (wherearewe == 5))
        {
            next_input();
            
            change_bg(body,"green");
            body.addEventListener("transitionend",()=>{change_bg(body,"#6E5653");});  // on transition end we want to back to previous color

        }
        else if(result_validation_tel && (wherearewe == 6))
        {
            next_input();

            change_bg(body,"green");
            body.addEventListener("transitionend",()=>{change_bg(body,"#6E5653");});  // on transition end we want to back to previous color
            
        }
        else if(wherearewe == 7)
        {
            next_input();

            change_bg(body,"green");
            body.addEventListener("transitionend",()=>{change_bg(body,"#6E5653");});  // on transition end we want to back to previous color
            
        }
        else  // this means that we introduced unproper data
        {
            change_bg(body,"#ff4d4d");
            body.addEventListener("transitionend",()=>{change_bg(body,"#6E5653");});  // on transition end we want to back to previous color

        }

    }


);


function next_input()
{
    wherearewe++;


    var all_circles = document.querySelectorAll(".c");


    switch (wherearewe)
    {
        case 2:
            
            all_circles[wherearewe-2].style.opacity = "0.5";
            all_circles[wherearewe-1].style.opacity = "1";

            var name_reg = document.querySelector('.reg_imie');
            var surname_reg = document.querySelector('.reg_nazwisko');

            surname_reg.style.animation = "fade-in 1s ease-in-out forwards";

            surname_reg.style.display = "block";
            name_reg.style.display = "none";

            

            break;
        
        case 3:

            all_circles[wherearewe-2].style.opacity = "0.5";
            all_circles[wherearewe-1].style.opacity = "1";

            var surname_reg = document.querySelector('.reg_nazwisko');
            var mail_reg = document.querySelector('.reg_mail');

            mail_reg.style.animation = "fade-in 1s ease-in-out forwards";  // we do not add event listener because we want only once this animtion

            mail_reg.style.display = "block";
            surname_reg.style.display = "none";

           
            break;

        case 4:

            all_circles[wherearewe-2].style.opacity = "0.5";
            all_circles[wherearewe-1].style.opacity = "1";

            
            var mail_reg = document.querySelector('.reg_mail');
            mail_reg.style.display = "none";

            var login_reg = document.querySelector('.reg_login');

            login_reg.style.animation = "fade-in 1s ease-in-out forwards";

            login_reg.style.display = "block";

            break;

        case 5: 

            all_circles[wherearewe-2].style.opacity = "0.5";
            all_circles[wherearewe-1].style.opacity = "1";

            var login_reg = document.querySelector('.reg_login');
            login_reg.style.display = "none";

            var password_reg = document.querySelector('.reg_haslo');

            password_reg.style.animation = "fade-in 1s ease-in-out forwards";

            password_reg.style.display = "block";

            var prompt = document.querySelector("#prompt");
            prompt.style.display="block";
            prompt.style.animation = "slide_right 0.75s ease-in-out";

            break;

        case 6:

            all_circles[wherearewe-2].style.opacity = "0.5";
            all_circles[wherearewe-1].style.opacity = "1";

            var prompt = document.querySelector("#prompt");
            prompt.style.animation = "slide_left 0.75s ease-in-out";
            prompt.addEventListener("animationend",()=>{prompt.style.display="none";})


            var password_reg = document.querySelector('.reg_haslo');
            password_reg.style.display = "none";

            var tel_reg = document.querySelector('.reg_tel');

           tel_reg.style.animation = "fade-in 1s ease-in-out forwards";

            tel_reg.style.display = "block";

            break;

        case 7:

            all_circles[wherearewe-2].style.opacity = "0.5";
            all_circles[wherearewe-1].style.opacity = "1";

            var tel_reg = document.querySelector('.reg_tel');
            tel_reg.style.display = "none";

            var checkbox_reg = document.querySelector('.regulamin_and_captcha');

            checkbox_reg.style.animation = "fade-in 1s ease-in-out forwards";

            checkbox_reg.style.display = "block";

            // change of buttons , we have finally button to submit our form and go with php

            var current_btn = document.querySelector(".next_btn");
            var submit_form_btn = document.querySelector(".submit_form")

            current_btn.style.display = "none";
            submit_form_btn.style.display = "block";

            break;



    }




}


function getCookie(name) {
    // Split cookie string and get all individual name=value pairs in an array
    var cookieArr = document.cookie.split(";");
    
    // Loop through the array elements
    for(var i = 0; i < cookieArr.length; i++) {
        var cookiePair = cookieArr[i].split("=");
        
        /* Removing whitespace at the beginning of the cookie name
        and compare it with the given string */
        if(name == cookiePair[0].trim()) {
            // Decode the cookie value and return
            return decodeURIComponent(cookiePair[1]);
        }
    }
    
    // Return null if not found
    return null;
}
