<?php 
    session_start();

    // if clients is logged yet then they will be transfered here

    if(isset($_SESSION['logged']) && $_SESSION['logged'])   // if we are logged yet we don t wanna log again until log out button
    {                                                           // first we generally checck if this variable exitst if not the conjunctive condition doesnt check the second so we do not get warning 
        header('Location: logged.php');
    }

?>


<!DOCTYPE html>
<html lang="pl">

<head>

    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>System logowania do systemu rezerwacji</title>

    <link rel="stylesheet" href="style.css" type="text/css">

</head>

<body>
    
    <main>
        <div class = "container">
            <div class = "window_log">
                
                    <div class="header_log"><h1>LOGOWANIE</h1></div>

                <form method="post" action="log.php">

                    <div class = "login">  <input type="text" placeholder="login lub email" name="login" class="text_login" value="<?php if(isset($_SESSION['loginInput'])){echo $_SESSION['loginInput'];unset($_SESSION['loginInput']);}?>"></div>
                    <div class = "password"> <input type="password" placeholder="hasło" name="pass" class="text_password"></div>
                    <div class = "button_submit"> <input type="submit" value="ZALOGUJ" name = "submit" class="submit_btn">  </div>

                    <?php

                        if(isset($_SESSION['error_log']))
                        {
                            echo "{$_SESSION['error_log']}";
                        }

                    ?>
                
                </form>
                
                <div class="registration">
                        <a href="registration.php" target="_blank" >Nie masz konta? Zarejestruj się za darmo!</a>
                        <br>
                        <!-- <a href="lostpass.php" target="_blank" >Zapomniałeś hasła?</a> -->
                </div>

            </div>
        </div>
    </main>

    <script src="script.js" type="text/javascript"></script>
</body>

</html>