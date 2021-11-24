import React from "react";
import { Alert } from "antd";

const ErrorAlert = ({ message }) => {
  return (
    <div style={{ marginBottom: "20px" }}>
      <Alert message={message} type="error" />
    </div>
  );
};

export default ErrorAlert;
