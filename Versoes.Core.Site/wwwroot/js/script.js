import initSetores from "./modules/setores.js";
import initLogin from "./modules/login.js";

const setorSection = document.querySelector('#js-setor');
const loginSection = document.querySelector('.js-login');
const logoutUsernamespan = document.querySelector('js-logout-username');
/*
axios.defaults.baseURL = 'http://localhost:51580/api';
//axios.defaults.headers.common['Authorization'] = AUTH_TOKEN;
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
*/

if (setorSection)
    initSetores();


if (loginSection)
    initLogin();

if (logoutUsernamespan)
    console.log(localStorage.getItem('Login'));