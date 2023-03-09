import React from "react";
import "../styles/Item.css";
import { MdEdit, MdDelete } from "react-icons/md";
export const Item = ({
  member: { id, firstName, secondName, thirdName, egn, phoneNumber },
  handleDelete,
  handleEdit,
}) => {
  return (
    <tr className="trow">
      <td className="prop">{firstName}</td>
      <td className="prop">{secondName}</td>
      <td className="prop">{thirdName}</td>
      <td className="prop">{egn}</td>
      <td className="prop">{phoneNumber}</td>
      <td className="prop">{phoneNumber}</td>
      <td className="prop">{phoneNumber}</td>
      <td className="prop">{phoneNumber}</td>
      <td className="prop">{phoneNumber}</td>
      <td className="prop">{phoneNumber}</td>

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
