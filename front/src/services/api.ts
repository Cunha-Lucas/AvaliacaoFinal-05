
import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5127', 
});

api.interceptors.request.use((config) => {
  if (typeof window !== 'undefined') {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
  }
  return config;
});

api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (typeof window !== 'undefined' && error.response?.status === 401) {
      window.location.href = '/nao-autenticado';
    }
    return Promise.reject(error);
  }
);

export default api;