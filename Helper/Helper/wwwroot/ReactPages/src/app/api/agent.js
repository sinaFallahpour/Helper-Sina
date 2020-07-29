import axios from 'axios';
//import ProjectStore from '../stores/projectStore';
import { toast } from 'react-toastify';
axios.defaults.baseURL = 'https://localhost:44340/api';
axios.interceptors.request.use(function (config) {
    var token = window.localStorage.getItem('jwt');
    if (token)
        config.headers.Authorization = "Bearer " + token;
    return config;
}, function (error) {
    return Promise.reject(error);
});
axios.interceptors.response.use(undefined, function (error) {
    if (error.message === 'Network Error' && !error.response) {
        toast.error('خطایه رخ داده!');
    }
    var _a = error.response, status = _a.status, data = _a.data, config = _a.config;
    // if (status === 404) {
    //   history.push('/notfound');
    // }
    // if (
    //   status === 400 &&
    //   config.method === 'get' &&
    //   data.errors.hasOwnProperty('id')
    // ) {
    //   history.push('/notfound');
    // }
    if (status === 500) {
        toast.error('خطایه رخ داده!');
    }
    throw error.response;
});
var responseBody = function (response) { return response.data; };
var sleep = function (ms) { return function (response) {
    return new Promise(function (resolve) {
        return setTimeout(function () { return resolve(response); }, ms);
    });
}; };
var requests = {
    get: function (url) {
        return axios
            .get(url)
            .then(responseBody);
    },
    post: function (url, body) {
        return axios
            .post(url, body)
            .then(responseBody);
    },
    put: function (url, body) {
        return axios
            .put(url, body)
            .then(responseBody);
    },
    del: function (url) {
        return axios
            .delete(url)
            .then(responseBody);
    },
    postForm: function (url, file) {
        var formData = new FormData();
        formData.append('File', file);
        return axios
            .post(url, formData, {
            headers: { 'Content-type': 'multipart/form-data' }
        })
            .then(responseBody);
    }
};
var AboutUs = {
    aboutUs: function () { return requests.get("/Home/aboutUs"); },
};
var ContactUs = {
    contactUs: function () { return requests.get("/Home/ContactUs"); },
};
export default {
    AboutUs: AboutUs,
    ContactUs: ContactUs
};
//# sourceMappingURL=agent.js.map