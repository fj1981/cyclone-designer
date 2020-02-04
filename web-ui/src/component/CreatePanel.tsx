import React from 'react'
import { observer, inject } from 'mobx-react'
import { Button } from '@blueprintjs/core'
import styled from 'styled-components'
import { IProps } from '../store/Store'
import { BUTTON_ID, BUTTON_STATE } from './def.d'


const CreatePanelWapper = styled.div`
  height:75px;
  text-align:center;
  margin:20px;
`

const TextWrapper = styled.div`
  margin:20px;
`

@inject('store')
@observer
export default class CreatePanel extends React.Component<IProps,{}> {
    static propTypes = {
    }

    private btnState = (e: BUTTON_ID) => {
        let state = this.props.store?.button_state[e];
        if (!state) {
          return false;
        }
        return state == BUTTON_STATE.BTN_ENABLE;
    }

    public onClick = () => {
        this.props.store!.EnableCreateFlowItem(true);
    };

    render() {
        return (
            <CreatePanelWapper>
                <Button text="创建新步骤 " 
                    onClick ={this.onClick}
                    disabled = {!this.btnState(BUTTON_ID.BUTTON_CREATE_FLOWITEM)}
                /> 
                <TextWrapper> 点击创建后，在视频点击鼠标进行操作</TextWrapper>
            </CreatePanelWapper>
        )
    }
}
