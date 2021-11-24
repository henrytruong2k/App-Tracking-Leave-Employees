import axios from "axios";

const axiosClient = axios.create({
  baseURL: process.env.REACT_APP_SERVER,
  headers: {
    "Content-Type": "application/json",
  },
});

// Add a request interceptor
axiosClient.interceptors.request.use(
  function (config) {
    // Do something before request is sent
    const userInfoFromStorage = localStorage.getItem("userInfo")
      ? JSON.parse(localStorage.getItem("userInfo"))
      : null;
    if (userInfoFromStorage) {
      config.headers.Authorization = `Bearer ${userInfoFromStorage.accessToken}`;
    }

    return config;
  },
  function (error) {
    // Do something with request error
    return Promise.reject(error);
  }
);

axiosClient.interceptors.response.use(
  function (response) {
    return response.data;
  },
  function (error) {
    console.log("ERROR RESPONSE: ", error.response);
    const { status, data } = error.response;
    if (status === 401) {
      throw new Error("Unauthorized");
    }
    if (status === 400) {
      throw new Error(data.message);
    }
    if (status === 500) {
      throw new Error(data.message);
    }
    return Promise.reject(error);
  }
);

export default axiosClient;
