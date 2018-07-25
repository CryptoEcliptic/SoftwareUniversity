function printLines(line) {

    for (let i = 0; line[i] != "Stop"; i++) {

        console.log(line[i]);
    }
}

printLines([
    '3',
    '6',
    '5',
    'Stop',
])