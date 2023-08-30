<?php

    session_start();

    // in case somebody write the url directly and did not register account
    if(!isset($_SESSION['proper_reg']))
    {
        header('Location: registration.php');
        exit();
    }
    else
    {
        unset($_SESSION['proper_reg']);
    }



?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dziękujemy za rejstrację!</title>

    <link rel="stylesheet" href="style.css" type="text/css">

</head>
<body>
    
    <div class="container_reg" style = "text-align: center;">

        <h1 style="padding: 50px;"> Serdecznie dziękujemy ci za zarejstrowanie u nas konta! </h1> </br>

        <div class = "desc_success">

            <h3 style="margin: 25px;"> Od teraz możesz w pełni z niego korzystać. Serdecznie zapraszamy. </h3> </br>

            <a href="index.php" style="display:block;margin: 50px;color:blue;"> Naciśnij link, aby zalogować się na swoje nowe konto </a>

        </div>

        <img src="thanks.svg" alt="Thank you user" style="width: 40%;height: 40%;margin-top: 30px;"></img>

    </div>

</body>
</html>