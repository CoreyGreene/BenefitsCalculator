import React, { useState } from "react";
import { EmployeeInfo } from "../../components/EmployeeInfo";

const BenefitsCalculatorLayout = (props) => {
  const generalPadding = {
    paddingLeft: "30px",
    paddingTop: "80px",
  };

  const inputStyle = {
    paddingTop: "10px",
    width: "400px",
  };

  const [includeFamily, setIncludeFamily] = useState(false);
  const [employeeName, setEmployeeName] = useState("");
  const [benefitsCost, setBenefitsCost] = useState(0);
  const [familyData, setFamilyData] = useState([{ name: "initial" }]);

  const IncludeFamily = () => {
    setIncludeFamily(!includeFamily);
  };

  const ShowFamilyInfo = () => {
    return (
      <div>
        <ul>
          {familyData.map((r) => (
            <li>
              <div style={inputStyle}>
                <input
                  type="name"
                  class="form-control"
                  id="employeeName"
                  onChange={(e) => {
                    r.name = e.target.value;
                  }}
                  aria-describedby="emailHelp"
                  placeholder="Enter Name"></input>
              </div>
            </li>
          ))}
        </ul>
      </div>
    );
  };

  const AddMoreRows = () => {
    setFamilyData([...familyData, { name: "test" }]);
  };

  function CurrencyFormat() {
    return (
      "$" + benefitsCost.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
    );
  }

  const CalculateBenefitsCost = async () => {
    //OMG is this hackey and wrong on so many levels, but newtonsoft dynamic json to object conversion was not playing nice today
    var delmitedStringOfNames =
      employeeName +
      "," +
      familyData
        .map(function (val) {
          return val.name;
        })
        .join(",");

    fetch(`BenefitsCalculator?data=${delmitedStringOfNames}`)
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          console.log("bad");
        }
      })
      .then((myJson) => {
        setBenefitsCost(myJson.cost);
      });
  };

  const employeeNameCallBack = (name) => {
    setEmployeeName(name);
  };

  return (
    <div style={generalPadding}>
      <div class="container">
        <div class="row">
          <div class="col-sm">
            <form style={{ height: "400px" }}>
              <EmployeeInfo employeeNameCallBack={employeeNameCallBack} />

              <div style={{ paddingTop: "30px" }}>
                <input
                  type="checkbox"
                  onClick={() => IncludeFamily()}
                  class="form-check-input"
                  id="additionalFamily"></input>
                <label class="form-check-label" for="additionalFamily">
                  Add additional family members
                </label>
              </div>

              {includeFamily ? ShowFamilyInfo() : null}
            </form>
          </div>

          <div class="col-sm">
            <div style={{ paddingTop: "35px" }}>
              <button
                onClick={AddMoreRows}
                type="submit"
                class="btn btn-primary">
                AddMoreRows
              </button>
              <div style={{ display: "inline-block", paddingLeft: "100px" }}>
                <button
                  type="submit"
                  onClick={() => CalculateBenefitsCost()}
                  disabled={employeeName == ""}
                  class="btn btn-primary"
                  style={{ alight: "right" }}>
                  Calculate
                </button>
              </div>
            </div>
            <div style={{ paddingTop: "25px" }}>
              <h2> Total Benefits Price: {CurrencyFormat()}</h2>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default BenefitsCalculatorLayout;