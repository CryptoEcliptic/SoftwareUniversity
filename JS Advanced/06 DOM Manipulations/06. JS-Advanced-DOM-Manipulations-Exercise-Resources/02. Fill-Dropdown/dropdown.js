function addItem() {
    let textField = document.getElementById('newItemText');
    let valueField = document.getElementById('newItemValue');
    let selectMenu = document.getElementById('menu');
    createOption();
    clearInput();

    function createOption() {
        let option = document.createElement('option');
        option.value = valueField.value;
        option.innerHTML = textField.value;
        selectMenu.appendChild(option);
    }
    function clearInput() {
        valueField.value = '';
        textField.value = '';
    }
}