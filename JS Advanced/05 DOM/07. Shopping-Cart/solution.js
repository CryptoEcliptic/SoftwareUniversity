function solve() {
   let isOrderFinished = false;
   const shoppingChart = new Set();
   let totalPrice = 0;
   let dataField = document.querySelector('textarea');
   let checkoutButton = document.getElementsByClassName('checkout')[0];

   checkoutButton.addEventListener('click', checkoutResult);

   [ ...document.querySelectorAll('.add-product') ].forEach(e => e.addEventListener('click', () => {
         if (isOrderFinished) {
            return;
         }
         let childrenElements = e.parentNode.parentElement.children;
         let productName = childrenElements[1].children[0].innerHTML;
         let price = childrenElements[3].innerHTML;

         if(productName === null || price === null){
            throw new Error("Missing DOM elements!")
         }
         
         shoppingChart.add(productName)

         totalPrice += Number(price)
         let message = `Added ${productName} for ${price} to the cart.`;
         dataField.value += message + '\n'
      }));

   function checkoutResult() {
      if (isOrderFinished) {
         return;
      }
      isOrderFinished = true;
      dataField.value += `You bought ${[...shoppingChart].join(', ')} for ${totalPrice.toFixed(2)}.`;
   }
}