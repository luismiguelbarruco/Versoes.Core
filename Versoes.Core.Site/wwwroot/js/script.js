import initSetores from "./modules/setores.js";
import initProjetos from "./modules/projetos.js";
import initLogin from "./modules/login.js";
import initUsuarios from "./modules/usuarios.js";

const setorSection = document.querySelector('#js-setor');
const usuarioSection = document.querySelector('#js-usuario');
const projetoSection = document.querySelector('#js-projeto');
const loginSection = document.querySelector('.js-login');
const logoutUsernamespan = document.querySelector('.js-logout-username');
const linkLogout = document.querySelector('#linkLogout');


if (usuarioSection)
    initUsuarios();

if (projetoSection)
    initProjetos();

if (setorSection)
    initSetores();

if (loginSection)
    initLogin();

if (logoutUsernamespan)
    logoutUsernamespan.innerText = localStorage.getItem('login');


if (linkLogout) {
    linkLogout.addEventListener('click', function() {
        localStorage.clear();
        window.location.href = '/Usuario/Login';
    });
}