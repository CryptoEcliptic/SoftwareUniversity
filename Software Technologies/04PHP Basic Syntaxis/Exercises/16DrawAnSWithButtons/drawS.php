<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php

for ($i = 1; $i <= 9; $i++) {

    if($i == 1 || $i == 9 || $i == 5){
        echo "<button style='background-color: blue'>1</button>
    <button style='background-color: blue'>1</button>
    <button style='background-color: blue'>1</button>
    <button style='background-color: blue'>1</button>
    <button style='background-color: blue'>1</button><br>";
    }
    else if($i == 2 || $i == 3 || $i == 4){
        echo "<button style='background-color: blue'>1</button>
        <button>0</button>
        <button>0</button>
        <button>0</button>
        <button>0</button><br>";
        
    }
    else if($i == 6 || $i == 7 || $i == 8){
        echo "<button>0</button>
        <button>0</button>
        <button>0</button>
        <button>0</button>
        <button style='background-color: blue'>1</button><br>";

    }
}
?>
</body>
</html>