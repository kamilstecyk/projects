<?php
    session_start();
    $_SESSION['loadedDeadlines'] = false;
    $_SESSION['inputCompleted'] = false;
   
    

    if(!isset($_SESSION['logged']) && !$_SESSION['logged'])   // if we are logged yet we don t wanna log again until log out button
    {                                                           // first we generally checck if this variable exitst if not the conjunctive condition doesnt check the second so we do not get warning 
        header('Location: log.php');
    }

    $_SESSION['adminLogged'] = true;
    

    if(!isset($_SESSION['whichDay']) )   // normally we want to display todays day
    {
        $_SESSION['whichDay'] = 0;
        $_SESSION['dateToDisplay'] = date('d-m-Y');
        $date = $_SESSION['dateToDisplay'];
        $_SESSION['date'] = $date;
        $_SESSION['iter'] = false;
    }
    
        

    // $_SESSION['date'] to zmienna przechowujaca stala date, na ktorej wykonujemy operacje dodawania dni i odejmowania, $_SESSION['dateToDisplay'] to własciwa data do wyswietlenia

    if(isset($_POST['submitDateBtn']) && isset($_POST['chooseDate']) && $_POST['chooseDate'] != '')
    {
        $inputDate = $_POST['chooseDate'];
        if(preg_match("/\d\d-\d\d-\d\d\d\d/",$inputDate))  // zwraca 0 lub 1 
        {
            $_SESSION['dateToDisplay'] = date('d-m-Y', strtotime($inputDate));
            $date = date('d-m-Y', strtotime($inputDate));
            $_SESSION['date'] = $date;
            $_SESSION['whichDay'] = 0;  // we set default setttings
            $_SESSION['iter'] = false;
        }
    }



    if(isset($_POST['right_arrow_x']) &&  isset($_POST['right_arrow_y']))
        {
            $_SESSION['loadedDeadlines'] = false;
            $_SESSION['whichDay']++;
            $_SESSION['iter'] = true;
           
        }
        else if(isset($_POST['left_arrow_x']) && isset($_POST['left_arrow_y']) ){
            $_SESSION['loadedDeadlines'] = false;
            $_SESSION['whichDay']--;
            $_SESSION['iter'] = true;
        }



        if($_SESSION['iter'])
        {

            if($_SESSION['whichDay'] >= 0)
                $_SESSION['dateToDisplay'] = date('d-m-Y', strtotime($_SESSION['date']. ' + '. $_SESSION['whichDay'] . ' days'));
            
            else
            {
                $_SESSION['dateToDisplay'] = date('d-m-Y', strtotime($_SESSION['date']. $_SESSION['whichDay'] . ' days'));  // we  perform subtraction beacuse which day is negative

            }
        }



        if(isset($_POST['submitDateBtn']) && isset($_POST['chooseDate'])  && $_POST['chooseDate'] != '')
        {
            $_SESSION['loadedDeadlines'] = true;
            $_SESSION['inputCompleted'] = true;  // mamy przeslany input

        }
        else{
            $_SESSION['inputCompleted'] = false;
            $_SESSION['loadedDEadlines'] = false;
        }
        

    


        



?>


