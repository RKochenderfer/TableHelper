const successfullyCreatedToast = document.getElementById('npcSuccessfullySavedToast')
const successfullyCreatedNpcToast = bootstrap.Toast.getOrCreateInstance(successfullyCreatedToast)

const failedToCreateToast = document.getElementById('npcFailedToSaveToast')
const failedToCreateNpcToast = bootstrap.Toast.getOrCreateInstance(failedToCreateToast)

export const showSuccessfullyCreatedNpcToast = () => {
    successfullyCreatedNpcToast.show()
}

export const showFailedToCreateNpcToast = () => {
    failedToCreateNpcToast.show()
}

