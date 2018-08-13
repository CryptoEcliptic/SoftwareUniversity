<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $number = intval($_GET['num']);
    $n1 = 1;
    $n2 = 1;
    $n3 = 2;
    echo $n1 . ' ';
    echo $n2 . ' ';
    echo $n3 . ' ';

    for ($i = 3; $i < $number; $i++) {
        $fibo = $n1 + $n2 + $n3;
        $n1 = $n2;
        $n2 = $n3;
        $n3 = $fibo;
        echo $fibo . " ";
    }
}
?>
</body>
</html>