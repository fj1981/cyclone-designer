import React, { Component } from 'react'
import { Provider } from "mobx-react"
import { FocusStyleManager, Divider } from "@blueprintjs/core";
import styled from 'styled-components'
import Store from "./store/Store";
import Toolbar from "./component/Toolbar"
import Content from "./component/Content";
import WinTitle from "./component/WinTitle";
import VariableList from './component/VariableList';
import EditDlg from './component/EditDlg';
import { Rect, IFlowItem, Size } from './component/def.d';
import GlobDef from './global';

require('./App.css')

FocusStyleManager.onlyShowFocusOnTabs();

const store = {
  store: new Store()
}

let tick = 100;
let url = '';
let gc_list: string[] = [];
var prev = Date.now();

function UpdateResImpl(resName: string) {
  fetch(`http://memres.app.local/${resName}?${tick++}`).then(res => {
    return res.blob();
  }).then(blob => {
    if (url) {
      gc_list.push(url);
    }
    var now = Date.now();
    if (now - prev >= 100000 && gc_list.length > 30) {
      gc_list.forEach((val: string) => {
        // URL.revokeObjectURL(val);
      });
      gc_list = [];
      prev = Date.now();
      return;
    }

    url = URL.createObjectURL(blob);
    //store.store.setLiveImgSrc(url);
  }).catch(function (error) {
    console.log('There has been a problem with your fetch operation: ', error.message);
  });
}

function UpdateRes(resName: string, newwidth: number, newheight: number) {
  //UpdateResImpl(resName);
  store.store.SetVideoParam({ width: newwidth, height: newheight, src: `${GlobDef.res_url}${resName}?${tick++}` });
}
(window as any).UpdateRes = UpdateRes;

function UpdateHoverRect(rcs: Rect[], rate: number = 1) {
  //UpdateResImpl(resName);
  store.store.SetHoveerRect(rcs.map(
    e => {
      let ret: Rect = e;
      ret.bottom *= rate;
      ret.left *= rate;
      ret.right *= rate;
      ret.top *= rate;
      return ret
    }));
}
(window as any).UpdateHoverRect = UpdateHoverRect;


function UpdateFlow(proj: string, sz: Size, rate: number) {
  store.store.LoadProject(proj);
}
(window as any).UpdateFlow = UpdateFlow;

function EnableCreateFlowItem() {
  store.store.create_flowitem = false;
}
(window as any).EnableCreateFlowItem = EnableCreateFlowItem;

const AppLayout = styled.div`
  margin:0;
  display: flex;
  flex-direction: column;
  height:100%;
  overflow: hidden; 
`

const Header = styled.header`
  flex: 0 0 20px;
  background-color: rgb(222,225,230);
`


const Footer = styled.footer`
  flex: 0 0 160px;
`

class App extends React.Component {
  // 在这里我们要使用mobx-react里的Provider，
  // 把所有的state注入Provider中，后面的子组件都可以使用@inject("想要使用的state")注入被观察者。
  public render() {
    return (
      <Provider {...store} >
        <AppLayout>
          <Header>
            <WinTitle />
            <Divider />
            <Toolbar />
          </Header>
          <Content />
          <Footer>
            <VariableList />
          </Footer>
        </AppLayout>
        <EditDlg />
      </Provider>
    );
  }
}

export default App;