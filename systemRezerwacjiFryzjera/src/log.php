<?php
    
    session_start();


    if($_SESSION['logged'])   // if we are logged yet we don t wanna log again until log out button
    {
        header('Location: logged.php');
    }


    session_start();
   
    $login = $_POST['login'];
    $password = $_POST['pass'];
    $_SESSION['login_to_show'] = $_POST['login'];
    
    if((!isset($_POST['login'])) || (!isset($_POST['pass']))) // this is example when user try to write exact url link to this file
    {
        header('Location: index.php');
        exit();
    }

    $check_conn = require_once 'database.php';
    if(!$check_conn){exit();}  // we have to have connecton to do script , this is handler of connection

    // firsly we have to sanitize and validate input, because it is proned to injection


    $sanitized_login = htmlentities($login,ENT_QUOTES,"UTF-8");
    $sanitized_password = htmlentities($password,ENT_QUOTES,"UTF-8");


    $result = $connection->query(sprintf("SELECT * FROM uzytkownicy WHERE login='%s' OR mail='%s'",mysqli_real_escape_string($connection,$sanitized_login),mysqli_real_escape_string($connection,$sanitized_login)));


    if($result)  // if querend is good
    {
        $row = $result->fetch_assoc(); // we get assosiactive table
        $how_many_users = $result->num_rows;
        $user = $row['login'];

        if( $how_many_users > 0 && $user != "kubi123" && password_verify($sanitized_password,$row['haslo']) == true )  // this means that we found such a user
        {   

          
            // we chech hashed password for given login

            

                $_SESSION['logged'] = true; // we have success
                $_SESSION['id'] = $row['id'];
                $_SESSION['Name_of_logged'] = $row['imie'];

                $result->free_result();

                unset($_SESSION['error_log']); // if we had earlier this error , now we can log normally
                header('Location: logged.php');
            
        }
        else if( $how_many_users > 0 && $user == "kubi123" && password_verify($sanitized_password,$row['haslo']) == true )  // we add manually admin to our system
        {
            $_SESSION['logged'] = true; // we have success
            $row = $result->fetch_assoc(); // we get assosiactive table
            $_SESSION['id'] = $row['id'];
            $_SESSION['Name_of_logged'] = $row['imie'];

            $result->free_result();

            unset($_SESSION['error_log']); // if we had earlier this error , now we can log normally
            header('Location: admin.php');
        }
        else
        {
            $_SESSION['error_log'] = '<div class="error">Nieprawidlowy login lub haslo!</div>';
            header('Location: index.php');
            $_SESSION['loginInput'] = $_POST['login'];
        }

    }
    else
    {
        echo 'Error of mysql';
    }

    $connection->close();
    

?>