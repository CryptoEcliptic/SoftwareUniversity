function solve(arr){
    arr.sort(comparator)
    for(let line of arr){
        console.log(line);
    }
    
    function comparator(a, b) {
        if (a.length !== b.length) {
            return (a.length - b.length);
        }
        return (a.localeCompare(b));
    }
}

solve(['test', 
'Deny', 
'omen', 
'Default']
);