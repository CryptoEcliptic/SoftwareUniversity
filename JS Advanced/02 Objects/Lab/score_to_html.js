function solve(jsonInput) {

  let parsedData = JSON.parse(jsonInput);
  let keys = Object.keys(parsedData[0]);

  let output = '';
  output += `<table>
  <tr><th>${keys[0]}</th><th>${keys[1]}</th></tr>`;
  output += "\n";

  for(let element of parsedData){
    output += `  <tr><td>${escapeElements(element.name)}</td><td>${element.score}</td></tr>`;
    output += "\n";
  }

  output +=`</table>`;
  console.log(output);

  function escapeElements(element){

    let escaped = element
            .replace(/&/g, '&amp;')
            .replace(/"/g,'&quot;')
            .replace(/>/g, '&gt;')
            .replace(/</g, '&lt;')
            .replace(/'/g, '&#39;');

    return escaped
  }
}
solve(['[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]']
);