<!DOCTYPE html>
<html lang="pl">
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
                        <div class="book"><a href="#2">Wizyty na dziś <img class ="book_icon" src="book.svg" width="46" height ="46"> </a> </div>
                        <div class="pipe"></div>
                        <div class="desc_"><a href="#3">Dodaj wizytę &nbsp; <img class ="desc_icon" src="addvisit.svg" width="46" height ="46"> </a></div>
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

            <p class ="desc">
                                
                    Szanowny fryzjerze!  <br>

                    Aby skorzystać z naszych usług:  <br>

                    1.	 Przejdź do sekcji kalendarz widocznej poniżej.  <br>
                    2.	Wpisz interesujący Cię dzień wizyt twoich klientów lub poruszaj się od razu strzałkami. Domyślnie ustawiony jest obecny dzień. <br>



            </p>

        </div>


    </section>



    <section>
        

        <div class = "container3" id="2" style="height:100vh;">

            <div class = "calendar">
                <div class ="todays_day" style="postion:relative;">

                    <div class = "change_months">    <!-- we change days instead of months, but the logic is the same of program -->
                        <form action="" method="POST">
                            <div class="change_m" style="padding-top:25px;">
                                   
                                        <input type="image" name="left_arrow" id="ch_m_l" src="left.svg" width="46" height ="46">
                                        <div id="m">
                                            <?php 
        echo $_SESSION['dateToDisplay'];
        if($_SESSION['dateToDisplay'] ==  date("d-m-Y")){echo " (Dziś)";}
        
        ?>
                                        </div> &nbsp; 
                                        <input type="image" name="right_arrow"  id="ch_m_r" src="right.svg" width="46" height ="46">
                                        
                                        <div id="dateChodeField">
                                            <input type="text" id="chooseDate" name="chooseDate" placeholder="Wyszukaj (dzień-mies-rok)">
                                            <input type="submit" value="WYSZUKAJ" id="submitDate" name="submitDateBtn">
                                        </div>
                            </div>
                        </form>
                    </div>

                </div>  
        
                

                <div class = "proper_calendar" style="background-color:white;">
                    <div class = "deadlines">

                        <?php
                            

                            if($_SESSION['loadedDeadlines'] == false)
                            {
                                
                                $_SESSION['loadedDeadlines'] = true;
                                $check_conn = require_once 'database.php';
                                if(!$check_conn){exit();}  // we have to have connecton to do script , this is handler of connection
                                
                                $dateForQuery = date('Y-m-d', strtotime($_SESSION['dateToDisplay']));
                                $ourQuery = 'SELECT w.poczwizyty,w.koniecwizyty,w.usluga,u.telefon FROM uzytkownicy u INNER JOIN wizyty w ON (u.id = w.idklienta) WHERE date(w.poczwizyty) = ' . '"' . $dateForQuery . '"ORDER BY w.poczwizyty;';
                                $result = $connection->query($ourQuery);
                                

                                // deadline class

                                $deadlineClass1 = '<div class = "deadline">
                                <div class = "deadlineTime">';   // we should give here time of visit
                                $deadlineClass2 = '</div>
                                <div class = "deadlineDetails" >
                                    <div class = "whichService">'; // we should give here which service is pergorned
                                
                                $deadlineClass3 = '</div>
                                    <div class = "phoneNumber">'; // we should give here phone number
                                $deadlineClass4 = '</div>

                                </div>
                                <div id="afterDesc" class="afterImg">
                                    <form method="POST" action="deleteVisit.php" style="padding-right:4px;">
                                        <button name="deleteVisitbtn" type="submit"><img src="remove.svg" class="removeImg" width="36" height ="36" ></button>
                                    </form>
                                </div>
                            </div>';  // this is end of our classes

                                
                                $listOfClasses = "";
                                $howManyRows = $result->num_rows;
                                if($result && $howManyRows > 0)   # querend is good
                                { 

                                    $row = $result->fetch_assoc();
                                    $poczwizyty = date('H:i', strtotime($row['poczwizyty']));  // we cant get values from row by row[0] for example ! 
                                    $koniecwizyty = date('H:i', strtotime($row['koniecwizyty']));
                                    $usluga =  $row['usluga'];
                                    $telefon = $row['telefon'];

                                   for($i=0;$i<$howManyRows;$i++)
                                   {
                                        $listOfClasses .= $deadlineClass1 . $poczwizyty . '-' . $koniecwizyty . $deadlineClass2 . $usluga . $deadlineClass3 . $telefon . $deadlineClass4;
                                        $row = $result->fetch_assoc();   // we get another row with values
                                        $poczwizyty = date('H:i', strtotime($row['poczwizyty'])); 
                                        $koniecwizyty = date('H:i', strtotime($row['koniecwizyty']));
                                        $usluga =  $row['usluga'];
                                        $telefon = $row['telefon'];
                                   }

                                   echo $listOfClasses;
                                    
                                }
                                else if($result && $howManyRows == 0){echo '<div id="noDeadlines" style="background-color: #2B2221;min-width:45%;min-height:200px;color:white;font-size:20px;display:flex;justify-content:center;align-items:center;margin-left:auto;margin-right:auto;">
                                    Brak wizyt na ten dzień
                        </div>';}
                                else
                                {
                                    echo 'blad';
                                }

                                $result->free_result();
                                $connection->close();
                            }
                            
                            else if(isset($_POST['submitDateBtn']) && isset($_POST['chooseDate']) && $_POST['chooseDate'] != '')
                            {
                                
                                $inputDate = $_POST['chooseDate'];
                                if(preg_match("/\d\d-\d\d-\d\d\d\d/",$inputDate))  // return 0 or 1 
                                {
                                    $check_conn = require_once 'database.php';
                                    if(!$check_conn){exit();}  // we have to have connecton to do script , this is handler of connection

                                    $_SESSION['dateToDisplay'] = date('d-m-Y', strtotime($inputDate));
                                    $date = date('d-m-Y', strtotime($inputDate));
                                    
                                    $_SESSION['loadedDeadlines'] = true;
                                    $_SESSION['inputCompleted'] = true;

                                    $dateForQuery = date('Y-m-d', strtotime($date));


                                    $ourQuery = 'SELECT w.poczwizyty,w.koniecwizyty,w.usluga,u.telefon FROM uzytkownicy u INNER JOIN wizyty w ON (u.id = w.idklienta) WHERE date(w.poczwizyty) = ' . '"' . $dateForQuery . '";';
                                    $result = $connection->query($ourQuery);

                                    // displaying visits

                                    // deadline class

                                    $deadlineClass1 = '<div class = "deadline">
                                    <div class = "deadlineTime">';   // we should give here time of visit
                                    $deadlineClass2 = '</div>
                                    <div class = "deadlineDetails">
                                        <div class = "whichService">'; // we should give here which service is performed
                                    
                                    $deadlineClass3 = '</div>
                                        <div class = "phoneNumber">'; // we should give here phone number
                                    $deadlineClass4 = '</div>
                                    </div>
                                    </div>';  // this is end of our classes

                                    
                                    $listOfClasses = "";
                                    $howManyRows = $result->num_rows;

                                    if($result && $howManyRows > 0)   # querend is good
                                    { 

                                        $row = $result->fetch_assoc();
                                        $poczwizyty = date('H:i', strtotime($row['poczwizyty']));  // we cant get values from row by row[0] for example ! 
                                        $koniecwizyty = date('H:i', strtotime($row['koniecwizyty']));
                                        $usluga =  $row['usluga'];
                                        $telefon = $row['telefon'];

                                    for($i=0;$i<$howManyRows;$i++)
                                    {
                                            $listOfClasses .= $deadlineClass1 . $poczwizyty . '-' . $koniecwizyty . $deadlineClass2 . $usluga . $deadlineClass3 . $telefon . $deadlineClass4;
                                            $row = $result->fetch_assoc();   // we get another row with values
                                            $poczwizyty = date('H:i', strtotime($row['poczwizyty'])); 
                                            $koniecwizyty = date('H:i', strtotime($row['koniecwizyty']));
                                            $usluga =  $row['usluga'];
                                            $telefon = $row['telefon'];
                                    }

                                    echo $listOfClasses;
                                        
                                    }
                                    else if($result && $howManyRows == 0){echo '<div id="noDeadlines" style="background-color: #2B2221;min-width:45%;min-height:200px;color:white;font-size:20px;display:flex;justify-content:center;align-items:center;margin-left:auto;margin-right:auto;">
                                        Brak wizyt na ten dzień
                                    </div>';}
                                    else
                                    {
                                        echo 'blad';
                                    }

                                    $result->free_result();
                                    
                                    $connection->close();
                                }
                                else
                                {
                                    echo '<div id="noDeadlines" style="background-color: #2B2221;min-width:45%;min-height:200px;color:white;font-size:20px;display:flex;justify-content:center;align-items:center;margin-left:auto;margin-right:auto;">
                                        Niepoprawna data
                                    </div>';
                                }
                            }
                            
                           

                        ?>
                    

                    </div>
                </div>




            </div>

        </div>
        
    </section>


<form method="post" action="addingVisitForm.php">

<div class = "container3" id="3" style="height:100vh;">

<div class = "calendar">
    <div class ="todays_day" style="postion:relative;">

            <h2 style="font-size: 28px;letter-spacing:5px;font-weight: 400;">DODAJ WIZYTĘ KLIENTA</h2>

    </div>  

    

    <div class = "proper_calendar" style="background-color:white;">
        
                            
        <div style="display:flex;flex-direction:column;width:100%;justify-content: space-evenly;height:100%;align-items:center;">




                <div id="addResponse">  
                        <div id="addResponseText">
                                <?php if(isset($_SESSION['cannotAdd']))
                                {
                                    if($_SESSION['cannotAdd'] == false)
                                    {
                                        echo 'Dodano pomyślnie wizytę!';
                                    }
                                    else
                                    {
                                        echo 'Nie mozesz dodac tego terminu!';
                                    }

                                    unset($_SESSION['cannotAdd']);

                                }
                                else if(isset($_SESSION['bookPast']))
                                {
                                    echo 'Nie mozesz zarezerwowac wizyty w przeszlosci';
                                    unset($_SESSION['bookPast']);

                                }
                             ?>
                        </div>
                        <img src="info.svg" width="36" height ="36" style="margin-left:5px;filter: invert(100%);">

                 </div>
                
               


                <!--<input type="text" class = "addInputs" name = "addingservice" placeholder="Rodzaj usługi" id="addservice">-->
                <div id="frameForSelect">
                <label id="addService" style="font-size:20px;padding-right: 15px;">Wybierz usługę: </label>
                            <select name="addService2" id="addService">  
                                    <option value="Strzyzenie męskie">Strzyzenie męskie</option>
                                    <option value="Strzyzenie damskie">Strzyzenie damskie</option>
                                    <option value="Farbowanie">Farbowanie</option>
                                    <option value="Balejaz">Balejaz</option>
                                    <option value="Stylizacja">Stylizacja</option>
                                </select>
                </div>
                <input type="text" class = "addInputs"  name = "adddateofservice" placeholder="Data usługi ( DD-MM-YYYY )" id="dateservice">
                <input type="text" class = "addInputs"  name = "addtimeofservice" placeholder="Godzina rozpoczęcia usługi ( HH:MM )" id="timeofservice">
                <input type="text" class = "addInputs"  name = "addPhone" placeholder="Numer telefonu klienta (xxx xxx xxx)" id="addPhoneInput">
                
                <input type="submit" name="submitVisit" value="DODAJ" id="submitVisitBtn">
                

        </div>
        
        
    </div>

    
    <?php if(isset($_POST['submitVisit'])){
                    
                    echo '<script> var responseDiv = document.querySelector("#addResponse");
                    responseDiv.style.display="block";
                    responseDiv.style.animation="fade_in 0.75s ease-in-out forwards";
                    setTimeout(()=>{responseDiv.style.animation="fade_out 0.75s ease-in-out forwards";},2500);
                    setTimeout(()=>{responseDiv.style.display="none"},3000);
                    </script>';

                }?>



</div>

</div>

</section>

</form>


    <footer style ="background-color: #6E5653;text-align:right;padding:25px;color:white;font-size:16px;padding-right:70px;">
                        Wszelkie prawa zastrzeżone &copy;
    </footer>

   



    <script src="handleIndexOfSelect.js" type ="text/javascript"></script>


</body>
</html>

