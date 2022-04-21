import React from "react";

/* don't need this component*/
const FamilyInfo = (props) => {
  const { name, nameChangeCallBack } = props;

  const style = {
    paddingTop: "10px",
    width: "400px",
  };

  const nameChangeEventHandler = (event) => {
    nameChangeCallBack(event);
  };

  return (
    <div style={style}>
      <div class="form-group">
        <input
          value={name}
          type="name"
          class="form-control"
          id="employeeName"
          onChange={nameChangeEventHandler()}
          aria-describedby="emailHelp"
          placeholder="Enter Name"></input>
      </div>
    </div>
  );
};
export default FamilyInfo;
