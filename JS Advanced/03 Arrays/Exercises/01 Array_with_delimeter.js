function solve(arr){
    function dataProcess() {
        let delimeter = arr.pop();
        let result = arr.join(delimeter);
        return result;
    }

    console.log(dataProcess());
}

solve(['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']
);

solve(['How about no?', 
'I',
'will', 
'not', 
'do', 
'it!', 
'_']
)