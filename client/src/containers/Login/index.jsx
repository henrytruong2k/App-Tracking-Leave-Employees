import { Alert, Button, Checkbox, Form, Input } from "antd";
import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { login } from "../../actions/userActions";
import LoadingScreen from "../../components/LoadingScreen";
import { USER_ROLE_HR } from "../../constants/userConstants";
import "./style.css";

const Login = () => {
  const isEmpty = (str) => {
    return !str || str.length === 0;
  };

  const dispatch = useDispatch();
  const userLogin = useSelector((state) => state.userLogin);
  const { loading, error, userInfo } = userLogin;
  const navigate = useNavigate();
  useEffect(() => {
    if (userInfo) {
      if (userInfo.role === USER_ROLE_HR) {
        navigate("/");
      } else {
        navigate("/employee");
      }
    }
  }, [dispatch, userInfo, navigate]);

  const onFinish = async (values) => {
    const { email, password } = values;
    if (!isEmpty(email) && !isEmpty(password)) {
      dispatch(login(email, password));
    }
  };

  return (
    <>
      {loading && <LoadingScreen />}
      <div className="form__layout">
        <div className="form__container">
          {error && (
            <Alert message="Error" description={error} type="error" showIcon />
          )}
          <Form
            name="basic"
            labelCol={{ span: 8 }}
            wrapperCol={{ span: 16 }}
            initialValues={{ remember: true }}
            onFinish={onFinish}
            autoComplete="off"
          >
            <h1>LOGIN</h1>
            <Form.Item
              label="Email"
              name="email"
              rules={[{ required: true, message: "Please input your email!" }]}
            >
              <Input />
            </Form.Item>

            <Form.Item
              label="Password"
              name="password"
              rules={[
                { required: true, message: "Please input your password!" },
              ]}
            >
              <Input.Password />
            </Form.Item>

            <Form.Item
              name="remember"
              valuePropName="checked"
              wrapperCol={{ offset: 8, span: 16 }}
            >
              <Checkbox>Remember me</Checkbox>
            </Form.Item>

            <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
              <Button type="primary" htmlType="submit">
                Sign in
              </Button>
            </Form.Item>
          </Form>
        </div>
      </div>
    </>
  );
};

export default Login;
