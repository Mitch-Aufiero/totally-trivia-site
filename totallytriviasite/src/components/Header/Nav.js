import React from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faHome, faGamepad, faEnvelope, faUser } from '@fortawesome/free-solid-svg-icons'



export default class Nav extends React.Component {


    render() {
        return (
            <ul>
                 <li><a className="active" href="#home">These <FontAwesomeIcon icon={faHome} /></a></li>
                 <li><a href="#play">Do <FontAwesomeIcon icon={faGamepad} /></a></li>
                 <li><a href="#contact">Not <FontAwesomeIcon icon={faEnvelope} /></a></li>
                 <li><a href="#about">Work <FontAwesomeIcon icon={faUser} /></a></li>
            </ul>

        )
    }
}