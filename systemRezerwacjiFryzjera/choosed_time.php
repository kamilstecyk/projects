<?php
    session_start();

    if(!isset($_SESSION['logged']) && !$_SESSION['logged'])   // if we are logged yet we don t wanna log again until log out button
    {                                                           // first we generally checck if this variable exitst if not the conjunctive condition doesnt check the second so we do not get warning 
        header('Location: log.php');
    }

    if(!isset($_POST['submit']))
    {
        header('Location: logged.php');
    }

?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Zarezerwowanie wizyty </title>

    <style>
        body{background: rgb(89,61,57);
    background: linear-gradient(180deg, rgba(89,61,57,1) 12%, rgba(255,255,255,1) 100%);color:white;}
            
    </style>
</head>



<?php

            
        if($_POST['submitField']){$_SESSION['displayDeadlines'] = true;$_SESSION['choosedService'] = $_POST['selectService'];$_SESSION['display']=true;}



        if (isset($_POST['submit'])) {  // this means that we sent data $_POST['submit'] have our choosed value of btn
            
            // here we want to connect with database and insert value , beacuse filtering information we had earlier, before oour choice

            $check_connection = require_once 'database.php';  // we get true or false

                if(!$check_connection)  // there is an error
                {
                    exit();  // we want to end at once, because noramlly firstly all script is intepreted and then the header function is done
                }
            
            $id_klienta = $_SESSION['id'];
            $timeOfVisit = $_POST['submit'];
            $tableOfHours = explode(' - ',$timeOfVisit);  // we divide into two hours
            $service = $_POST['selectService'];
            
            $choosed_data =  $_COOKIE['year'] . "-" . $_COOKIE['month'] . "-" . $_COOKIE['day'] . " ";  // instead of cookies we could use ajax in js
            $fullDataWithTimeBeginning = $choosed_data . $tableOfHours[0] . ":00";
            $fullDataWithTimeEnding = $choosed_data . $tableOfHours[1] . ":00";
           

            $result = $connection->query("INSERT INTO wizyty VALUES(NULL,$id_klienta,'$fullDataWithTimeBeginning','$fullDataWithTimeEnding','$service');");
            
            if(!$result)   // bad querend
                {   
                    $connection->close(); 
                    exit("Błąd kwerendy");
                }
                
            

           
        }
        
        
    ?>




<body>
   

        <div class="container_reg" style = "text-align: center;">

        <h1 style="padding: 50px;"> Serdecznie dziękujemy ci za zarezerwowanie wizyty u nas! </h1> </br>

        <div class = "desc_success">

            <h3 style="margin: 25px;"> Nie zapomnij nas odwiedzić w zarezerwowanym przez ciebie dniu. </h3> </br>

            <a href="logged.php" style="display:block;margin: 50px;color: blue;"> Naciśnij link, aby powrócić na stronę główną </a>
            <a href="logout.php" style="display:block;margin: 50px;color:blue;"> Naciśnij link, aby wylogować się ze swojego konta </a>

        </div>

        <img src="thanks.svg" alt="Thank you user" style="width: 40%;height: 40%;margin-top: 30px;"></img>

        </div>



</body>
</html>



