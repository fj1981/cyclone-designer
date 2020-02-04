import React from 'react'
import { observer, inject } from 'mobx-react'
import { Button } from '@blueprintjs/core'
import styled from 'styled-components'
import { IProps } from '../store/Store'


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

    public onClick = () => {
        this.props.store!.EnableCreateFlowItem(true);
    };

    render() {
        return (
            <CreatePanelWapper>
                <Button text="创建新步骤 " 
                    onClick ={this.onClick}
                    disabled = {this.props.store!.create_flowitem}
                /> 
                <TextWrapper> 点击创建后，在视频点击鼠标进行操作</TextWrapper>
            </CreatePanelWapper>
        )
    }
}
