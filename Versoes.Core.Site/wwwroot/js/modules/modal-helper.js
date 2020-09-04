export const modalsucesso = Swal.mixin({
    width: '24rem',
    confirmButtonText: 'OK <i class="fas fa-check"></i>',
    keydownListenerCapture: true,
    stopKeydownPropagation: false,
    customClass: {
        confirmButton: 'btn btn-success',
    },
    buttonsStyling: false,
    icon: 'success',
});

export const modalerro = Swal.mixin({
    width: '24rem',
    confirmButtonText: 'OK <i class="fas fa-check"></i>',
    keydownListenerCapture: true,
    stopKeydownPropagation: false,
    customClass: {
        confirmButton: 'btn btn-danger',
    },
    buttonsStyling: false,
    icon: 'error',
});