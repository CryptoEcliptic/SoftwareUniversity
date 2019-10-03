function solve(arr){
    let step = Number(arr.pop());

    let result = arr.filter((_,i) => i % step == 0); 

   for(let j = 0; j < result.length; j++){
       console.log(result[j]);
   }
}

// solve(['1', 
// '2',
// '3', 
// '4', 
// '5', 
// '6']
// );

// solve(['dsa',
// 'asd', 
// 'test', 
// 'tset', 
// '2']
// )