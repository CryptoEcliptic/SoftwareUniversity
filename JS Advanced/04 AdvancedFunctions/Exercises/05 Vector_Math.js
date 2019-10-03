let func = (function solution() {
    function add([x1, y1], [x2, y2]) {
        return [x1 + x2, y1 + y2]

    }
    function multiply([x, y], multiplyer){
        return [x * multiplyer, y * multiplyer]
    }
    function length([x, y]){
        return Math.sqrt((Math.pow(x, 2) + Math.pow(y, 2)))
    }

    function dot([x1, y1], [x2, y2]){
        return x1 * x2 + y1 * y2
    }
    function cross([x1, y1], [x2, y2]){
        return (x1 * y2) - (y1 * x2)
    }

    return{
        add,
        multiply,
        length,
        dot,
        cross
    }
})()

console.log(func.add([1, 1], [1, 0]))
console.log(func.multiply([3.5, -2], 2))
console.log(func.length([3, -4]))
console.log(func.dot([2, 3], [2, -1]))
console.log(func.cross([3, 7], [1, 0]))
