<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num"/>
    <input type="submit"/>
</form>
<?php
if (isset($_GET['num'])) {
    $number = intval($_GET['num']);
    for ($i = $number; $i >= 1; $i--) {
        if(isPrime($i)){
            echo $i . " ";
        }
    }
}
?>
<?php
function isPrime($x)
{
    if($x <= 1)
    {
        return false;
    }
    $data = array();
    for ($i=1;$i<=$x;$i++)
    {
        if(is_integer($x/$i))
        {
            array_push($data, ($x/$i));
        }
    }
    if(count($data)>2)
    {
        return false;
    }
    else
    {
        echo $x . " ";
    }
}
?>
</body>
</html>