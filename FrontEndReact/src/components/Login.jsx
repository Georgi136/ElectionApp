import React, { useState } from "react";
import "../styles/Login.css";

export const Login = () => {
  const [name, setName] = useState("");
  const [pass, setPass] = useState("");

  const HandleSubmit = (e) => {
    e.preventDefault();
    console.log(name);
  };
  return (
    <div className="login-container">
      <form className="login-form" onSubmit={HandleSubmit}>
        <label for="name">Партия/Полит.Група</label>
        <input
          value={name}
          onChange={(e) => setName(e.target.value)}
          type="name"
          placeholder="Партия/Полит.Група"
        />
        <label for="password">Парола</label>
        <input
          value={pass}
          onChange={(e) => setPass(e.target.value)}
          type="password"
          placeholder="Парола"
        />
        <br></br>
        <button className="" type="submit">
          Влизане
        </button>
      </form>
    </div>
  );
};
