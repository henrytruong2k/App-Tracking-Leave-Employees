import { PlusOutlined } from "@ant-design/icons";
import {
  Button,
  DatePicker,
  Form,
  Input,
  message,
  Modal,
  Select,
  Alert,
} from "antd";
import React, { useState } from "react";
import { useSelector } from "react-redux";
import leaveAPI from "../../../../api/leaveAPI";
import ErrorAlert from "../../../../components/ErrorAlert";
import LoadingScreen from "../../../../components/LoadingScreen";
import { layout, validateMessages } from "../../../../configs/configs";

const { Option } = Select;
const { TextArea } = Input;
const AddLeaveRequest = ({ requester, onUpdateList }) => {
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);
  const userLogin = useSelector((state) => state.userLogin);
  const { userInfo } = userLogin;
  const [isModalVisible, setIsModalVisible] = useState(false);
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
    const params = { ...user, createdById: userInfo?.id };
    try {
      setLoading(true);
      const data = await leaveAPI.add(params);
      console.log("data: ", data);
      if (data) {
        onUpdateList(data);
        message.success("Created successfully");
        onReset();
      }
    } catch (error) {
      setError(error.message);
    }
    setLoading(false);
  };

  return (
    <>
      {loading && <LoadingScreen />}
      <div className="container">
        <Button
          type="primary"
          onClick={showModal}
          style={{ marginBottom: "20px" }}
        >
          <PlusOutlined />
          Add New Leave Request
        </Button>

        <Modal
          title="Add New Leave Request"
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
            {error && <ErrorAlert message={error} />}
            <Form.Item
              name={["user", "fromDate"]}
              label="From Date"
              rules={[{ required: true, message: "Please input From date" }]}
            >
              <DatePicker />
            </Form.Item>
            <Form.Item
              name={["user", "toDate"]}
              label="To Date"
              rules={[{ required: true, message: "Please input To date" }]}
            >
              <DatePicker />
            </Form.Item>
            <Form.Item
              name={["user", "requestedById"]}
              label="Requester"
              rules={[{ required: true, message: "Please select Requester!" }]}
            >
              <Select placeholder="Select Requester">
                <Option value={requester?.id}>{requester?.fullName}</Option>
              </Select>
            </Form.Item>

            <Form.Item
              name={["user", "reason"]}
              label="Reason"
              rules={[{ required: true, message: "Please input Reason!" }]}
            >
              <TextArea rows={4} />
            </Form.Item>

            <Form.Item wrapperCol={{ ...layout.wrapperCol, offset: 8 }}>
              <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
          </Form>
        </Modal>
      </div>
    </>
  );
};

export default AddLeaveRequest;
