import React, { Component } from 'react'
import { observer, inject } from 'mobx-react'
import styled from 'styled-components'
import logo from '../resource/logo.png';

require('../resource/WinTitle.css')

const Header = styled.header`
  flex: 0 0 20px;
  display: flex;
  -webkit-app-region: drag;
`

const Logo = styled.div`
  width: 100px;
  background: url(${logo}) no-repeat
  background-size: 100% 100%
  margin:2px 10px
`
const TitleText = styled.div`
  display: flex;
  flex: 1;
  align-items:center;
  justify-content:center;
`

const AppSysCommandContainer = styled.div`
		display: flex;
		-webkit-app-region: drag;
    justify-content: flex-end;
`

const SysCommands = styled.ul`
    list-style: none inside;
    padding: 0;
    margin: 0;
    height: 32px;
    -webkit-app-region: no-drag;
    display: flex;
`

const SysCommandsLi = styled.li.attrs(
  {
    'n-ui-command':(props:{'ui-command':string})=>props['ui-command']
  })`
    display: inline-flex;
    width: 32px;
    background-color: transparent;
    color: #000000;
    align-items: center;
    justify-content: center;
    transition: all ease-in-out 300ms;
    font-size: 0.8em;
    &:hover {
      background-color:rgb(199,202,207);
    }
`


@inject('store')
@observer
export default class WinTitle extends Component <any,{isMaximized:boolean}>{
  static propTypes = {
  }
  constructor(props:any) {
    super(props);
    this.state = { isMaximized: false};
  }
  render() {
    return (
      <Header>
        <Logo />
        <TitleText>Cyclone RPA Personal</TitleText>
        <AppSysCommandContainer>
          <SysCommands>
            <li className="syscmd" n-ui-command ="minimize">
              <svg x="0px" y="0px" viewBox="0 0 10.2 1" data-radium="true" style={{ width: "10px", height: "1px" }}>
                <rect width="10.2" height="1" />
                </svg>
            </li>
            <li className="syscmd" n-ui-command ="restore" style={{display:this.state.isMaximized?"flex":"none"}}>
            <svg x="0px" y="0px" viewBox="0 0 10.2 10.2" data-radium="true" style={{ width: "10px", height: "10px" }}>
              <path fill="rgba(0, 0, 0, .4)" d="M2.1,0v2H0v8.1h8.2v-2h2V0H2.1z M7.2,9.2H1.1V3h6.1V9.2z M9.2,7.1h-1V2H3.1V1h6.1V7.1z" />
            </svg>
            </li>
            <li className="syscmd" n-ui-command ="maximize" style={{display:this.state.isMaximized?"none":"flex"}}>
              <svg x="0px" y="0px" viewBox="0 0 10.2 10.1" data-radium="true"  style={{ width: "10px", height: "10px",strokeWidth:4 }}>
                <path  d="M0,0v10.1h10.2V0H0z M9.2,9.2H1.1V1h8.1V9.2z" />
              </svg>
            </li>
            <li className="sysclosecmd" n-ui-command ="close">
              <svg x="0px" y="0px" viewBox="0 0 10.2 10.2" data-radium="true"  style={{ width: "10px", height: "10px" }}>
                <polygon points="10.2,0.7 9.5,0 5.1,4.4 0.7,0 0,0.7 4.4,5.1 0,9.5 0.7,10.2 5.1,5.8 9.5,10.2 10.2,9.5 5.8,5.1 " />
              </svg>
            </li>
          </SysCommands>
        </AppSysCommandContainer>
      </Header>
    )
  }
}


