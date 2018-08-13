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

</form>
<?php
if (isset($_GET['num'])) {
    $number = intval($_GET['num']);
    $n1 = 1;
    $n2 = 1;
    echo $n1 . ' ';
    echo $n2 . ' ';

    for ($i = 2; $i < $number; $i++) {
        $fibo = $n1 + $n2;
        $n1 = $n2;
        $n2 = $fibo;
        echo $fibo . " ";
    }
}
?>
</body>
</html>