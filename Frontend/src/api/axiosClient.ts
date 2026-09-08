import axios from "axios";

const axiosClient = axios.create({
  baseURL: "http://localhost:5160/api",
  headers: {
    "Content-Type": "application/json",
  },
});

// İstek gönderilmeden önce: localStorage'da token varsa Authorization header'a ekle
axiosClient.interceptors.request.use((config) => {
  const token = localStorage.getItem("token");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// Cevap geldikten sonra: 401 gelirse (token süresi dolmuş/geçersiz) otomatik logout
axiosClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      localStorage.removeItem("token");
      window.location.href = "/login";
    }
    return Promise.reject(error);
  }
);

export default axiosClient;