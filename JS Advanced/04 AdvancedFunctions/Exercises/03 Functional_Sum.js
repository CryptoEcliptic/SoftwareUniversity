let add = (function (){
    let result = 0;

    return function sumNums(num){
        result += num;

        sumNums.toString = function () {
            return result;
        }  
        return sumNums;
    }
})();

console.log(add(1)(6)(-3).toString());