import React from 'react'
import { observer, inject } from 'mobx-react'
import { ButtonGroup, Button } from '@blueprintjs/core/lib/esm/components'
import { IProps } from '../store/Store'
import styled from 'styled-components'
import { test_str } from '../resource/test'
import { BUTTON_ID, BUTTON_STATE } from './def.d'


const ToolbarWapper = styled.div`
  padding: 10px;
  background-color: rgb(222,225,230);
`

@inject('store')
@observer
export default class Toolbar extends React.Component<IProps, {}> {

  private LoadImg() {
    console.log('333333');
    this.props.store!.SetVideoParam({ width: 512, height: 512, src: `/logo512.png` });
    // fetch('http://memres.app.local/live.png').then(res => {     
    //   return res.blob();
    // }).then(blob => {
    //   console.log(typeof blob);
    //   let url=URL.createObjectURL(blob);
    //   this.props.store!.setLiveImgSrc(url);
    // }).catch(function(error) {
    //   console.log('There has been a problem with your fetch operation: ', error.message);
    // });
  }

  private ExcuteCmd(funcName: string) {
    if (funcName === 'OnOpenFile') {
      this.OnOpenFile();
      return;
    }
   // this.LoadImg();
    let funcstr = `
    if(window.${funcName}) {
      window.${funcName}();}
    `;
    eval(funcstr);
  }

  private OnOpenFile() {
    this.props.store?.LoadProject(test_str)
  }

  private btnState = (e: BUTTON_ID) => {
    let state = this.props.store?.button_state[e];
    if (!state) {
      return false;
    }
    return state == BUTTON_STATE.BTN_ENABLE;
  }

  render() {
    return (
      <ToolbarWapper >
        <ButtonGroup >
          <Button
            disabled={!this.btnState(BUTTON_ID.BUTTON_NEW)}
            style={{ marginLeft: 3 }}
            onClick={() => this.ExcuteCmd('OnNewFile')}
            icon="document"
            className="bp3-large" />
          <Button
            disabled={!this.btnState(BUTTON_ID.BUTTON_OPEN)}
            style={{ marginLeft: 3 }}
            onClick={() => this.ExcuteCmd('OnOpenFile')}
            icon="document-open"
            className="bp3-large" />
          <Button
            disabled={!this.btnState(BUTTON_ID.BUTTON_SAVE)}
            style={{ marginLeft: 3 }}
            onClick={() => this.ExcuteCmd('OnSaveFile')}
            icon="floppy-disk"
            className="bp3-large" />
        </ButtonGroup>
        <ButtonGroup style={{ marginLeft: 5 }} >
          <Button
            disabled={!this.btnState(BUTTON_ID.BUTTON_RUN)}
            style={{ marginLeft: 3 }}
            onClick={() => this.ExcuteCmd('OnRun')}
            icon="play"
            className="bp3-large" />
          <Button
            disabled={!this.btnState(BUTTON_ID.BUTTON_PAUSE)}
            style={{ marginLeft: 3 }}
            onClick={() => this.ExcuteCmd('OnPause')}
            icon="pause"
            className="bp3-large" />
          <Button
            disabled={!this.btnState(BUTTON_ID.BUTTON_STOP)}
            style={{ marginLeft: 3 }}
            onClick={() => this.ExcuteCmd('OnStop')}
            icon="stop"
            className="bp3-large" />
        </ButtonGroup>
      </ToolbarWapper >

    )
  }
}
