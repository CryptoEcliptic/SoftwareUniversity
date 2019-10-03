function solve(arrays) {
    let data = [];
    let sorted = [];
    for (let line of arrays) {
        data.push(JSON.parse(line));
    }

    for (let line of data) {
        let sortLine = line.sort((a, b) => b - a);
        sorted.push(sortLine);
    }

    for (let i = 0; i < sorted.length - 1; i++) {
        let currentArr = sorted[i];
        for (let j = i + 1; j < sorted.length; j++) {
            let equal = compareArrays(currentArr, sorted[j]);
            if(equal){
                sorted.splice(j, 1);
                j--;
            }
        }
    }
   
    let output = sorted
        .sort((a, b) => a.length - b.length);
    for (let line of output) {
        console.log(`[${line.join(', ')}]`);
    }
    function compareArrays(currentArr, nextArr) {
        if (currentArr.length !== nextArr.length) {
            return false;
        }
        else {
            for (let i = 0; i < currentArr.length; i++) {
                if (currentArr[i] !== nextArr[i]) {
                    return false;
                }
            }
        }
        return true;
    }
}

// solve(["[-3, -2, -1, 0, 1, 2, 3, 4]",
//     "[10, 1, -17, 0, 2, 13]",
//     "[4, -3, 3, -2, 2, -1, 1, 0]"]
// );

solve(["[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]",
    "[1, 2, 3, 4, 5, 6]"
  ]
);