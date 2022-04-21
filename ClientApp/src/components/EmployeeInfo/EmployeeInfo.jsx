import React, { useState } from "react";

const EmployeeInfo = (props) => {
  //var displayName = Home.name;

  const { employeeNameCallBack } = props;
  const [employeeName, setEmployeeName] = useState("");

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
    </div>
  );
};
export default EmployeeInfo;

/*
export class Home extends Component {
  static displayName = Home.name;

    // code blow works
    /*
    componentDidMount() {
        this.populateWeatherData();
    }
    async populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
    */
