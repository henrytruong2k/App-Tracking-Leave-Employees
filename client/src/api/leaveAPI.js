import axiosClient from "./axiosClient";

const leaveAPI = {
  getAll(params) {
    const url = "/LeaveRequest/GetAll";
    return axiosClient.get(url, { params });
  },
  getMyLeave(id) {
    const url = `/LeaveRequest/MyLeave/${id}`;
    return axiosClient.get(url);
  },
  add(data) {
    const url = "/LeaveRequest/AddLeaveRequest";
    return axiosClient.post(url, data);
  },
  getApproveList(id) {
    const url = `/LeaveRequest/CheckLeaveRequest/${id}`;
    return axiosClient.get(url);
  },
};

export default leaveAPI;
