<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>18. Fifty Shades of Grey</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
<?php
for ($row = 0;$row < 255; $row += 51){
    for ($col = 0; $col < 50; $col += 5){
        $color = "style=\"background-color: rgb(" . ($row + $col) . ", " . ($row + $col) . ", " . ($row + $col) . ");\"";
        echo "<div $color></div>";
    }
    echo "<br>";
}
?>
</body>
</html>