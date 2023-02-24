import React from "react";
import { MainList } from "./MainList";
export const MainPanel = ({ members, handleDelete, handleEdit }) => {
  return (
    <div className="parent">
      <div className="div2">
        <MainList
          members={members}
          handleDelete={handleDelete}
          handleEdit={handleEdit}
        />
      </div>
      <div className="div3">test log</div>
    </div>
  );
};
