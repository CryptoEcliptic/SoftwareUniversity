function solve(arr){
    let data = [];

    for (let index = 0; index < arr.length; index++) {

       let[name, level, items] = arr[index].split(' / ');
       level = Number(level);
       items = items ? items.split(', ') : []; 
    
       data.push({name, level, items});
    }
    console.log(JSON.stringify(data));
}

solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);