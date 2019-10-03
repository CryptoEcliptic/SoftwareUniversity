function solve(arr){
    const reducer = (acc, curr) => acc + curr;
    let horizontalArr = [];
    let verticalArr = [];

    for(let i = 0; i < arr.length; i++ ){
        let currentElement = arr[i];
        let rowSum = currentElement.reduce(reducer);
        horizontalArr.push(rowSum)

        let colSum = 0;
        for(let j = 0; j < arr.length; j++)
        {
            colSum += arr[j][i]; 
        }
        verticalArr.push(colSum)  
    }
    let result = true;
    for(let i = 0; i < horizontalArr.length; i++){
        if(horizontalArr[i] !== verticalArr[i]){
            result = false;
            break;
        }
}
 return console.log(result);
}

solve([[4, 5, 6],
 [6, 5, 4],
 [5, 5, 5]]
   );