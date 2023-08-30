<?php
    session_start();


    if(!isset($_SESSION['logged']) && !$_SESSION['logged'])   // if we are logged yet we don t wanna log again until log out button
    {                                                           // first we generally checck if this variable exitst if not the conjunctive condition doesnt check the second so we do not get warning 
        header('Location: log.php');
    }
    

    if(isset($_SESSION['adminLogged'])){    

        $check_conn = require_once 'database.php';
        if(!$check_conn){exit();}  // we have to have connecton to do script , this is handler of connection
        
        $beginningTimeStamp = date('Y-m-d H:i:s',strtotime($_COOKIE['timestamp1ToDelete']));
        $endingTimeStamp = date('Y-m-d H:i:s',strtotime($_COOKIE['timestamp2ToDelete']));

        echo $beginningTimeStamp . " " . $endingTimeStamp;

        $result = $connection->query("DELETE FROM wizyty WHERE poczwizyty = '$beginningTimeStamp' AND koniecwizyty='$endingTimeStamp';");

        echo '<div style="background-color:blue;font-size:30px;">hellllllo' .$result . '</div>';

        if(!$result)
        {
            echo 'SQL error';
        }

       
        $connection->close();
    }


    header('Location: admin.php#2');


?>