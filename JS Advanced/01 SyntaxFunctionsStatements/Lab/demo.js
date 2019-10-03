function myFunc(){
    console.log('a');
}

//myFunc();

function stringLength(arg1, arg2, arg3){
    let totalSymbols = arg1.length + arg2.length + arg3.length;

    console.log(totalSymbols);
    console.log(Math.floor(totalSymbols / 3));
}

//stringLength('chocolate', 'ice cream', 'cake');

function mathOperations(number1, number2, operator){

    let result = 0;
    if(operator === '+'){
        result = number1 + number2;
    }
    else if(operator === '-'){
        result = number1 - number2;
    }
    else if(operator === '*'){
        result = number1 * number2;
    }
    else if(operator === '/'){
        result = number1 / number2;
    }
    else if(operator === '%'){
        result = number1 % number2;
    }
    else if(operator === '**'){
        result = Math.pow(number1, number2);
    }
    else{
        console.log("Unsupported operation!")
    }
    console.log(result);
}

//mathOperations(2, 2, '**');

function sumOfNumbers(param1, param2){
    let result = 0;
    let startNumber = +param1;
    let endNumber = +param2;

    for(let i = startNumber; i <= endNumber; i++){
        result += i;
    }
    console.log(result);
}

//sumOfNumbers('-8', '20');

function largestNumber(param1, param2, param3){
    let result = Math.max(param1, param2, param3)

    console.log(`The largest number is ${result}.`);
}

//largestNumber(-3, -5, -22.5)

function circleArea(arg)
{
    let result = 0;
    let piValue = Math.PI;
    let inputType = typeof(arg);

    if(inputType === "number")
    {
        result = piValue * Math.pow(arg, 2);
        result = result.toFixed(2);
    }
    else
    {
        result = `We can not calculate the circle area, because we receive a ${typeof(arg)}.`
    }

    console.log(result);
}

//circleArea('5');

function squareOfStars(number)
{
   if(number == null){
       number = 5;
   }

    for(let i = 0; i < number; i++){
        
        console.log("* ".repeat(number))
    }
}

//squareOfStars();

function dayOfWeek(argument)
{
    let type = typeof(argument);
    if(type !== 'string')
    {
        console.log('error');
    }
    else
    {
        let daysOfWeek = ['error', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
        if(daysOfWeek.includes(argument))
        {
            console.log(daysOfWeek.indexOf(argument));
        }
        else
        {
            console.log('error');
        }
    }
}

dayOfWeek("Tuesday");