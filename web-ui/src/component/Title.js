import React, { Component } from "react";
import PropTypes from "prop-types";
import { observer, inject } from "mobx-react";
import { nav, Icon } from "@blueprintjs/core";
import styled from "styled-components";
import logo from "./add.svg";




export default class extends Component {
  constructor(props) {
    super(props);
    this.state = { isMaximized: true };
  }

  render() {
    return (
      <nav className='bp3-navbar .modifier'>
        <div className='bp3-navbar-group bp3-align-left'>
          <div className='bp3-navbar-heading'>Blueprint</div>
          <input className='bp3-input' placeholder='Search files...' type='text' />
        </div>
        <div className='bp3-navbar-group bp3-align-right app-sys-command-container'>
				
        </div>
      </nav>
    );
  }
}

// @inject('store')
// @observer
// export default class Title extends Component <IProps, {}> {
//   static propTypes = {
//   }

//   render() {
//     return (
//       <div>

//       </div>
//     )
//   }
// }
