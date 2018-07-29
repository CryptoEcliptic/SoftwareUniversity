function intoJsonString(arr) {
    let object = {};

    for(let pair of arr) {
        let tokens = pair.split("->");
        let key = tokens[0].trim();
        let value = tokens[1].trim();
        if(!isNaN(value)) {
            value = parseFloat(value);
        }
        object[key] = value;
    }

    let json = JSON.stringify(object);
    console.log(json);
}
intoJsonString([
    'name -> Angel',
    'surname -> Georgiev',
    'age -> 20',
    'grade -> 6.00',
    'date -> 23/05/1995',
    'town -> Sofia'
]);