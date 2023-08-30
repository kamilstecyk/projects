<?php
    session_start();

    if(!isset($_SESSION['logged']) && !$_SESSION['logged'])   // if we are logged yet we don t wanna log again until log out button
    {                                                           // first we generally checck if this variable exitst if not the conjunctive condition doesnt check the second so we do not get warning 
        header('Location: log.php');
    }


?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Panel klienta
    </title>

    <link rel="stylesheet" href="style2.css" type="text/css">

</head>
<body>
    
    


    <section>
        <div class = "container1">
                <header>

                    <div class="welcome_user">Witaj <?php echo $_SESSION['Name_of_logged'];?> ! <img src="hand.svg" width="60" height ="60"></div>
                        
                    <nav>
                        <div class="desc_"><a href="#1">Jak używać? &nbsp; <img class ="desc_icon" src="help.svg" width="46" height ="46"> </a></div>
                        <div class="book"><a href="#2">Zarezerwuj termin <img class ="book_icon" src="book.svg" width="46" height ="46"> </a> </div>
                        <div class="pipe"></div>
                        <div class="history"><a href="#3">Historia<img class ="book_icon" src="history.svg" width="46" height ="46"></a> </div>
                        <div class="logout"><a href="logout.php">Wyloguj <img class="logout_icon" src="logout.svg" width="46" height ="46"> </a> </div>

                    </nav>

                </header>
                <div class="container_jpg">
                    <img src="hairdresser.jpg">
                </div>
        </div>
    </section>

    
    <section>

        <div class = "container2" id="1" style="height:100vh;">

            <p class ="desc" style="text-align: center;">
               
                    Szanowny kliencie!  <br>

                    Aby skorzystać z naszych usług:  <br>

                    1.	 Przejdź do sekcji kalendarz widocznej poniżej.  <br>
                    2.	Wybierz interesujący Cię dzień świadczenia usługi. <br>
                    3.	Zaznacz usługę z listy oferowanych zabiegów. <br>
                    4.	Wybierz dogodną godzinę z bazy dostępnych terminów   <br>
                    5.   Pamiętaj, aby zarezerwować wizytę najpóźniej dzień przed
                    oczekiwaną wizytą. W naszym salonie nie ma możliwości rezerwacji wizyty
                    w tym samym dniu z racji tego, ze fryzjer musi sobie rozplanować dzień. <br>
                    6.	Przyjdź do naszego salonu i ciesz się nową fryzurą!   <br>

                    Zapraszamy codziennie od poniedziałku do piątku w godzinach 8-19!  <br>

                    Czekamy na ciebie  <br>
                    Zespół Salonu Fryzjerskiego

            </p>

        </div>


    </section>



    <section>

        <div class = "container3" id="2" style="height:100vh;">

            <div class = "calendar" >
                <div class ="todays_day">
                    <div id ="cal_today" style="color:white;"> 7 LUTY 2015 </div>
                </div>  
        
                <div class = "change_months">
                    <div class="change_m">
                            <div  id="change_month_left"><img src="left.svg"  width="46" height ="46"></div> &nbsp; <div id="m"> LUTY </div> &nbsp; 
                            <div class="change_month_right"  style="filter: invert(1);"><img src="right.svg"  width="46" height ="46"></div>
                    </div>
                    <div class = "display_year">
                            2015
                    </div>

                </div>


                <div class = "proper_calendar" style="<?php if(isset($_SESSION['displayDeadlines']) && $_SESSION['displayDeadlines'] == true){echo 'display:none !important;';} ?>">
                    <div class="white_line">
                        <div class = "week_days">
                                <div>ND</div> <div>PON</div> <div>WT</div> <div>ŚR</div> <div>CZW</div> <div>PT</div> <div>SOB</div>
                        </div>
                    </div>
                    
                    <div class="days">

                                <div class="prev-date">26</div><div class="prev-date">27</div><div class="prev-date">28</div><div class="prev-date">29</div><div class="prev-date">30</div>

                                <div>1</div> <div>2</div> <div>3</div> <div>4</div> <div>5</div> <div>6</div> <div>7</div>
                                <div> 8</div> <div>9</div> <div>10</div> <div>11</div> <div>12</div> <div>13</div> <div>14</div>
                                <div> 15  </div> <div> 16  </div> <div> 17 </div> <div> 18  </div> <div> 19  </div> <div> 20  </div> <div> 21  </div>
                                <div> 22  </div> <div class="td"> 23  </div> <div> 24  </div> <div> 25  </div> <div> 26  </div> <div> 27  </div> <div> 28  </div><div>29</div><div>30</div><div>31</div>

                                <div class="next-date">1</div>
                                <div class="next-date">2</div>
                                <div class="next-date">3</div>
                                <div class="next-date">4</div>
                                <div class="next-date">5</div>
                                <div class="next-date">6</div>
                        
                    </div>
                    
                </div>

                <!-- here we will have our choosed day window -->
                <form action="choosed_time.php" method="POST">

                <div class = "choosed_day" style="<?php if(isset($_SESSION['displayDeadlines'])&& $_SESSION['displayDeadlines'] == true){echo 'display:block !important';unset($_SESSION['displayDeadlines']);} ?>">
                    
                    <div class ="todays_day">
                        
                        <div id ="time_today" style="color:white;"> 
                                
                                 <!-- displaying day is that which the cliend chose !-->
                            <?php if(isset($_COOKIE['day']) &&  isset($_COOKIE['month']) && isset($_COOKIE['year']))
                            {
                                echo $_COOKIE['day'] . " " . $_COOKIE['polishMonth'] . " " . $_COOKIE['year'];
                            }  ?>

                        </div>
                        
                        <div id = "return_btn" style="cursor:pointer;">
                            <img src="back_cal.svg"  width="46" height ="46"> 
                        </div>
                        
                    </div>  


                    <div class = "choose_time">
                        

                            <label id="selectService" style="font-size:20px;padding-right: 15px;">Wybierz usługę: </label>
                            <select name="selectService" id="selectService">  
                                    <option value="Strzyzenie męskie">Strzyzenie męskie</option>
                                    <option value="Strzyzenie damskie">Strzyzenie damskie</option>
                                    <option value="Farbowanie">Farbowanie</option>
                                    <option value="Balejaz">Balejaz</option>
                                    <option value="Stylizacja">Stylizacja</option>
                                </select>
                                <input id='submitField' type="submit" name="submitField" value="Wyszukaj terminów">

                    </div>

                    <div class = "proper_time">

                        <div class = "header_ct">
                            
                            ZNALEZIONE WOLNE TERMINY

                        </div>


                        <div class = "found_time">  <!--  here we will be show available time of visit -->
                        
                            <!-- this form will generate as many deadlines of choosed service as possible -->

                            <?php                    
                            if(isset($_SESSION['display'])){

                                    $check_connection = require_once 'database.php';  // we get true or false


                                    
                                    if(!$check_connection)  // there is an error
                                    {
                                        exit();  // we want to end at once, because noramlly firstly all script is intepreted and then the header function is done
                                    }
                                    
                        
                                                $timeOfServices = [
                                                    0 => "0:30",
                                                    1 => "1:00",
                                                    2 => "1:30",
                                                    3 => "3:00",
                                                    4 => "0:30",
                                                ];


                                                $choosedIndex = $_COOKIE['indexs'];
                                                


                                    $tableOfSplit = explode(":",$timeOfServices[$choosedIndex]);
                                


                                    $choosed_data =  $_COOKIE['year'] . "-" . $_COOKIE['month'] . "-" . $_COOKIE['day'] . " ";  

                                    $result = $connection->query("SELECT * FROM wizyty WHERE DATE(poczwizyty) = '$choosed_data' AND DATE(poczwizyty) > NOW() ORDER BY poczwizyty;");  // we sort deadlines from begginning to end
                                    $rows = $result->num_rows;


                                    // we have to handle displaying only deadlines from now , because it is senseless to book visits in the past

                                    if($rows == 0)   
                                    {
                                        if($choosedIndex == 0 || $choosedIndex == 4){  // case when time of service is 0,5 h
                                            $minutes = $tableOfSplit[1];
                                            $hours = $tableOfSplit[0];
                                            $beginningMinutes = 0;
                                            $endingMinutes = $minutes;
                                        

                                            for($b=8,$e=8;$e<=19;)
                                            {

                                                if($e == 19 && $endingMinutes > 0){break;}  // we cannot work after saloon ours of working
                                            
                                                if($beginningMinutes == 0 && $endingMinutes == 0){
                                                echo '<input type="submit" value="' . $b . ":" . "00" . " - " . $e . ":" . "00" . '" name ="submit">';}
                                                if($beginningMinutes == 0 && $endingMinutes != 0)
                                                {
                                                    echo '<input type="submit" value="'. $b . ":" . "00" . " - " . $e . ":" . $endingMinutes . '" name ="submit">';

                                                }
                                                if($beginningMinutes != 0 && $endingMinutes == 0)
                                                {
                                                    echo '<input type="submit" value="' . $b . ":" . $beginningMinutes . " - " . $e . ":" . "00" . '" name ="submit">';

                                                }

                                                if($beginningMinutes != 0 && $endingMinutes != 0){
                                                echo '<input type="submit" value="' . $b . ":" . $beginningMinutes . " - " . $e . ":" . $endingMinutes . '" name ="submit">';
                                                }

                                                if($e == 19 && $endingMinutes == 0){break;}   // we stop iterations, our saloon is closed
                                                
                                                $beginningMinutes += $minutes;
                                                $endingMinutes += $minutes;
                                                
                                                if($beginningMinutes >= 60)
                                                {
                                                    $beginningMinutes = 0;
                                                    ++$b;
                                                }
                                                if($endingMinutes >= 60)
                                                {
                                                    $endingMinutes = 0;
                                                    ++$e;
                                                }

                                            }
                                        }
                                        

                                        if($choosedIndex == 1)
                                        {

                                            $godzinarozpoczenia = 8;
                                            $min00 = "00";
                                            $min30 = "30";

                                            //STRZYZENIE DAMSKIE
                                            for ($i = 0; $i < 11; $i++) {
                                                echo '<input type="submit" value="'  . $godzinarozpoczenia . ":" . $min00 . " - " . ($godzinarozpoczenia + 1) . ":" . $min00 .  '" name ="submit">';
                                                $godzinarozpoczenia++;
                                                
                                            }
                                        }


                                        if($choosedIndex == 3)
                                        {
                                            $godzinarozpoczenia = 8;
                                            $min00 = "00";
                                            $min30 = "30";

                                            //BALEJAŻ
                                            for ($i = 0; $i < 4; $i++) {
                                                if($i==3){
                                                    echo '<input type="submit" value="' . $godzinarozpoczenia . ":" . $min00 . " - " . ($godzinarozpoczenia + 2) . ":" . $min00 . '" name ="submit">';
                                                    break;
                                                }
                                                echo '<input type="submit" value="' . $godzinarozpoczenia . ":" . $min00 . " - " . ($godzinarozpoczenia + 3) . ":" . $min00 . '" name ="submit">';
                                                $godzinarozpoczenia+=3;
                                            }
                                        }

                                        if($choosedIndex == 2)
                                        {
                                            $godzinarozpoczenia = 8;
                                            $min00 = "00";
                                            $min30 = "30";

                                            //FARBOWANIE
                                            for ($i = 0; $i < 7; $i++){
                                                if($i%2==0){
                                                    echo '<input type="submit" value="' . $godzinarozpoczenia . ":" . $min00 . "-" . ($godzinarozpoczenia + 1) . ":" . $min30 . '" name ="submit">';
                                                    continue;
                                                }
                                                echo '<input type="submit" value="' . $godzinarozpoczenia+1 . ":" . $min30 . "-" . ($godzinarozpoczenia + 3) . ":" . $min00 . '" name ="submit">';
                                                $godzinarozpoczenia+=3;
                                            }
                                        }
                            
                                    }

                                    if($rows > 0)  // this means that we have some deadlines in our db
                                    {
         
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


                                    function availableHours($openingHours,$closingHours,$startOfBarber,$endOfBarber,$duration) {
                                        
                                        $timeStampsDuration = ParseDateToInts($duration);
                                        $timeStampsOpen = ParseDateToInts($startOfBarber);
                                        $timeStampsClose = ParseDateToInts($endOfBarber);

                                        $currentTimestamp = $timeStampsOpen;
                                        $possibleMeetings = array();

                                        $openingHoursTimeStamps = array();
                                        $closingHoursTimeStamps = array();

                                        for($i = 0;$i<count($openingHours);++$i)
                                        {
                                            $tempTimeStamps = ParseDateToInts($openingHours[$i]);
                                            $openingHoursTimeStamps[$i] = $tempTimeStamps;
                                        }

                                        for($i = 0;$i<count($closingHours);++$i)
                                        {
                                            $tempTimeStamps = ParseDateToInts($closingHours[$i]);
                                            $closingHoursTimeStamps[$i] = $tempTimeStamps;
                                        }

                                        $pointer = 0;


                                        while(true)
                                        {

                                            $endHour = $currentTimestamp[0] + $timeStampsDuration[0];
                                            $endMinute = $currentTimestamp[1] + $timeStampsDuration[1];
                                            if($endMinute >= 60)
                                            {
                                                $endHour += 1;
                                                $endMinute -= 60;
                                            }
                                        
                                            
                                            if($pointer < count($openingHoursTimeStamps) && ($endHour > $openingHoursTimeStamps[$pointer][0] || ($endHour == $openingHoursTimeStamps[$pointer][0] && $endMinute > $openingHoursTimeStamps[$pointer][1])))
                                            {
                                                $currentTimestamp[0] = $closingHoursTimeStamps[$pointer][0];
                                                $currentTimestamp[1] = $closingHoursTimeStamps[$pointer][1];
                                                $pointer++;
                                            }
                                            else if($endHour > $timeStampsClose[0] || ($endHour == $timeStampsClose[0] && $endMinute > $timeStampsClose[1]))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                $temp = array();
                                                $temp[] = buildHour($currentTimestamp[0],$currentTimestamp[1]);
                                                $temp[] = buildHour($endHour,$endMinute);
                                                $possibleMeetings[] = $temp;
                                                $currentTimestamp[1] += 30;

                                                if($currentTimestamp[1] >= 60)
                                                {
                                                    $currentTimestamp[0] += 1;
                                                    $currentTimestamp[1] -= 60;

                                                }

                                            }




                                        }

                                        return $possibleMeetings;

                                    }


                                    
                                    
                                    $startOfBarber = "08:00:00";  // here we have open hour of saloon
                                    $endOfBarber = "19:00:00";   // here we have closing hour of saloon

                                    // this is example to check if it is working
                                    //$openingHours = ["09:30:00","12:00:00","14:00:00"];
                                    //$closingHours = ["10:00:00","12:30:00","15:30:00"];

                                    $openingHours = array();
                                    $closingHours = array();

                                    // we have to fill array of opening ours and closing hours from our database
                                    
                                    while($row = $result->fetch_assoc())   // we get the row from our database)
                                    {
                                        $tmpOpeningHour = date('H:i:s', strtotime($row['poczwizyty']));
                                        $tmpEndingHour = date('H:i:s', strtotime($row['koniecwizyty']));
                                        $openingHours[] = $tmpOpeningHour;
                                        $closingHours[] = $tmpEndingHour;


                                    }

                                
                                    $meetings = availableHours($openingHours,$closingHours,$startOfBarber,$endOfBarber,$timeOfServices[$choosedIndex]);
                                    
                                    for($i=0;$i<count($meetings);++$i)
                                    {
                                        $begginingHourProper = explode(':',$meetings[$i][0]);
                                        $endingHourProper = explode(':',$meetings[$i][1]);

                                        echo  '<input type="submit" value="' . $begginingHourProper[0] . ":" . $begginingHourProper[1] .  " - " . $endingHourProper[0] . ":" . $endingHourProper[1] . '" name="submit">';
                                    }
                                    

                                }
        
                            }                

            ?>

                        </div>

                    </div>

                </div>

                </form>


            </div>

        </div>

    </section>





    <section>

        <div class = "container3" id="3" >

            <div class = "calendar">
                <div class ="todays_day">
                    <div id ="cal_today" style="color:white;"> Historia ostatnio zarezerwowanych wizyt </div>
                </div>  

                <div class="allVisits">

                <!-- HERE we have script for displaying our reserved visits -->
                    
                <?php

                            $check_conn = require_once 'database.php';
                            if(!$check_conn){exit();}  // we have to have connecton to do script , this is handler of connection

                            $ourQuery = 'SELECT poczwizyty,usluga FROM wizyty WHERE idklienta = ' . $_SESSION['id'] . ' ORDER BY poczwizyty DESC LIMIT 6;';    // we limit our displaying visits to 6 becauose of style
                            $result = $connection->query($ourQuery);


                            $class1 = '<div class="clientsHistory">
                            <div class="dateOfVistit">'; // now we should write date
                            $class2 = '</div>
                            <div class="whichService">'; // now we should write service
                            $class3 = '</div>
                            </div>';

                            $listOfClasses = "";

                            if($result)  // querend is good
                            {
                                
                                $howManyRows = $result->num_rows;
                                if($howManyRows == 0)
                                {
                                    echo '<div style="width:50%;height:25%;display:flex;justify-content:center;align-items:center;background-color:#6E5653;color:white;font-size:20px;transform: translateY(50%);
                                    ">Nie zarezerwowałeś niestety zadnych wizyt w naszym salonie</div>';
                                }
                                else
                                {
                                    $row = $result->fetch_assoc();
                                    $poczwizyty = date('d-m-Y  H:i', strtotime($row['poczwizyty']));
                                    $usluga =  $row['usluga'];

                                    for($i=0;$i<$howManyRows;$i++)
                                   {
                                        $listOfClasses .= $class1 . $poczwizyty . $class2 . $usluga . $class3;
                                        $row = $result->fetch_assoc();   // we get another row with values
                                        $poczwizyty = date('d-m-Y  H:i', strtotime($row['poczwizyty'])); 
                                        $usluga =  $row['usluga'];
                                   }
                                    
                                   echo $listOfClasses;
                                }

                            }
                            else
                            {
                                echo 'Nieznany Błąd';
                            }

                            $result->free_result();


                    ?>

                </div>
            </div>

        </div>

    </section>


    <footer style ="background-color: #6E5653;text-align:right;padding:25px;color:white;font-size:16px;padding-right:70px;">
                        Wszelkie prawa zastrzeżone &copy;
    </footer>
   


    <script src="calendar.js" type ="text/javascript"></script>

    

</body>
</html>
