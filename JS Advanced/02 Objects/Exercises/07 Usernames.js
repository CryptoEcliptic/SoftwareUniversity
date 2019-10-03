function solve(arr) {
    const usernames = new Set();

    for (const name of arr) {
        usernames.add(name);
    }

    [...usernames]
        .sort((a, b) => comparator(a, b))
        .forEach(x => console.log(x));

    function comparator(a, b) {
        if (a.length !== b.length) {
            return (a.length - b.length);
        }
        return (a.localeCompare(b));
    }
}



solve(['Denise',
    'Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot']
);