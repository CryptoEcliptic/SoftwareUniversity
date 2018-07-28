function solve(arr) {

    let object = {};

    for (let i = 0; i < arr.length - 1; i++) {
        let tokens = arr[i].split(' ');
        let key = tokens[0];
        let value = tokens[1];
        object[key] = value;
    }

    if (object.hasOwnProperty(arr[arr.length - 1])) {
        console.log(object[arr[arr.length - 1]]);
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