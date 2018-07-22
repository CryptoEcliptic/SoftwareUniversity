function productNums(args) {
    let x = args[0];
    let y = args[1];
    let z= args[2];
    let counter = 0;
    if(x === 0 || y ==0 || z ==0){
        console.log("Positive");
    }

    if (x < 0){
        counter++;
    }

    if (y < 0){
        counter++;
    }

    if (z < 0){
        counter++;
    }

    if (counter % 2 == 0) {
        console.log("Positive");
    }
    else{
        console.log("Negative");
    }
}
console.log(productNums([1, 2, 2]))