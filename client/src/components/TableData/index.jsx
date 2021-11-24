import { Table } from "antd";
import React from "react";

const TableData = ({ columns, dataSource }) => {
  return (
    <Table
      columns={columns}
      dataSource={dataSource}
      rowKey={(record) => record.id}
    />
  );
};

export default TableData;
