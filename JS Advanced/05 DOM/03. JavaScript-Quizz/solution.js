function solve() {

  const correctAnswers = {
    0: 'onclick',
    1: 'JSON.stringify()',
    2: 'A programming API for HTML and XML documents',
  };
  let index = 0;
  let correctCount = 0;

  let sections = document.getElementsByTagName("section");
  let result = document.getElementById('results');

  const handler = e => {
    const answer = e.target.textContent.trim();
    if (correctAnswers[index] === answer) {
      correctCount++;
    }

    if (index < 2) {
      sections[index].style.display = 'none';
      sections[index + 1].style.display = 'block';
    } else {
      sections[index].style.display = 'none';
      result.style.display = 'block';
      let finalResultElement = document.getElementsByClassName('results-inner')[0];
      finalResultElement.firstChild.textContent = correctCount === 3 ?
        'You are recognized as top JavaScript fan!' : `You have ${correctCount} right answers`;
    }
    index++;
  }
  document.addEventListener('click', handler);
  console.log(sections)
}
