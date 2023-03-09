import React from "react";
import "./styles/App.css";
import { Login } from "./components/Login";
import { Header } from "./components/Header";
import { MainPanel } from "./components/MainPanel";
import { AddForm } from "./components/AddForm";
import { Navigate, Route, Routes } from "react-router-dom";
import { useState, useEffect } from "react";
import uuid from "uuid/v4";

const initilaMembers = [];

function App() {
  const [members, SetMembers] = useState(initilaMembers);
  // handelDeleate
  const handleDelete = async (id) => {
    await fetch(`https://localhost:7131/Members/${id}`, {
      method: "DELETE",
    })
      .then((respones) => respones.json())
      .then((data) => {
        console.log(data);
      })
      .catch((err) => {
        console.error(err);
      });
  };
  const handleEdit = (id) => {
    console.log("edited");
  };

  const getMembers = async () => {
    const response = await fetch("https://localhost:7131/Members");
    return response.json();
  };

  useEffect(() => {
    // createMember().then((r) => r.status);
    getMembers().then((r) => console.log(r));
    getMembers().then((r) => SetMembers(r));
  }, [members]);

  return (
    <div className="App">
      <Routes>
        <Route path="/login" element={<Login />}></Route>
        <Route
          path="/home"
          element={
            <>
              <Header />
              <MainPanel
                members={members}
                handleDelete={handleDelete}
                handleEdit={handleEdit}
              />
            </>
          }
        ></Route>
        <Route
          path="/submitform"
          element={
            <>
              <Header />
              <AddForm SetMembers={SetMembers} members={members} />
            </>
          }
        ></Route>
        <Route path="/" element={<Navigate to="/home" />}></Route>
      </Routes>
    </div>
  );
}

export default App;
