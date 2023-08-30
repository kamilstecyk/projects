<?php
    
    session_start();

    $everything_is_good = true;

    // we secure our scirpt in case somebody go straigh to this by url

    if(!isset($_POST['reg_name']) || !isset($_POST['reg_surname']) || !isset($_POST['reg_mail']) || !isset($_POST['reg_login']) || !isset($_POST['reg_pass']) || !isset($_POST['reg_tel'])/* || !isset($_POST['regulamin']) || !isset($_POST['submit'])*/)
    {
        // we stay on the site
    }

    else if(isset($_POST['reg_name']) && isset($_POST['reg_surname']) && isset($_POST['reg_mail']) && isset($_POST['reg_login']) && isset($_POST['reg_pass']) && isset($_POST['reg_tel']) && (!isset($_POST['regulamin']) || !isset($_POST['submit'])))
    { // we remember inputed data in case then it is fail
        $_SESSION['goodName'] = $_POST['reg_name'];
        $_SESSION['goodSurname'] = $_POST['reg_surname'];
        $_SESSION['goodMail'] = $_POST['reg_mail'];
        //$_SESSION['goodPass'] = $_POST['reg_pass'];  // maybe it is not good idea to fill password, better user should write again
        $_SESSION['goodLogin'] = $_POST['reg_login'];
        $_SESSION['goodTel'] = $_POST['reg_tel'];
        $_SESSION['message'] = "Nie zaakceptowałeś regulaminu!";
    }
    else{

                // we are creating variables which were inputed on form


                $name = $_POST['reg_name'];
                $surname = $_POST['reg_surname'];
                $mail = $_POST['reg_mail'];
                $login = $_POST['reg_login'];
                $password = $_POST['reg_pass'];
                $tel = $_POST['reg_tel'];
                $regulamin = $_POST['regulamin'];   // this is checkbox
                $submit = $_POST['submit'];
                


                // now we will be sanitizing data, earlier in js we validated , html entitis make only entites to html querend, it cannot be the source code

                
                $sanitized_name = htmlentities($name,ENT_QUOTES,"UTF-8");
                $sanitized_surname = htmlentities($surname,ENT_QUOTES,"UTF-8");  
                $sanitized_login = htmlentities($login,ENT_QUOTES,"UTF-8");
                $sanitized_password = htmlentities($password,ENT_QUOTES,"UTF-8");
                $sanitized_mail = htmlentities($mail,ENT_QUOTES,"UTF-8");
                $sanitized_tel = htmlentities($tel,ENT_QUOTES,"UTF-8");


                

                $response   = isset($_POST["g-recaptcha-response"]) ? $_POST['g-recaptcha-response'] : null;
                $privatekey = "6Ld-K4QcAAAAACBnIYV-F4d9fIQ-NceRbdUM06Ig";

                $ch = curl_init();
                curl_setopt($ch, CURLOPT_URL, "https://www.google.com/recaptcha/api/siteverify");
                curl_setopt($ch, CURLOPT_HEADER, 0);
                curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
                curl_setopt($ch, CURLOPT_POST, 1);
                curl_setopt($ch, CURLOPT_POSTFIELDS, array(
                    'secret' => $privatekey,
                    'response' => $response,
                    'remoteip' => $_SERVER['REMOTE_ADDR']
                ));

                $resp = json_decode(curl_exec($ch));
                curl_close($ch);


                // $answer->success == false
                if($resp->success == false)  // no success, bad verification by captcha
                {
                    $everything_is_good = false;

                    // this variables are useful for displaying in inputs  during registration again with recaptcha error
                    $_SESSION['goodName'] = $_POST['reg_name'];
                    $_SESSION['goodSurname'] = $_POST['reg_surname'];
                    $_SESSION['goodMail'] = $_POST['reg_mail'];
                    $_SESSION['goodLogin'] = $_POST['reg_login'];
                    $_SESSION['goodTel'] = $_POST['reg_tel'];

                    $_SESSION['message'] = " Musisz udowodnić, że nie jesteś robotem!";
   
                }


                // do rest of action only if we have everything good on the form including recaptcha

                if($everything_is_good){

                    // check if such a a user doesnt exists currently in db
                    
                        
                    $check_connection = require_once 'database.php';  // we get true or false

                    if(!$check_connection)  // there is an error
                    {
                        
                        exit();  // we want to end at once, because noramlly firstly all script is intepreted and then the header function is done
                    }

                    
                    // mail

                    $result1 = $connection->query("SELECT id FROM uzytkownicy WHERE mail='$sanitized_mail'");

                    if(!$result1)   // bad querend
                    {   
                        $everything_is_good = false;
                        $connection->close(); 
                        exit("Błąd kwerendy");
                    }
                    
                    $how_many_mails = $result1->num_rows;

                    if($how_many_mails > 0)
                    {
                        $everything_is_good = false;
                        // obsluga tego bledu
                    }

                    // login

                    $result2 = $connection->query("SELECT id FROM uzytkownicy WHERE login='$sanitized_login'");

                    if(!$result2)   // bad querend
                    {   
                        $everything_is_good = false;
                        $connection->close(); 
                        exit("Błąd kwerendy");
                    }
                    
                    $how_many_logins = $result2->num_rows;

                    if($how_many_logins > 0)
                    {
                        $everything_is_good = false;
                        // obsluga tego bledu
                    }

                    $result1->free_result();
                    $result2->free_result();

                    /////////////////////////


                    // hasing password with default algorithm of php

                    $pass_hash = password_hash($sanitized_password,PASSWORD_DEFAULT);

                    // if we have default default account because hairdresser book deadline then update columns in db, we can have only one phone number in db

                    $result3 = $connection->query("SELECT login FROM uzytkownicy WHERE telefon='$sanitized_tel';");
                    $howManyPhones = $result3->num_rows;

                    if(!$result3)
                    {
                        $everything_is_good = false;
                        $connection->close(); 
                        exit("Błąd kwerendy");

                    }


                    if($howManyPhones > 0)
                    {
                        $resultRow = $result3->fetch_assoc();
                        if($howManyPhones == 1 && $resultRow['login']=='nieznanylogin')  // we can update data oin db
                        {

                            $result4 = $connection->query("UPDATE uzytkownicy SET imie='$sanitized_name',nazwisko='$sanitized_surname',login='$sanitized_login',haslo='$pass_hash',mail='$sanitized_mail' WHERE telefon='$sanitized_tel' AND login = 'nieznanylogin';");  // update data in db
                            
                            if(!$result4)
                            {
                                $everything_is_good = false;
                                $connection->close(); 
                                exit("Błąd kwerendy");
                            }
                            else
                            {
                                $_SESSION['proper_reg'] = true;
                                header('Location: success_reg.php');
                            }
                            
                        }
                        else
                        {
                            $everything_is_good = false;
                            $_SESSION['message'] = "Niestety juz posiadasz konto w naszym serwisie!";
                            // echo '<script>window.alert("Posiadasz juz konto w naszym serwisie!")</script>';
                        }


                    }
                    else{


                        if($everything_is_good)   // main task of our registration
                        {
                        // validation is proper and we can insert into db
                            
                            $result3 = $connection->query("INSERT INTO uzytkownicy VALUES (NULL,'$sanitized_name','$sanitized_surname','$sanitized_login','$pass_hash','$sanitized_mail','$sanitized_tel');");
                            
                            if($result3) // proper querend
                            {
                                $_SESSION['proper_reg'] = true;
                                header('Location: success_reg.php');
                                
                            }
                            else
                            {   
                                
                                $connection->close();
                                exit("Unfortunately, there are some problems.. try later");
                            }

                        }
                    }
                    $connection->close();    // we close connection at the end
                }
        }
