function create(words) {

   let contentElement = document.getElementById('content');
   words.forEach(x => contentElement.appendChild(createDiv(x)));

   [...document.querySelectorAll('#content div')].forEach(x => x.addEventListener('click', (e) =>{
      e.target.firstChild.style.display = 'block';
   }));

   function createDiv(text) {
      let divElement = document.createElement('div');
      let pElement = document.createElement('p');
      pElement.style.display = 'none';
      pElement.innerHTML = text;
      divElement.appendChild(pElemend);

      return divElement;
   }
}