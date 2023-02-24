import React, { useState } from "react";
import uuid from "uuid/v4";
import "../styles/AddForm.css";
export const AddForm = ({ SetMembers, members }) => {
  const [name, setName] = useState("");
  const [secondName, setSecondName] = useState("");
  const [lastName, setLastName] = useState("");
  const [EGN, setEGN] = useState("");
  const [tel, setTel] = useState("");
  // const [pass, setPass] = useState('');

  const HandleSubmit = (e) => {
    e.preventDefault();
    const formObject = {
      id: uuid(),
      name,
      secondName,
      lastName,
      EGN,
      tel,
    };
    console.log(formObject);
    console.log(members);
    console.log(formObject);
    SetMembers([...members, formObject]);
  };

  return (
    <div className="add-form-container">
      <form className="add-form" onSubmit={HandleSubmit}>
        <h1>Член на СИК</h1>
        <div className="form-container">
          <div className="first-row">
            <label for="name">Име</label>
            <input
              value={name}
              onChange={(e) => setName(e.target.value)}
              type="text"
              placeholder="Име"
            />
            <label for="name2">Презиме</label>
            <input
              value={secondName}
              onChange={(e) => setSecondName(e.target.value)}
              type="text"
              placeholder="Бащино име"
            />
            <label for="name3">Фамилия</label>
            <input
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
              type="text"
              placeholder="Фамилия"
            />
          </div>
          <div className="second-row">
            <label for="EGN">ЕГН</label>
            <input
              value={EGN}
              onChange={(e) => setEGN(e.target.value)}
              type="text"
              placeholder="ЕГН"
            />
            <label for="Tel">Телефон</label>
            <input
              value={tel}
              onChange={(e) => setTel(e.target.value)}
              type="text"
              placeholder="Телефон"
            />
          </div>
        </div>
        <button className="button-form" type="submit">
          Въведи
        </button>
      </form>
    </div>
  );
};
