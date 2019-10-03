function solve(arr){

    let fruits = {};
    let bottles = {};

    function processData(fruits){
        for (const key in fruits) {
            if (fruits.hasOwnProperty(key)) {
               if(Number(fruits[key] >= 1000)){
    
                let quantity = Math.floor(fruits[key] / 1000);
                bottles[key] = quantity;
               }  
            }
        }
    }

    for(const line of Object.values(arr)){
        let key = line.split(' => ')
        let fruit = key[0];
        let quantity = Number(key[1]);

        if(!(fruit in fruits)){

            fruits[fruit] = quantity;
        }
        else{
            fruits[fruit] += quantity;
        }

        processData(fruits);
    }
    Object.entries(bottles).forEach(x => console.log(`${x[0]} => ${parseInt(x[1])}`));
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']

);