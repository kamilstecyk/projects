<?php
    session_start();
    
    session_unset(); // we end session because we want to log out
    header('Location: index.php');

?>