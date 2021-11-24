import { DatePicker, Tag } from "antd";
import moment from "moment";
import React, { useEffect, useState } from "react";
import leaveAPI from "../../api/leaveAPI";
import Header from "../../components/Header";
import TableData from "../../components/TableData";
import { monthFormat } from "../../configs/configs";
import LoadingScreen from "../../components/LoadingScreen";

const ChartScreen = () => {
  const [list, setList] = useState([]);
  const [loading, setLoading] = useState(false);
  useEffect(() => {
    (async () => {
      try {
        setLoading(true);
        const data = await leaveAPI.getAll();
        console.log(data);
        setList(data);
      } catch (error) {
        console.log(error);
      }
      setLoading(false);
    })();
  }, []);

  const onChange = async (date, dateString) => {
    const [month, year] = dateString.split("/");
    try {
      setLoading(true);
      const data = await leaveAPI.getAll({ month, year });
      setList(data);
    } catch (error) {
      console.log(error);
    }
    setLoading(false);
  };
  const parseDate = (date) => {
    return moment(new Date(date)).format("MM/DD/YYYY");
  };
  const calculateDiff = (from, to) => {
    const start = moment(from);
    const end = moment(to);
    return end.diff(start, "days");
  };

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
      title: "Date Actioned",
      key: "dateActioned",
      dataIndex: "dateActioned",
      render: (text) => parseDate(text),
    },
  ];

  return (
    <>
      {loading && <LoadingScreen />}
      <Header />
      <div className="container">
        <div style={{ marginTop: "20px" }}>
          <DatePicker
            onChange={onChange}
            format={monthFormat}
            picker="month"
            style={{
              marginBottom: "20px",
            }}
          />
          <TableData columns={columns} dataSource={list} />
        </div>
      </div>
    </>
  );
};

export default ChartScreen;
