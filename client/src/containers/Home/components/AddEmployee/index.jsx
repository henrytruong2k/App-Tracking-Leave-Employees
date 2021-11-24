import { PlusOutlined } from "@ant-design/icons";
import {
  Button,
  DatePicker,
  Form,
  Input,
  InputNumber,
  Modal,
  Select,
  message,
} from "antd";
import React, { useState } from "react";
import employeeAPI from "../../../../api/employeeAPI";
import { layout, validateMessages } from "../../../../configs/configs";

const { Option } = Select;

const AddEmployee = ({ approvers, onUpdateList }) => {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [dateOfBirth, setDateOfBirth] = useState("");
  const showModal = () => {
    setIsModalVisible(true);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };

  const [form] = Form.useForm();

  const onReset = () => {
    form.resetFields();
  };

  const onFinish = async (values) => {
    const { user } = values;
    const params = { ...user, dateOfBirth };
    if (!onDateChange) return;
    try {
      const data = await employeeAPI.add(params);
      if (data) {
        onUpdateList(data);
        message.success("Created successfully");
        onReset();
      }
    } catch (error) {
      console.log(error);
    }
  };

  const onDateChange = (...rest) => {
    const [, date] = rest;
    setDateOfBirth(date);
  };

  return (
    <div className="container">
      <h2>HR View</h2>
      <Button
        type="primary"
        onClick={showModal}
        style={{ marginBottom: "20px" }}
      >
        <PlusOutlined />
        Add New Employee
      </Button>

      <Modal
        title="Add New Employee"
        visible={isModalVisible}
        centered
        footer={null}
        onCancel={handleCancel}
      >
        <Form
          {...layout}
          name="nest-messages"
          form={form}
          onFinish={onFinish}
          validateMessages={validateMessages}
        >
          <Form.Item
            name={["user", "fullName"]}
            label="FullName"
            rules={[{ required: true, message: "Please input Full Name" }]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            name={["user", "dateOfBirth"]}
            label="Date of Birth"
            rules={[{ required: true, message: "Please input Date of Birth" }]}
          >
            <DatePicker onChange={onDateChange} />
          </Form.Item>

          <Form.Item
            name={["user", "address"]}
            label="Address"
            rules={[{ required: true, message: "Please input Address" }]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            name={["user", "email"]}
            label="Email"
            rules={[
              {
                type: "email",
                message: "The input is not valid E-mail!",
              },
              {
                required: true,
                message: "Please input E-mail!",
              },
            ]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            name={["user", "password"]}
            label="Password"
            rules={[{ required: "true", message: "Please input password!" }]}
            initialValue="1234"
            tooltip="Default is 1234"
          >
            <Input.Password />
          </Form.Item>

          <Form.Item
            name={["user", "dayoff"]}
            label="Day off"
            rules={[
              {
                type: "number",
                min: 0,
                max: 12,
                required: "true",
                message: "Please input day off!",
              },
            ]}
          >
            <InputNumber />
          </Form.Item>

          <Form.Item
            name={["user", "role"]}
            label="Role"
            rules={[{ required: true, message: "Please select Role!" }]}
          >
            <Select placeholder="Select Role">
              <Option value="HR">HR</Option>
              <Option value="Employee">Employee</Option>
            </Select>
          </Form.Item>

          <Form.Item
            name={["user", "approverId"]}
            label="Approver"
            rules={[{ required: true, message: "Please select Approver!" }]}
          >
            <Select placeholder="Select Approver">
              {approvers.map((approver) => (
                <Option key={approver.id} value={approver.id}>
                  {approver.fullName}
                </Option>
              ))}
            </Select>
          </Form.Item>

          <Form.Item wrapperCol={{ ...layout.wrapperCol, offset: 8 }}>
            <Button type="primary" htmlType="submit">
              Submit
            </Button>
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default AddEmployee;
