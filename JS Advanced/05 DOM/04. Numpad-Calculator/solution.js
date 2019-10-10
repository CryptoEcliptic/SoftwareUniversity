function solve() {

    let operators = ["/", "*", "-", "+",];
    let leftOperandAsString = '';
    let rightOperandAsString = '';
    let operator = '';
    let result = 0;
    let expressedDisplay = document.getElementById('expressionOutput');
    let outputDisplay = document.getElementById('resultOutput');
    let isRightOperand = false;

    const dataProcessor = e => {
        const keyPressed = e.target.value;
        if (keyPressed === 'Clear') {
            expressedDisplay.innerHTML = '';
            outputDisplay.innerHTML = '';
            leftOperandAsString = '';
            rightOperandAsString = '';
            operator = '';
            result = 0;
            isRightOperand = false;
            return;
        }
        if (operators.includes(keyPressed)) {
            isRightOperand = true;
            operator = keyPressed
        }
        if (isRightOperand && keyPressed !== '=' && !(operators.includes(keyPressed))) {
            rightOperandAsString += keyPressed;
        } else {
            if (!(operators.includes(keyPressed)) && keyPressed !== '=')
                leftOperandAsString += keyPressed
        }

        if(keyPressed !== '='){
            expressedDisplay.textContent = (leftOperandAsString + ' ' + operator + ' ' + rightOperandAsString)
        }

        if (keyPressed === "=") {
            result = calculateResult(leftOperandAsString, operator, rightOperandAsString);
            outputDisplay.textContent = result
        }
    }
    function calculateResult(a, operator, b) {
        if(a === '' || operator === '' || b == ''){
            return NaN
        }
        let calc = {
            '+': (a, b) => a + b,
            '-': (a, b) => a - b,
            '*': (a, b) => a * b,
            '/': (a, b) => a / b,
        }
        result = calc[operator](Number(a), Number(b));
        return result
    }
    document.addEventListener('click', dataProcessor);
}