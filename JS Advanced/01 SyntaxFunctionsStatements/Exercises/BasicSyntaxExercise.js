function fruits(fruit, grams, pricePerKg) {
    let weightInKg = grams / 1000;
    let moneyNeeded = pricePerKg * weightInKg;

    console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`)
}

//fruits('apple', 1563, 2.35);

function greatestCommonDivisor(number1, number2) {
    let minNumber = Math.min(number1, number2);
    let greatestDivisor = 1;

    for (let i = 1; i <= minNumber; i++) {
        if (number1 % i === 0 && number2 % i === 0) {
            greatestDivisor = i;
        }
    }

    console.log(greatestDivisor);
}

//greatestCommonDivisor(2154, 458)

function sameNumbers(number) {
    let numberAsString = number.toString();
    let sum = +numberAsString[0];
    let areEqual = true;

    for (let i = 1; i < numberAsString.length; i++) {
        let firstNumber = +numberAsString[0];
        sum += +numberAsString[i]
        if (firstNumber != numberAsString[i]) {
            areEqual = false;
        }
    }

    console.log(areEqual);
    console.log(sum);
}

//sameNumbers(1234);

function timeToWalk(paces, paceLengthInMeters, speedKmperHour) {
    let metersForBreak = 500;
    let secondsInOneMinute = 60;

    let distanceInMeters = paces * paceLengthInMeters;
    let numberOfBreaks = Math.floor(distanceInMeters / metersForBreak);
    let secondsForBreak = numberOfBreaks * secondsInOneMinute;

    let speedInMetersPesSecond = speedKmperHour / 3.6;
    let secondsForWalk = distanceInMeters / speedInMetersPesSecond;

    let totalTravelTimeInSeconds = secondsForBreak + secondsForWalk;

    var hours = Math.floor(totalTravelTimeInSeconds / 3600);
    var minutes = Math.floor(totalTravelTimeInSeconds / 60);
    var seconds = Math.floor(totalTravelTimeInSeconds % 60) + 1;

    if (hours < 10) {
        hours = '0' + hours
    }

    if (minutes < 10) {
        minutes = '0' + minutes
    }

    if (seconds < 10) {
        seconds = '0' + seconds
    }
    console.log(`${hours}:${minutes}:${seconds}`);
}

//timeToWalk(2564, 0.70, 5.5);

function calorieObject(dataArr) {
    let element = {};

    for (let i = 0; i <= dataArr.length - 1; i += 2) {
        element[dataArr[i]] = +dataArr[i + 1];
    }

    console.log(element);
}

//calorieObject(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);

function roadRadar([speed, typeRoad]) {
    let result;
    function speedTresholdsWarning(number) {
        let result;
        if(number <= 0){

        }
        else if (number <= 20) {

            result = 'speeding';
        }
        else if (number <= 40) {
            result = 'excessive speeding';
        }
        else {
            result = 'reckless driving';
        }

        return result;
    }

    let zones = {
        'city': 50,
        'residential': 20,
        'interstate': 90,
        'motorway': 130
    }

    let difference = speed - zones[typeRoad];
    result = speedTresholdsWarning(difference);

    result !== undefined ? console.log(result) : "";
}

roadRadar([40, 'city']);


function cookingByNumbers(params) {

    let operationsMap = {
        'chop': (x) => x / 2,
        'dice': (x) => Math.sqrt(x),
        'spice': (x) => x + 1,
        'bake': (x) => x * 3,
        'fillet': (x) => x * 0.8
    }

    let parsedNumber = Number(params[0]);

    for (let i = 1; i < params.length; i++) {

        parsedNumber = operationsMap[params[i]](Number(parsedNumber));
        console.log(parsedNumber);
    }
}

//cookingByNumbers(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);

function valididyChecker(arr) {
    let x1 = Number(arr[0]);
    let y1 = Number(arr[1]);
    let x2 = Number(arr[2]);
    let y2 = Number(arr[3]);

    function distance(x1, y1, x2, y2) {
        let distH = x1 - x2;
        let distY = y1 - y2;
        let result = Math.sqrt(distH ** 2 + distY ** 2);
        return result;
    }

    if (Number.isInteger(distance(x1, y1, 0, 0))) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(distance(x2, y2, 0, 0))) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(distance(x1, y1, x2, y2))) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

//valididyChecker([3, 0, 0, 4]);

function coffeeMachine(input) {
    let totalIncome = 0;

    function calcPrice(arr) {
        let price = 0;
        const typeDrink = arr[0];
        if (typeDrink === 'coffee') {
            if (arr[1] === 'caffeine') {
                price += 0.8;
            } else {
                price += 0.9;
            }
            if (Number(arr.pop()) !== 0) {
                price += 0.1;
            }
        } else if (typeDrink === 'tea') {
            price += 0.8;
            if (Number(arr.pop()) !== 0) {
                price += 0.1;
            }
        }
        if (arr.includes('milk')) {
            price += Number((price * 0.1).toFixed(1));
        }
        return price;
    }

    function hasEnoughMoney(inserted, needed) {
        if (inserted >= needed) {
            return {
                isEnough: true,
                change: Number((inserted - needed).toFixed(2)),
                price: needed,
            };
        }
        return {
            isEnough: false,
            change: Number(Math.abs(inserted - needed).toFixed(2)),
            price: needed,
        };

    }

    for (const line of input) {
        const arr = line.split(', ');
        const insertCoins = Number(arr.shift());
        const drink = arr[0];

        const output = hasEnoughMoney(insertCoins, calcPrice(arr));

        if (output.isEnough) {
            totalIncome += output.price;
            console.log(`You ordered ${drink}. Price: $${output.price.toFixed(2)} Change: $${output.change.toFixed(2)}`);
        }else {
            console.log(`Not enough money for ${drink}. Need $${output.change.toFixed(2)} more.`);
        }
    }

    console.log(`Income Report: $${totalIncome.toFixed(2)}`);
}

coffeeMachine([
    '1.00, coffee, caffeine, milk, 4',
    '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0' ]);
