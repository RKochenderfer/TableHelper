window.emitCustomEvent = (eventName) => {
    const myEvent = new CustomEvent(eventName);
    window.dispatchEvent(myEvent);
};

export const globalRegisterResizeHandler = (dotnetHelper) => {
    function reportSize() {
        let width = window.innerWidth;
        try {
            dotnetHelper.invokeMethodAsync('UpdateCols', width);
        } catch (err) {
            console.error(err);
        }
    }

    window.addEventListener('resize', reportSize);
    reportSize();
}