?>



<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Panel rezerwacji</title>

    <link rel="stylesheet" href="style.css" type="text/css">

    <script src="https://www.google.com/recaptcha/api.js" async defer></script>

    


</head>
<body>
    
<section>
    <div container_reg>
    <header>
        <div class="reg_header">
            <h1> Zarejestruj się już teraz!  </h1>
        </div>
    </header>
        
   

        <div id="prompt"  ><h3><?php echo 'Hasło powinno zawierać od 6-16 liczb,liter,znaków, przy czym wymagana jest minimum jedna z nich, a w dodatku mała i wielka litera';?></h3></div>

        <div id="prompt2" <?php if(isset($_SESSION['message'])){echo 'style="display:block!important;animation:Longslide_left 3s ease-in-out forwards;"';}?>> 
        <?php if(isset($_SESSION['message'])){echo $_SESSION['message'];unset($_SESSION['message']);}  ?>
        </div>
        

    <main>
        <form method="post" >  <!--form will be handled by this site -->
            <div class = "reg_imie"><input type="text" name="reg_name" placeholder="imię" id='reg_n' value="<?php 
                if(isset($_SESSION['goodName']))
                {
                    echo $_SESSION['goodName'];
                    unset($_SESSION['goodName']);
                }
            ?>"></div>
            <div class = "reg_nazwisko"><input type="text" name="reg_surname" placeholder="nazwisko" id='reg_sur' value="<?php 
                if(isset($_SESSION['goodSurname']))
                {
                    echo $_SESSION['goodSurname'];
                    unset($_SESSION['goodSurname']);
                }
            ?>"></div>
            <div class = "reg_mail"><input type="email" name="reg_mail" id='reg_m' placeholder="mail" value="<?php 
                if(isset($_SESSION['goodMail']))
                {
                    echo $_SESSION['goodMail'];
                    unset($_SESSION['goodMail']);
                }
            ?>"></div>
            <div class = "reg_login"><input type="text" name="reg_login" id='reg_l' placeholder="login" value="<?php 
                if(isset($_SESSION['goodLogin']))
                {
                    echo $_SESSION['goodLogin'];
                    unset($_SESSION['goodLogin']);
                }
            ?>"></div>
            <div class = "reg_haslo"><input type="password" name="reg_pass" id='reg_p' placeholder="haslo" ></div>
            <div class = "reg_tel"><input type="text" name="reg_tel" id='reg_t' placeholder="telefon" value="<?php 
                if(isset($_SESSION['goodTel']))
                {
                    echo $_SESSION['goodTel'];
                    unset($_SESSION['goodTel']);
                }
            ?>"></div>
            <div class = "regulamin_and_captcha">
                
                <label class="desc_checkbox"><input type="checkbox" name="regulamin" id="reg_checkbox">Akceptuję regulamin</label>
                <div id="recaptcha" class="g-recaptcha" data-sitekey="6Ld-K4QcAAAAAMg_wVnqalZdexGj7bw5AboyrAc2"></div>

            </div>
            <div class = "next_btn"><button id="reg_submit"><img src="arrow_right.svg" alt="arrow-right"></img></button></div>
            <div class="submit_form"><input type="submit" name="submit" value="Zarejestruj!" id="submit_form_btn"></div>
        </form>
    </main>

        <div class = "circles">
            
            <div class="c1 c"></div>
            <div class="c2 c"></div>
            <div class="c3 c"></div>
            <div class="c4 c"></div>
            <div class="c5 c"></div>
            <div class="c6 c"></div>
            <div class ="c7 c"></div>

        </div>

    </div>
<section>

    <script src="script.js" type ="text/javascript"></script>

</body>
</html>