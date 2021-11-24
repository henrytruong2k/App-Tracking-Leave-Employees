import { Button, Popconfirm, Space, Tag, notification } from "antd";
import { DeleteOutlined, EditOutlined, EyeOutlined } from "@ant-design/icons";
import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import leaveAPI from "../../api/leaveAPI";
import Header from "../../components/Header";
import TableData from "../../components/TableData";
import AddLeaveRequest from "./components/AddLeaveRequest";
import moment from "moment";
import employeeAPI from "../../api/employeeAPI";

const EmployeeScreen = () => {
  const [myLeaveRequests, setMyLeaveRequests] = useState([]);
  const [renderList, setRenderList] = useState([]);
  const [requester, setRequester] = useState(null);
  const userLogin = useSelector((state) => state.userLogin);
  const { userInfo } = userLogin;
  const parseDate = (date) => {
    return moment(new Date(date)).format("MM/DD/YYYY");
  };
  const calculateDiff = (from, to) => {
    const start = moment(from);
    const end = moment(to);
    return end.diff(start, "days");
  };

  useEffect(() => {
    (async () => {
      try {
        const leaveHistories = leaveAPI.getMyLeave(userInfo?.id);
        const requesterList = employeeAPI.getApprover(userInfo?.approverId);

        const [...array] = await Promise.all([leaveHistories, requesterList]);
        setMyLeaveRequests(array[0]);
        setRequester(array[1]);
      } catch (error) {
        console.log(error);
      }
    })();
  }, [userInfo]);

  useEffect(() => {
    setRenderList(myLeaveRequests);
  }, [myLeaveRequests]);

  const columns = [
    {
      title: "Id",
      dataIndex: "id",
      key: "id",
    },
    {
      title: "Create by",
      dataIndex: "createdBy",
      key: "createdBy",
      render: (text) => text.fullName,
    },
    {
      title: "Requested by",
      dataIndex: "requestedBy",
      key: "requestedBy",
      render: (text) => text?.fullName,
    },
    {
      title: "From",
      dataIndex: "fromDate",
      key: "fromDate",
      render: (text) => parseDate(text),
    },
    {
      title: "To",
      dataIndex: "toDate",
      key: "toDate",
      render: (text) => parseDate(text),
    },
    {
      title: "Total",
      key: "totalDayOff",
      render: (record) => calculateDiff(record.fromDate, record.toDate),
    },
    {
      title: "Reason",
      dataIndex: "reason",
      key: "reason",
      render: (text) => <span className="line-clamp">{text}</span>,
    },
    {
      title: "Create At",
      key: "createdAt",
      dataIndex: "createdAt",
      render: (text) => text !== null && parseDate(text),
    },

    {
      title: "Status",
      key: "approved",
      dataIndex: "approved",
      render: (status) => {
        if (status === null) {
          return <Tag color="blue">Pending</Tag>;
        }
        if (status) {
          return <Tag color="green">Approved</Tag>;
        } else {
          return <Tag color="volcano">Denied</Tag>;
        }
      },
    },
    {
      title: "Action",
      key: "action",
      render: (record) => (
        <Space size="middle">
          <Button
            type="primary"
            shape="circle"
            icon={<EyeOutlined />}
            // onClick={() => onViewData(record)}
          />
          {record.approved === null && (
            <>
              <Button
                type="primary"
                shape="circle"
                icon={<EditOutlined />}
                // onClick={() => onEditData(record)}
              />
              <Popconfirm
                placement="bottomLeft"
                title={"Bạn chắc chắn muốn xóa dữ liệu này?"}
                // onConfirm={() => onDeleteData(record.id)}
              >
                <Button
                  type="danger"
                  shape="circle"
                  icon={<DeleteOutlined />}
                />
              </Popconfirm>
            </>
          )}
        </Space>
      ),
    },
  ];
  const onHandleList = (data) => {
    console.log("run:", data);
    const newList = [...myLeaveRequests];
    newList.unshift(data);
    setMyLeaveRequests(newList);
  };

  return (
    <>
      <Header />
      <div className="container">
        <h2>My Leave Requests</h2>
        <AddLeaveRequest requester={requester} onUpdateList={onHandleList} />
        <TableData columns={columns} dataSource={renderList} />
      </div>
    </>
  );
};

export default EmployeeScreen;
