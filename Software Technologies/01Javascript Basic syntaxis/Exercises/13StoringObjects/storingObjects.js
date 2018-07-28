function storingObjects(arr) {

    let dataCollection = new Array();

    for (let i = 0; i < arr.length; i++)
    {
        let input = arr[i].split(" -> ");
        let name = input[0];
        let age = Number(input[1]);
        let grade = input[2];

        dataCollection.push({
            Name: name,
            Age: age,
            Grade: grade
    });
    }
    for(let item of dataCollection) {
        for(let key of Object.keys(item)) {
            console.log(`${key}: ${item[key]}`)
        }
    }
}
storingObjects([
    'Pesho -> 13 -> 6.00',
    'Ivan -> 12 -> 5.57',
    'Toni -> 13 -> 4.90'
]);