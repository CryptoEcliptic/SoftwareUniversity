function solve(arr){
    let tab = '   ';
    let doubleTab = '      ';
    let result = '';
    result += '<table>';
    result += "\n";
    for(let line of arr){
        line = JSON.parse(line);
        result += tab + '<tr>' + "\n";
        result += doubleTab + `<td>${line.name}</td>\n`
        result += doubleTab + `<td>${line.position}</td>\n`
        result += doubleTab + `<td>${line.salary}</td>\n`

        result += tab + '</tr>' + "\n";
    }


    result += '</table>';
    console.log(result);
}

solve([
    '{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}' ]
)