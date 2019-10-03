function solve(args) {
    let catalogue = {};

    for (const line of args) {
        let letter = line[0];
        let inputLine = line.split(' : ')
        let key = inputLine[0];
        let value = Number(inputLine[1]);

        if(!catalogue.hasOwnProperty(letter)){
            catalogue[letter] = {};
        }

        let products = catalogue[letter];

        if(!products.hasOwnProperty(key)){
            products[key] = value;
        }
    }
    let sortedIndexes = Object.keys(catalogue).sort((a, b) => a.localeCompare(b));

    for(let letter of sortedIndexes){
        let products = catalogue[letter];
        let sortedProducts = Object.keys(products).sort((a, b) => a.localeCompare(b));
        console.log(letter);
        
        for (const p of sortedProducts) {
            console.log(`  ${p}: ${products[p]}`)
        }
    }
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);