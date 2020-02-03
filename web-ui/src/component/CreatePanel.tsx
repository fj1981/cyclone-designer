import React from 'react'
import PropTypes from 'prop-types'
import { observer, inject } from 'mobx-react'
import { Button } from '@blueprintjs/core'
import styled from 'styled-components'
import { IProps } from '../store/Store'


const CreatePanelWapper = styled.div`
  height:50px;
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
                <TextWrapper> 点击创建后，在视频中移动鼠标选取元素，右键创建步骤</TextWrapper>
            </CreatePanelWapper>
        )
    }
}
