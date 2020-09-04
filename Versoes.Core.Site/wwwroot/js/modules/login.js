import { api } from '../modules/api.js';
import { modalsucesso, modalerro } from '../modules/modal-helper.js';

export default function initLogin() {

    const apiAutenticar = api + '/usuarios/login';
    const form = document.querySelector('#formSingIn');

    form.addEventListener("submit", handleSubmit);


    function handleSubmit(event) {
        event.preventDefault();
        event.stopPropagation();

        if (this.checkValidity()) {
            const login = this.querySelector('#Login').value;
            const senha = this.querySelector('#Senha').value;

            // console.log(login, senha);
            handleAuthentication(login, senha)

        }
        form.classList.add('was-validated');
    }

    async function handleAuthentication(login, senha) {
        //console.log(login, senha);
        try {
            const response = await axios.post(apiAutenticar, { login, senha });

            if (response.data.success) {
                localStorage.clear();
                localStorage.setItem("token", response.data.data.token);
                localStorage.setItem("usuarioId", response.data.data.usuarioViewModel.id);
                localStorage.setItem("login", response.data.data.usuarioViewModel.login);
                localStorage.setItem("setorId", response.data.data.usuarioViewModel.setor.id);
                document.location.href = '/Home'
            } else {
                modalerro.fire({
                    text: response.data.message
                });
            }

        } catch (err) {
            modalerro.fire({
                text: 'Erro inesperado ao realizar login'
            });
            console.error(err);
        }
    };
}