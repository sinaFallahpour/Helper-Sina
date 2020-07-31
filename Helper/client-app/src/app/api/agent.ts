import axios, { AxiosResponse } from 'axios';

import { history } from '../..';
import { toast } from 'react-toastify';
  
import { IUser, IUserFormValues } from '../models/user';
import { IProfile, IPhoto } from '../models/profile';
import "react-toastify/dist/ReactToastify.css"

axios.defaults.baseURL = 'https://localhost:44340/api';

axios.interceptors.request.use(
  config => {
    const token = window.localStorage.getItem('jwt');
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

axios.interceptors.response.use(undefined, error => {
  if (error.message === 'Network Error' && !error.response) {
    toast.error('خطایی رخ داده!');
  }
  const { status, data, config } = error.response;
  // if (status === 404) {
  //   history.push('/notfound');
  // }
  if (
    status === 400 &&
    config.method === 'get' &&
    data.errors.hasOwnProperty('id')
  ) {
    history.push('/notfound');
  }
  if (status === 500) {
    console.log(error)
    toast.error('خطایی رخ داده!');
  }
  throw error.response;
});

const responseBody = (response: AxiosResponse) => response.data;

// const sleep = (ms: number) => (response: AxiosResponse) =>
//   new Promise<AxiosResponse>(resolve =>
//     setTimeout(() => resolve(response), ms)
//   );

const requests = {
  get: (url: string) =>
    axios
      .get(url)
      .then(responseBody),
  post: (url: string, body: {}) =>
    axios
      .post(url, body)
      .then(responseBody),
  put: (url: string, body: {}) =>
    axios
      .put(url, body)
      .then(responseBody),
  del: (url: string) =>
    axios
      .delete(url)
      .then(responseBody),
  postForm: (url: string, file: Blob) => {
    let formData = new FormData();
    formData.append('File', file);
    return axios
      .post(url, formData, {
        headers: { 'Content-type': 'multipart/form-data' }
      })
      .then(responseBody);
  }
};




const User = {
  current: (): Promise<IUser> => requests.get('/user'),
  login: (user: IUserFormValues): Promise<IUser> =>
    requests.post(`/user/login`, user),
  register: (user: IUserFormValues): Promise<IUser> =>
    requests.post(`/user/register`, user)
};

const Profiles = {
  get: (username: string): Promise<IProfile> =>
    requests.get(`/profiles/${username}`),
  uploadPhoto: (photo: Blob): Promise<IPhoto> =>
    requests.postForm(`/photos`, photo),
  setMainPhoto: (id: string) => requests.post(`/photos/${id}/setMain`, {}),
  deletePhoto: (id: string) => requests.del(`/photos/${id}`),
  updateProfile: (profile: Partial<IProfile>) =>
    requests.put(`/profiles`, profile),


};


const AboutUs = {
  aboutUs: () => requests.get(`/Home/aboutUs`),
};

const ContactUs = {
  contactUs: () => requests.get(`/Home/ContactUs`),
};




export default {
  User,
  Profiles,
  AboutUs,
  ContactUs
};
