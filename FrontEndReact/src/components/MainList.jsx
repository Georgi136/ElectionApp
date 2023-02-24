import React from "react";
import { Item } from "./Item";

export const MainList = ({ members, handleDelete, handleEdit }) => {
  console.log(members);
  return (
    <>
      <table className="table">
        <tr>
          <th className="prop">Име</th>
          <th className="prop">Презиме</th>
          <th className="prop">Фамилия</th>
          <th className="prop">ЕГН</th>
          <th className="prop">Телефон</th>
          <th className="prop">Телефон</th>
          <th className="prop">Телефон</th>
          <th className="prop">Телефон</th>
          <th className="prop">Телефон</th>
          <th className="prop">Телефон</th>
          <th className="prop">Поправи/Изтрий</th>
        </tr>
        {members.map((member, index) => {
          return (
            <Item
              key={index}
              member={member}
              handleDelete={handleDelete}
              handleEdit={handleEdit}
            />
          );
        })}
      </table>
    </>
  );
};
