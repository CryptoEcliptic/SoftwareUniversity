function solve(arr, command) {

    function comparator(a, b){
        if (command === 'asc') {
            return (a - b);
        }
        return (b - a);

    }
    const result = arr.sort(comparator);
    return result;
}

let arrayS = solve([14, 7, 17, 6, 8], 'desc');
console.log(arrayS)