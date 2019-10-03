function solve(arr){
    let biggestNum = arr[0];
    let result = [];

    for(let i = 0; i < arr.length; i++){

        if(arr[i] >= biggestNum){
            result.push(arr[i])
            biggestNum = arr[i];
        }  
    }
    for(let line of result){
        console.log(line);
    }
}


// solve([1, 
//     2, 
//     3,
//     4]    
//     );

    solve([1, 
        3, 
        8, 
        4, 
        10, 
        12, 
        3, 
        2, 
        24]
        )