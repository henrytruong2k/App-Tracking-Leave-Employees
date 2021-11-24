import { DeleteOutlined, EditOutlined, EyeOutlined } from "@ant-design/icons";
import { Button, Space, Table, Tag, Popconfirm } from "antd";
import React, { useEffect, useState } from "react";
import Header from "../../components/Header";
import TableData from "../../components/TableData";
import useEmployee from "../../hooks/useEmployee";
import AddEmployee from "./components/AddEmployee";
import "./style.css";

const Home = () => {
  const { list } = useEmployee();
  const [renderList, setRenderList] = useState(list);
  useEffect(() => {
    setRenderList(list);
  }, [list]);

  const onViewData = (data) => {
    console.log(data);
  };
  const onEditData = (data) => {
    console.log(data);
  };
  const onDeleteData = (data) => {
    console.log(data);
  };
  const columns = [
    {
      title: "Id",
      dataIndex: "id",
      key: "id",
    },
    {
      title: "Full Name",
      dataIndex: "fullName",
      key: "fullName",
      render: (text) => <a>{text}</a>,
    },
    {
      title: "Date of Birth",
      dataIndex: "dateOfBirth",
      key: "dateOfBirth",
    },
    {
      title: "Email",
      dataIndex: "email",
      key: "email",
    },
    {
      title: "Day off",
      key: "dayoff",
      dataIndex: "dayoff",
      render: (value) => (
        <>
          <Tag color={value > 0 ? "green" : "red"}>{value}</Tag>
        </>
      ),
    },
    {
      title: "Approver",
      key: "approver",
      dataIndex: "approver",
      render: (value) => {
        return {
          props: {
            style: {
              fontWeight: "600",
            },
          },
          children: value?.fullName,
        };
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
            onClick={() => onViewData(record)}
          />
          <Button
            type="primary"
            shape="circle"
            icon={<EditOutlined />}
            onClick={() => onEditData(record)}
          />
          <Popconfirm
            placement="bottomLeft"
            title={"Bạn chắc chắn muốn xóa dữ liệu này?"}
            onConfirm={() => onDeleteData(record.id)}
          >
            <Button type="danger" shape="circle" icon={<DeleteOutlined />} />
          </Popconfirm>
        </Space>
      ),
    },
  ];

  const handleUpdateList = (data) => {
    const newList = [...renderList];
    newList.unshift(data);
    setRenderList(newList);
  };

  return (
    <>
      <Header />
      <div className="container">
        <AddEmployee approvers={renderList} onUpdateList={handleUpdateList} />
        <TableData columns={columns} dataSource={renderList} />
      </div>
    </>
  );
};

export default Home;
