function solve(arr) {
    let rotations = Number(arr.pop() % arr.length);

    for (let i = 0; i < rotations; i++) {

        let lastElement = arr.pop();
        arr.unshift(lastElement);
    }
    let result = "";
    for(let line of arr){
        result += line + ' ';
    }

    console.log(result.trim())
}

solve(['1',
    '2',
    '3',
    '4',
    '2']
)

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
)