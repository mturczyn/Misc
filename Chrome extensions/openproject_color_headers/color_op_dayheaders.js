window.onload = (event) => {
	let counter = 1;
	let i = setInterval(() => {
    var dayHeaders = document.querySelectorAll("tr > td[colspan='3']");
    console.log("Iteracja nr. " + counter + ", dł. tablicy: " + dayHeaders.length);
    for(let dayHeader of dayHeaders) {
      dayHeader.parentNode.style.backgroundColor = "#1A67A3";
      dayHeader.parentNode.style.color = "#FFFFFF";
    }
	if(dayHeaders.length > 0 || counter > 20) {
		console.log("Koniec iteracji");
		clearInterval(i);
	}
	counter++;
  }, 500);
}