import axiosClient from "./axiosClient";

const employeeAPI = {
  getAll() {
    const url = "/Employee/GetAll";
    return axiosClient.get(url);
  },
  getApprover(id) {
    const url = `/Employee/GetApprover/${id}`;
    return axiosClient.get(url);
  },
  login(params) {
    const url = "/Employee/Authenticate";
    return axiosClient.post(url, params);
  },
  add(data) {
    const url = "/Employee/AddEmployee";
    return axiosClient.post(url, data);
  },
};

export default employeeAPI;
