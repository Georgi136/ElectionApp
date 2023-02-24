import React from "react";
import "../styles/Item.css";
import { MdEdit, MdDelete } from "react-icons/md";
export const Item = ({
  member: { id, name, secondName, lastName, EGN, tel },
  handleDelete,
  handleEdit,
}) => {
  return (
    <tr className="trow">
      <td className="prop">{name}</td>
      <td className="prop">{secondName}</td>
      <td className="prop">{lastName}</td>
      <td className="prop">{EGN}</td>
      <td className="prop">{tel}</td>
      <td className="prop">{tel}</td>
      <td className="prop">{tel}</td>
      <td className="prop">{tel}</td>
      <td className="prop">{tel}</td>
      <td className="prop">{tel}</td>

      <td className="prop">
        <button
          className="edit-btn"
          aria-label="edit button"
          onClick={() => handleEdit(id)}
        >
          <MdEdit />
        </button>
        <button
          className="clear-btn"
          aria-label="delete button"
          onClick={() => handleDelete(id)}
        >
          <MdDelete />
        </button>
      </td>
    </tr>
  );
};
