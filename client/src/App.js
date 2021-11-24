import { useSelector } from "react-redux";
import { Route, Routes } from "react-router-dom";
import Header from "./components/Header";
import { USER_ROLE_HR } from "./constants/userConstants";
import ApproveScreen from "./containers/ApproveScreen";
import ChartScreen from "./containers/ChartScreen";
import EmployeeScreen from "./containers/EmployeeScreen";
import Home from "./containers/Home";
import Login from "./containers/Login";
import NotFound from "./containers/NotFound";
import { PrivateRoute } from "./utils/PrivateRoute";

function App() {
  const userLogin = useSelector((state) => state.userLogin);
  const { userInfo } = userLogin;
  return (
    <Routes>
      <Route path="*" element={<NotFound />} />
      <Route exact path="/" element={<PrivateRoute />}>
        <Route path="/" element={<Home />} />
        <Route path="/employee" element={<EmployeeScreen />} />
        <Route path="/approve-page" element={<ApproveScreen />} />
        <Route path="/charts" element={<ChartScreen />} />
      </Route>
      <Route path="/login" element={<Login />} />
    </Routes>
  );
}

export default App;
