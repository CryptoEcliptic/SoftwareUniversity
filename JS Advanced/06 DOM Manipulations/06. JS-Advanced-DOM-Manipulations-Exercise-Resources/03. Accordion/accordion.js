function toggle() {
    let button = document.getElementsByClassName('button')[0];
    let mailField = document.getElementById('extra');

    if(mailField.style.display === 'block'){
        mailField.style.display = 'none';
        button.innerHTML = 'MORE';
    }else{
        mailField.style.display = 'block'
        button.innerHTML = 'LESS';
    }
}