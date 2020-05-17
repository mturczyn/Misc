alert('Extension loaded');
chrome.contextMenus.create({
	title: 'Tłumacz: %s',
	contexts: ['selection'],
	onclick: searchText
});

function searchText(info){
	// Pozbywamy się niepotrebnych spacji na początku i na końcu,
	// oraz wwszelkich białych znaków i zastepujemy je spacją.
	textToTranslate = info.selectionText.trim().replace(/\s+/g, ' ');
	if(!textToTranslate) return;
	var xhr = new XMLHttpRequest();
	xhr.onreadystatechange = () => {
		if(xhr.readyState !== XMLHttpRequest.DONE) return;
		var doc = new DOMParser().parseFromString(xhr.response, 'text/html');
		var translations = doc.querySelectorAll('body > main > div.page > div > div.content-column > div:nth-child(1) > div > div > div.quick-result-overview li');
		translations = [].map.call(translations, (item, index) => ++index + '. ' + item.innerText);
		alert(`${textToTranslate}:\n${translations.join('\n')}`);
	};
	xhr.open('GET', 'https://pl.bab.la/slownik/angielski-polski/' + textToTranslate);
	xhr.send();
}