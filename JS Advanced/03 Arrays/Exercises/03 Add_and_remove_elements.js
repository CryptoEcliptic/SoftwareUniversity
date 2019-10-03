function solve(commands){
    let result = [];
    let number = 1;

    let actions = {
        add : "push",
        remove : "pop"
    }
    for(let i = 0; i < commands.length; i++){
       result[actions[commands[i]]](number++);
    }
    if(result.length === 0){
        console.log("Empty");
    } else{
        for(let line of result){
            console.log(line);
        }
    }  
}

solve(['add', 
'add', 
'add', 
'add'])

solve(['add', 
'add', 
'remove', 
'add', 
'add']
)