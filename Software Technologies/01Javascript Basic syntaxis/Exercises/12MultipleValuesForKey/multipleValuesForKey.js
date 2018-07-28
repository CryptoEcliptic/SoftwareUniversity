function solve(arr) {

    let objectCollection = {};

    for (let i = 0; i < arr.length - 1; i++) {

        let input = arr[i].split(' ');
        let key = input[0];
        let value = input[1];
        if (!objectCollection.hasOwnProperty(key)) {
            objectCollection[key] = new Array();
        }

        objectCollection[key].push(value);
    }
    let key = arr[arr.length - 1];
    if (objectCollection.hasOwnProperty(key)) {
        for (let value of objectCollection[key]) {
            console.log(value);
        }
    } else {
        console.log("None");
    }
}

solve([
    '3 test',
    '3 test1',
    '4 test2',
    '4 test3',
    '4 test5',
    '4'
]);