import React, { useState } from "react";
import "../styles/AddForm.css";
export const AddForm = ({ SetMembers, members }) => {
  const [firstName, setName] = useState("");
  const [secondName, setSecondName] = useState("");
  const [thirdName, setLastName] = useState("");
  const [egn, setEGN] = useState("");
  const [phoneNumber, setTel] = useState("");
  // const [pass, setPass] = useState('');

  const HandleSubmit = async (e) => {
    e.preventDefault();
    const formObject = {
      firstName,
      secondName,
      thirdName,
      egn,
      education: "sredno",
      phoneNumber,
    };
    await fetch("https://localhost:7131/Members", {
      method: "POST",
      body: JSON.stringify(formObject),
      headers: {
        "Content-Type": "application/json; charset=utf-8",
      },
    })
      .then((respones) => respones.json())
      .then((data) => {
        console.log(data);
      })
      .catch((err) => {
        console.error(err);
      });
  };

  return (
    <div className="add-form-container">
      <form className="add-form" onSubmit={HandleSubmit}>
        <h1>Член на СИК</h1>
        <div className="form-container">
          <div className="first-row">
            <label for="name">Име</label>
            <input
              value={firstName}
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
              value={thirdName}
              onChange={(e) => setLastName(e.target.value)}
              type="text"
              placeholder="Фамилия"
            />
          </div>
          <div className="second-row">
            <label for="EGN">ЕГН</label>
            <input
              value={egn}
              onChange={(e) => setEGN(e.target.value)}
              type="text"
              placeholder="ЕГН"
            />
            <label for="Tel">Телефон</label>
            <input
              value={phoneNumber}
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
