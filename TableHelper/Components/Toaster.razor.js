/**
 * Handles managing toast selectors and instances 
 */
class ToastHelper {
    /** 
     * The HTML Element's id of the bootstrap toast
     * @type {string}
     */
    #toastId;
    
    /** 
     * The selector to the bootstrap toast element
     * @type {HTMLElement}
     */
    #selector;

    /**
     * The bootstrap Toast instance
     * @type {bootstrap.Toast}
     */
    #toastInstance;

    /**
     * Create a new ToastHelper for a toast element
     * @param toastElementId
     */
    constructor(toastElementId) {
        this.#toastId = toastElementId;
    }

    /**
     * Shows the toast element on the page
     */
    show() {
        if (this.#selector === undefined) {
            this.#selector = document.getElementById(this.#toastId);
        }
        if (this.#toastInstance === undefined) {
            this.#toastInstance = bootstrap.Toast.getOrCreateInstance(this.#selector);
        }
        this.#toastInstance.show();
    }
}

let successToast = new ToastHelper('successToast');
let failedToast = new ToastHelper('failedToast');

/**
 * Displays a blue toast for presenting success messages
 */
export const showSuccessToast = () => successToast.show()

/**
 * Shows a red toast for present failure messasges
 */
export const showFailedToast = () => failedToast.show()

