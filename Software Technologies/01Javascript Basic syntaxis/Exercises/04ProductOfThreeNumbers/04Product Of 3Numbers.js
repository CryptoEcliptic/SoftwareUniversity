
function productof3Numbers(numbers) {

    let product = numbers[0] * numbers[1] * numbers[2];
    if (product < 0){
        console.log("Negative");
    }
    else{
        console.log("Positive");
    }
}
productof3Numbers(['2', '3', '4']);
