/*axios.defaults.baseURL = 'http://localhost:51580/api';
axios.defaults.headers.common['Authorization'] = AUTH_TOKEN;
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';


*/
export const api = new URL("http://localhost:51580/api");

axios.interceptors.request.use(async(config) => {
    console.log('reuiqisição do axios' + config.url);
    if (!config.url.endsWith('Login')) {
        console.log('reuiqisição de login');
        const userToken = localStorage.getItem('token');
        config.headers.Authorization = `Bearer ${userToken}`;
    }
    return config;
}, (error) => {
    if (error.response.status === 401) {
        const requestConfig = error.config;
        return axios(requestConfig);
    }
    return Promise.reject(error);
});