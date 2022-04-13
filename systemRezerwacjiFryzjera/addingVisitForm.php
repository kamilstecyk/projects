<?php
    session_start();


    if(!isset($_SESSION['logged']) && !$_SESSION['logged'])   // if we are logged yet we don t wanna log again until log out button
    {                                                           // first we generally checck if this variable exitst if not the conjunctive condition doesnt check the second so we do not get warning 
        header('Location: log.php');
    }


    // handling form of adding visit by hairdresser


if(isset($_POST['addService2'])&& isset($_POST['adddateofservice']) && isset($_POST['addtimeofservice']) && $_POST['adddateofservice'] != "" &&   $_POST['addtimeofservice'] !=  "" &&  isset($_POST['submitVisit']) && isset($_POST['addPhone']) && $_POST['addPhone'] != "")
{

// now we have to check if pattern of inputs matches we do it in js before submit, it is essential

        // we stay at our page 

        

        //echo '<a href="admin.php">Nacisnij</a>';

        // functions we need

        $sanitized_date = htmlentities($_POST['adddateofservice'],ENT_QUOTES,"UTF-8");
        $sanitized_time = htmlentities($_POST['addtimeofservice'],ENT_QUOTES,"UTF-8");
        $sanitized_phone =  htmlentities($_POST['addPhone'],ENT_QUOTES,"UTF-8");

        function ParseDateToInts($time)
        {
            $timestamp = array();
            $temp = explode(":",$time);
            $timestamp[0] = intval($temp[0]);
            $timestamp[1] = intval($temp[1]);
            return $timestamp;
        }

        function buildHour($hour, $minutes)
        {
            $builder = "";
            if($hour < 10)
            {
                $builder .= 0;
                
            }
            $builder .= $hour;
            $builder .= ':';
            if($minutes < 10)
            {
                $builder .= 0;
            }
            $builder .= $minutes;
            $builder .= ":00";
            return $builder;
        }

        // code  / ----------- /


        $choosedIndex =  $_COOKIE['indexs'];

        // based on id's of our select 
        $timeOfServices = [
            0 => "0:30",
            1 => "1:00",
            2 => "1:30",
            3 => "3:00",
            4 => "0:30",
        ];


        // we connect to our database

        

        $startTime = $sanitized_time;
        
        $arrayOfStartTime = ParseDateToInts($startTime);
        $arrayOfService = ParseDateToInts($timeOfServices[$choosedIndex]);


        $endHour = $arrayOfStartTime[0] + $arrayOfService[0];
        $endMinutes = $arrayOfStartTime[1] + $arrayOfService[1];

        // adding hours if we have more minutes than 60
        for($endMinutes;$endMinutes>=60;$endMinutes-=60)
        {
            $endHour += 1;
        }


        $endTime = buildHour($endHour,$endMinutes);
        

        $newDate = date("Y-m-d", strtotime($sanitized_date));  

        // we are building timestamp for start time , we have to alsa change format of date to YYYY-MM-DD

        $timestampStart = $newDate . " " . $startTime . ":00";
    
        // we are building timestamp for end time


        $timestampEnd = $newDate . " " . $endTime;

        // we get rows with true when our input overlaps with database visits or NULL when we can add our wanted visit to db

        $ourQuery = "SELECT true AS response FROM wizyty w WHERE 
        w.koniecwizyty > '2022-02-17 16:00:00'
        AND
        w.poczwizyty < '2022-02-17 17:30:00';";
        

       
       

        // we check if we do not book visit in the past , it is senseless

        if(date('Y-m-d H:i:s',strtotime($timestampStart)) > date('Y-m-d H:i:s'))
        {

            

            $check_conn = require_once 'database.php';
           if(!$check_conn){exit();}  // we have to have connecton to do script , this is handler of connection


            
          


            $resultOS = $connection->query(sprintf("SELECT true AS response FROM wizyty w WHERE 
            w.koniecwizyty > '%s' AND w.poczwizyty < '%s'",mysqli_real_escape_string($connection,$timestampStart),mysqli_real_escape_string($connection,$timestampEnd)));

            //$resultOS = $connection->query("SELECT true AS response FROM wizyty w WHERE 
            //w.koniecwizyty > '$timestampStart' AND w.poczwizyty < '$timestampEnd'");






           

            
            if($resultOS)
            {
                $clientId = 0;


                $row = $resultOS->fetch_assoc(); // we get assosiactive table
                $howManyOverlapping = $resultOS->num_rows;

                $resultOS->free_result();


                
                

                if($howManyOverlapping == 0)  // we have null from results, we do not have overlapping deadline in db
                {
                    // we need client id, if we do not have such client we will be creating default account then client can create account and by his number account will be updated instead of duplicating

                    
                $resultUser = $connection->query(sprintf("SELECT u.id FROM uzytkownicy u WHERE u.telefon = '%s';",mysqli_real_escape_string($connection,$sanitized_phone)));

                    //$resultUser = $connection->query("SELECT u.id FROM uzytkownicy u WHERE u.telefon = '$sanitized_phone';");


                    

                    if($resultUser)
                    {

                        $rowUser = $resultUser->fetch_assoc();
                        $howManyUsers = $resultUser->num_rows;


                        if($howManyUsers != 0)  // we have sycha a user so we ccan take id
                        {
                            $clientId = $rowUser['id'];
                        
                        }
                        else   // we have to add anonymous user having only phone number
                        {
                            $resultAddingtoDB = $connection->query(sprintf("INSERT INTO uzytkownicy (telefon) VALUES ('%s');",mysqli_real_escape_string($connection,$sanitized_phone)));


                            
                            if($resultAddingtoDB) // success
                            {
                                $resultUser = $connection->query(sprintf("SELECT u.id FROM uzytkownicy u WHERE u.telefon = '%s';",mysqli_real_escape_string($connection,$sanitized_phone)));


                                
                                if($resultUser)
                                {
                                    $rowUser = $resultUser->fetch_assoc();
                                    $clientId = $rowUser['id'];

                                    

                                }
                                else
                                {
                                    echo 'SQL error';
                                }

                                $resultUser->free_result();

                            }
                            else{echo 'Inserting sql error';}

                            $resultAddingtoDB->free_result();

                        }
                        

                    }
                    else{
                        echo 'SQL failure';
                    }

                    

                    $addService = $_POST['addService2'];

                    // adding to DB our data

                    $resultI = $connection->query(sprintf("INSERT INTO wizyty (idklienta,poczwizyty,koniecwizyty,usluga) VALUES ('%s','%s','%s','%s')",mysqli_real_escape_string($connection,$clientId),mysqli_real_escape_string($connection,$timestampStart),mysqli_real_escape_string($connection,$timestampEnd),mysqli_real_escape_string($connection,$_POST['addService2'])));

                    /*$resultI=$connection->query("INSERT INTO wizyty (idklienta,poczwizyty,koniecwizyty,usluga) VALUES ('$clientId','$timestampStart','$timestampEnd','$addService');");  */         
                    

                    if(!$resultI)
                    {
                        echo 'Adding to DB by SQL ERROR';

                    }
                    else  // we have succes and we will be displaying info about it after refresh
                    {
                        $_SESSION['cannotAdd'] = false;
                    }


                    
                    
                    
                }
                else    // we have deadline overlapping in db
                {
                    $_SESSION['cannotAdd'] = true;
                }
                

            }
            else
            {
                echo 'Error of mysql';
                $resultOS->free_result();
            }
           

            $connection->close();

       }
          else
       {
            $_SESSION['bookPast'] = true;
       }

       

   
        
}

?>


<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style2.css" type="text/css">

    <title>Dodanie terminu do kalendarza</title>
</head>
<body>


    
<div class = "container3" id="3" style="height:100vh;">

<div class = "calendar">
    
    

    <div class = "proper_calendar" style="position:absolute;background-color:white;left:50%;top:50%;transform: translate(-50%,-50%);">
        
         <div id="backField" >
            <a href="admin.php" >
                <img src="return2.svg" width="50" height ="50" style="margin-left:5px;filter:invert(100%);">
                Powróć
            </a>
        </div>
                            
        <div style="display:flex;flex-direction:column;width:100%;justify-content: space-evenly;height:100%;align-items:center;align-items:center;" id="responseBox">

            
            <div id="text" style="text-align:center;font-size:24px;max-width: 60%;padding-top:4%;">

            <?php if(isset($_SESSION['cannotAdd']) && $_SESSION['cannotAdd'] == true)
                                {

                                        echo 'Niestety, nie mozesz dodac tego terminu, poniewaz nachodzi on na jeden z tych, który znajduje ju się w bazie!';
                           


                                }
                                else if(isset($_SESSION['bookPast']))
                                {
                                    echo 'Nie mozesz zarezerwowac wizyty w przeszlosci!';
                                    unset($_SESSION['bookPast']);

                                }
                                else
                                {
                                    echo 'Gratulacje, dodano pomyślnie wizytę!';
                                }
                             ?>
        
            </div>

            <div>
                <?php 
                   
                    
                     if((isset($_SESSION['cannotAdd']) && $_SESSION['cannotAdd'] == true )|| isset($_SESSION['bookPast'])) // success image
                     {
                        echo '<img src="insertFailure.svg" alt="Successful insertion">';
                        unset($_SESSION['cannotAdd']);   // here we can unset for future

                     }
                     else{
                        echo '<img src="successInsert.svg" alt="Unsuccessful insertion">';
                        unset($_SESSION['cannotAdd']);   // here we can unset for future

                     }

                ?>
            </div>


                          
        </div>

        
        
        
    </div>


                    
</div>

</div>

</section>


    
</body>
</html>