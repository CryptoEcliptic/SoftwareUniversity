function solve() {

    let inputField = document.getElementById("input");
    let button = document.querySelector("#container > button");
    let convertOption = document.getElementById("selectMenuTo");
    
    createOptions();
    
    button.addEventListener("click", convert);

    function convert() {
        let number = Number(inputField.value)
        let result;

        if(convertOption.value === 'binary'){
            result = decimalToBinary(number);

        }else if(convertOption.value === 'hexadecimal'){
            result = decimalToHexadecimal(number);
        }

        let resultField = document.getElementById("result");
        resultField.value = result;
        console.log(resultField.value);
        return resultField.value;
    }

    function createOptions(){
        let binaryOprion =  document.createElement("option");
        binaryOprion.textContent = "Binary";
        binaryOprion.value = "binary";

        let hexadecOption = document.createElement("option");
        hexadecOption.textContent = "Hexadecimal";
        hexadecOption.value = "hexadecimal";

        convertOption.appendChild(binaryOprion);
        convertOption.appendChild(hexadecOption);
    }

    function decimalToBinary(number){
        return ((number >>> 0).toString(2));
    }

    function decimalToHexadecimal(number){
        return number.toString(16).toUpperCase();
    }
}