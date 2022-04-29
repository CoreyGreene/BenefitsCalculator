import React, { useState } from "react";
import { useSelector, useDispatch } from "react-redux";

const EmployeeInfo = (props) => {
  const { employeeNameCallBack } = props;
    const [employeeName, setEmployeeName] = useState("");
    const count = useSelector((state) => state.counter.value);

  const style = {
    paddingTop: "10px",
    width: "400px",
  };

  const verifyValueEntered = (event) => {
    var name = event.target.value;
    if (name != "") {
      setEmployeeName(event.target.value);
    }
    employeeNameCallBack(event.target.value);
  };

  return (
    <div style={style}>
      <div class="form-group">
        <label for="employeeName">Employee Name</label>
        <input
          type="name"
          class="form-control"
          id="employeeName"
          aria-describedby="emailHelp"
          placeholder="Full Name"
          onChange={(e) => verifyValueEntered(e)}></input>
          </div>


          <div>
              testing redux counter:
              <span>{count}</span>
              </div>
    </div>
  );
};
export default EmployeeInfo;
