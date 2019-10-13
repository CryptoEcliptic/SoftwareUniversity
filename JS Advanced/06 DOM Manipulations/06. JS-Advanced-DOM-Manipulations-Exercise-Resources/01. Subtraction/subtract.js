function subtract() {
    let firstInput = document.getElementById('firstNumber');
    let secondInput = document.getElementById('secondNumber');
    let resultField = document.getElementById('result');

    let result = Number(firstInput.value) - Number(secondInput.value);
    resultField.innerHTML = result;
}