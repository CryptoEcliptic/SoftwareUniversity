function solve(data) {
        function textProcessor(string) {
            let textToProcess = string
                .split("|")
                .filter(x => x !== '')
                .map(x => x.trim())
                .map(x => Number(x) ? Number((Math.floor(Number(x) * 100) / 100).toFixed(2)) : x)
                ;
            return textToProcess;
        }

    let keys = data[0];
    let processedKeys = textProcessor(keys);

    let values = [];
    for (let i = 1; i < data.length; i++) {
        
        let processedRow = textProcessor(data[i]);
        let obj = {};
        for(let j =0; j < processedRow.length; j++){

            let currKey = processedKeys[j];
            let val = processedRow[j]
            obj[currKey] = val; 
        } 
        values.push(obj);
    }
    let result = JSON.stringify(values);
    console.log(result);
}


solve(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']

)

// [
// {"Town":"Beijing", 
//  "Latitude":39.91, 
//  "Longitude":116.36
// }
// ]
