import { BellOutlined, DownOutlined } from "@ant-design/icons";
import { Badge, Dropdown, Menu } from "antd";
import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { NavLink, useNavigate } from "react-router-dom";
import { logout } from "../../actions/userActions";
import "./style.css";

const Header = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const userLogin = useSelector((state) => state.userLogin);
  const { userInfo } = userLogin;
  const logoutHandler = () => {
    dispatch(logout());
    navigate("/login");
  };
  const onEmployeePage = () => {
    navigate("/employee");
  };
  const menu = (
    <Menu>
      <Menu.Item key="0" onClick={onEmployeePage}>
        Profile
      </Menu.Item>
      <Menu.Divider />
      <Menu.Item key="1" onClick={logoutHandler}>
        Logout
      </Menu.Item>
    </Menu>
  );
  const onApprovePage = () => {
    navigate("/approve-page");
  };
  return (
    <header>
      <div className="container">
        <div className="header__container">
          <h3>IT COMPANY</h3>
          <ul>
            <li>
              <NavLink to="/charts">Charts</NavLink>
            </li>
          </ul>
          {userInfo && (
            <div style={{ display: "flex" }}>
              <div
                style={{ marginRight: "15px", cursor: "pointer" }}
                onClick={onApprovePage}
              >
                <Badge count={0}>
                  <BellOutlined style={{ fontSize: "20px" }} />
                </Badge>
              </div>
              <Dropdown overlay={menu} trigger={["click"]}>
                <b style={{ cursor: "pointer" }}>
                  {userInfo.fullName} ({userInfo.role}) <DownOutlined />
                </b>
              </Dropdown>
            </div>
          )}
        </div>
      </div>
    </header>
  );
};

export default Header;
