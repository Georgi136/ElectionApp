import React from "react";
import "./styles/App.css";
import { Login } from "./components/Login";
import { Header } from "./components/Header";
import { MainPanel } from "./components/MainPanel";
import { AddForm } from "./components/AddForm";
import { Route, Routes } from "react-router-dom";
import { useState, useEffect } from "react";
import uuid from "uuid/v4";

const initilaMembers = [
  {
    id: uuid(),
    name: "test",
    secondName: "test",
    lastName: "Tste1",
    EGN: "0145134844",
    tel: "0896658248",
  },
  {
    id: uuid(),
    name: "tesdsdfs,mst",
    secondName: "test,ms.,vnsd.",
    lastName: "Tstdddde1",
    EGN: "0145134844",
    tel: "0896658248",
  },
  {
    id: uuid(),
    name: "sdsdfs,mst",
    secondName: "test,ms.,vnsd.",
    lastName: "tdddde1",
    EGN: "0145134844",
    tel: "0896658248",
  },
];

function App() {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [members, SetMembers] = useState(initilaMembers);
  // handelDeleate
  const handleDelete = (id) => {
    let tempMembers = members.filter((m) => m.id !== id);
    SetMembers(tempMembers);
  };
  const handleEdit = (id) => {
    console.log("edited");
  };
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
      </Routes>
    </div>
  );
}

export default App;
