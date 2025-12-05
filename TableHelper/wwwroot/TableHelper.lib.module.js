window.emitCustomEvent = (eventName) => {
    const myEvent = new CustomEvent(eventName);
    window.dispatchEvent(myEvent);
};