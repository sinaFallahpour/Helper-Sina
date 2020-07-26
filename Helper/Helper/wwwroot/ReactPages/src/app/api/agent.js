import axios from 'axios';
//import ProjectStore from '../stores/projectStore';
// axios.defaults.baseURL = 'http://localhost:5000/api';
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
var Projecets = {
    list: function (params) {
        return axios.get('/Admin/Projects/List', { params: params }).then(responseBody);
    },
    delete: function (project) {
        axios.post("/Admin/Projects/Delete/" + project.Id, project);
    }
};
export default {
    Projecets: Projecets,
};
//# sourceMappingURL=agent.js.map