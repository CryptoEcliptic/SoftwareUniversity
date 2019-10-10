function solve() {
   const leftSpan = document.querySelector('#result').firstElementChild;
   const rightSpan = document.querySelector('#result').lastElementChild;
   let historyElement = document.getElementById('history');
   let firstCard;
   let secondCard;

   [...document.querySelectorAll('img')].forEach(x => x.addEventListener('click', (e) => {
      e.target.src = 'images/whiteCard.jpg';
      if (e.target.parentElement.id === 'player1Div') {
         leftSpan.innerHTML = e.target.name;
         firstCard = e.target;
      } else {
         rightSpan.innerHTML = e.target.name;
         secondCard = e.target;
      }
      checkCards();
      addResultToHistory();
   }));

   function checkCards() {
      if (leftSpan.innerHTML !== '' && rightSpan.innerHTML !== '') {
         if (Number(firstCard.name) > Number(secondCard.name)) {
            firstCard.style.border = '2px solid green';
            secondCard.style.border = '2px solid red';
         } else {
            secondCard.style.border = '2px solid green';
            firstCard.style.border = '2px solid red';
         }
      }
   }
   function addResultToHistory() {
      if (leftSpan.innerHTML !== '' && rightSpan.innerHTML !== '') {
         historyElement.innerHTML += `[${firstCard.name} vs ${secondCard.name}] `;
         leftSpan.innerHTML = '';
         rightSpan.innerHTML = '';
      }
   }
}

