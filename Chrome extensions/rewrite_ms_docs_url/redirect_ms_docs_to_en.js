chrome.webRequest.onBeforeRequest.addListener(
  (event) => { 
    if ( event.url.includes("/pl-pl/")) {
      return { redirectUrl: event.url.replace("/pl-pl/", "/en-us/") }; 
	}
  },
  {urls: ["*://docs.microsoft.com/*"]},
  ["blocking"]
);