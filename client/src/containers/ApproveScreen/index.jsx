import React, { useEffect } from "react";
import Header from "../../components/Header";
import leaveAPI from "../../api/leaveAPI";
import { useSelector } from "react-redux";

const ApproveScreen = () => {
  const userLogin = useSelector((state) => state.userLogin);
  const { userInfo } = userLogin;
  useEffect(() => {
    (async () => {
      const data = await leaveAPI.getApproveList(userInfo?.id);
      console.log("approve list: ", data);
    })();
  }, [userInfo]);
  return (
    <>
      <Header />
    </>
  );
};

export default ApproveScreen;
