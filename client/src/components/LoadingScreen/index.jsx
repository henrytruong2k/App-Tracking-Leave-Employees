import React from "react";
import { Spin } from "antd";
import "./style.css";

const LoadingScreen = () => {
  return (
    <div className="loader">
      <div className="loader__container">
        <Spin size="large" />
      </div>
    </div>
  );
};

export default LoadingScreen;
