function setValuesToIndexes(numberLines) {

    let collData = new Array(Number(numberLines[0]));
    for (let i = 0; i < collData.length; i++) {
        collData[i] = 0;
    }

    for (let i = 1; i < numberLines.length; i++) {

    let inputs = numberLines[i].split(" - ");
    let index = Number(inputs[0]);
    let value = Number(inputs[1]);
    collData[index] = value;

    }

    for (let item of collData) {
        console.log(item);
    }
}
setValuesToIndexes(['5',
    '0 - 3',
    '3 - -1',
    '4 - 2']);
