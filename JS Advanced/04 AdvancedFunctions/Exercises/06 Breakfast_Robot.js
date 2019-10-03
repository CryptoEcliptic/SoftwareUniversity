function solution() {
    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    };
    const resources = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    return function processData(...params) {

        let splittedParams = params.toString().split(' ');
        let command = splittedParams[0];
        let result;
        if (command == "report") {
            result = Object.entries(resources)
                .map(x => x.join('='))
                .join(' ');
            return result
        }
        result = command === "restock" ? restockResources(splittedParams[1], Number(splittedParams[2]))
            : prepareMeal(splittedParams[1], Number(splittedParams[2]))

        return result;
    }
    function restockResources(type, quantity) {
        resources[type] += Number(quantity);
        return "Success"
    }
    function prepareMeal(meal, quantity) {
        let currentMeal = recipes[meal];
        let resourcesToTake = {};
        for (let ingredient in currentMeal) {
            let quantityIngr = Number(currentMeal[ingredient] * quantity);
            if (resources[ingredient] < quantityIngr) {
                return `Error: not enough ${ingredient} in stock`;
            } else {
                resourcesToTake[ingredient] = (typeof resourcesToTake[ingredient] === 'undefined') ? quantityIngr
                    : resourcesToTake[ingredient] + quantityIngr;
            }
        }
        for (let ingr in resourcesToTake) {
            resources[ingr] -= resourcesToTake[ingr];
        }
        return "Success";
    }
}

let manager = solution();
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));

// console.log(manager('prepare turkey 1'));
// console.log(manager('restock protein 10'));
// console.log(manager('prepare turkey 1'));
// console.log(manager('restock carbohydrate 10'));
// console.log(manager('prepare turkey 1'));
// console.log(manager('restock fat 10'));
// console.log(manager('prepare turkey 1'));
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare turkey 1'));
// console.log(manager('report'));