import React from "react";
import { Link } from "react-router-dom";
import { ControlPanel } from "./ControlPanel"
import "../styles/Header.css"

export const Header = () => {
    return(
    <div className="header-style">
        <Link to="/home" replace><p>Избори за народни представители<br></br> 2 Април 2023 г.</p></Link>
        <ControlPanel/>
    </div>
    )
}