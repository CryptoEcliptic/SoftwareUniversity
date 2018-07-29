function parsingJSON(arr) {

    for (let i = 0; i < arr.length; i++) {
        let data = JSON.parse((arr[i]));
        console.log(`Name: ${data.name}`);
        console.log(`Age: ${data.age}`);
        console.log(`Date: ${data.date}`);
    }
}
parsingJSON([
    '{"name":"Gosho","age":10,"date":"19/06/2005"}',
    '{"name":"Tosho","age":11,"date":"04/04/2005"}'
]);