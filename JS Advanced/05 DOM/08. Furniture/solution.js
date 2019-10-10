function solve() {
  let furnitures = [];
  let totalAmount = 0;
  let sumOfFactors = 0;
  const generateButton = document.querySelector('#exercise > button:nth-child(3)');
  const buyButton = document.querySelector('#exercise > button:nth-child(6)');
  const inputTextArea = document.querySelector('#exercise > textarea:nth-child(2)');
  const mainTable = document.querySelector('.table > tbody:nth-child(2)');
  const resultTextArea = document.querySelector('#exercise > textarea:nth-child(5)');

  generateButton.addEventListener('click', processInputData);
  buyButton.addEventListener('click', buyItems);

  function processInputData() {

    if (inputTextArea.value !== '') {
      let inputData = JSON.parse(inputTextArea.value);
      addDataToTable(inputData);
    }
  }
  function addDataToTable([...inputData]) {

    for (let line of inputData) {
      createTableRow(line)
      console.log(line)
    }
  }
  function createTableRow(line) {

    const tableRow = document.createElement('tr');

    const img = document.createElement('img');
    img.src = line.img;

    const pName = document.createElement('p');
    pName.innerHTML = line.name;

    const pPrice = document.createElement('p');
    pPrice.innerHTML = line.price;

    const pDecFac = document.createElement('p');
    pDecFac.innerHTML = line.decFactor

    const input = document.createElement('input');
    input.type = 'checkbox';

    tableRow
      .appendChild(document.createElement('td'))
      .appendChild(img);

    tableRow
      .appendChild(document.createElement('td'))
      .appendChild(pName);

    tableRow
      .appendChild(document.createElement('td'))
      .appendChild(pPrice);

    tableRow
      .appendChild(document.createElement('td'))
      .appendChild(pDecFac);

    tableRow
      .appendChild(document.createElement('td'))
      .appendChild(input);

    mainTable.appendChild(tableRow);
  }
  function buyItems() {
    [...document
      .querySelectorAll('tr td input')]
      .forEach(x => {
        if (x.checked) {
          let children = x.parentNode.parentElement.children;
          let furniture = children[1].textContent;
          let price = children[2].textContent;
          let decorationFactor = children[3].textContent;
          furnitures.push(furniture);
          totalAmount += Number(price);
          sumOfFactors += Number(decorationFactor);
        }
      });
    showResult()
  }
  function showResult() {
    let result = `Bought furniture: ${furnitures.join(', ')}
Total price: ${totalAmount.toFixed(2)}\nAverage decoration factor: ${sumOfFactors / furnitures.length}`;
    resultTextArea.value = result;
  }
}