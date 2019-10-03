function solve() {

    let data = [...arguments];
    let resultCounts = [];
    let result = [];

    for (let line of data) {
        let currentType = typeof (line);
        if (!(currentType in resultCounts)) {
            resultCounts[currentType] = 1;
        } else {
            resultCounts[currentType]++;
        }

        result.push(`${currentType}: ${line}`);
    }

    let sorted = Object.entries(resultCounts).sort((a, b) => b[1] - a[1]);

    for (let line of result) {
        console.log(line);
    }
    for (let [key, value] of sorted) {
        console.log(`${key} = ${value}`);
    }
}



//solve('cat', 42, function () { console.log('Hello world!');});
solve({ name: 'bob' }, 3.333, 9.999);