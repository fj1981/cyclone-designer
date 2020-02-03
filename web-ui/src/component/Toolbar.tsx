import React from 'react'
import { observer, inject } from 'mobx-react'
import { ButtonGroup, Button } from '@blueprintjs/core/lib/esm/components'
import { IProps } from '../store/Store'
import styled from 'styled-components'
import { test_str } from '../resource/test'


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
    if(funcName === 'OnOpenFile') {
       this.OnOpenFile();
       return;
    }
    this.LoadImg();
    let funcstr = `
    if(window.${funcName}) {
      window.${funcName}();}
    `;
    eval(funcstr);
  }

  private OnOpenFile() {
    this.props.store?.LoadProject(test_str)
  }

  render() {
    return (
      <ToolbarWapper >
        <ButtonGroup >
          <Button icon="document" className="bp3-large" onClick={() => this.ExcuteCmd('OnNewFile')} />
          <Button icon="document-open" className="bp3-large" onClick={() => this.ExcuteCmd('OnOpenFile')} />
          <Button icon="floppy-disk" className="bp3-large" onClick={() => this.ExcuteCmd('OnSaveFile')} />
        </ButtonGroup>
        <ButtonGroup style={{ marginLeft: 5 }} >
          <Button icon="play" className="bp3-large" onClick={() => this.ExcuteCmd('OnRun')} />
          <Button icon="pause" className="bp3-large" onClick={() => this.ExcuteCmd('OnPause')} />
          <Button icon="stop" className="bp3-large" onClick={() => this.ExcuteCmd('OnStop')} />
        </ButtonGroup>
      </ToolbarWapper >

    )
  }
}
