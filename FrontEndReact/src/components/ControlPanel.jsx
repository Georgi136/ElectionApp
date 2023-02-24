import React from "react";
import { Link } from "react-router-dom";
import "../styles/ControlPanel.css"
export const ControlPanel = () => {

    return(
        <div className="control-panel">
            
            <button className="btn"><Link to="/submitform" replace>Добавяне</Link></button>
            
            <button className="btn">Хронология</button>
            {/* <button className="Edit-btn">Реадктиране</button> */}
        </div>
    )
} 