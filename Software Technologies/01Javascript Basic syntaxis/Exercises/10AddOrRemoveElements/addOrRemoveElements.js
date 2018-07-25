function addOrRemove(inputData) {

    let arr = new Array();
    for (let i = 0; i < inputData.length; i++) {

        let input = inputData[i].split(' ');
        let command = input[0];
        let number = input[1];
        if(command === "add"){
            arr.push(number);
        }
        if (command === "remove" && number < arr.length)
            arr.splice(number, 1);
    }
    for (let item of arr) {
        console.log(item);
    }
}
addOrRemove([
    'add 3',
    'add 5',
    'remove 1',
    'add 2'
]);