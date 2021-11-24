import { useEffect, useState } from "react";
import employeeAPI from "../api/employeeAPI";

const useEmployee = () => {
  const [list, setList] = useState([]);

  useEffect(() => {
    (async () => {
      try {
        const data = await employeeAPI.getAll();
        setList(data);
      } catch (error) {
        console.log(error);
      }
    })();
  }, []);
  return { list, setList };
};

export default useEmployee;
