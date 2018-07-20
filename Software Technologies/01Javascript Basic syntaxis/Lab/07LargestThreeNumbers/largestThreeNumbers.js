function largestThree(arr) {
    let numbers = arr.map(Number);

    let sortedNumbers = numbers.sort((a, b) => b - a );
    let threeMax = Math.min(3, arr.length)

    for (let i = 0; i < threeMax; i++) {
        console.log(sortedNumbers[i]);
        
    }
}

largestThree(['10', '30', '15', '20', '50', '5']);