import React, { Component } from 'react'
import { Button, Card, Elevation } from "@blueprintjs/core";
import styled from 'styled-components';
import { IFlowItem, FlowItemType } from './def.d';
import { OnRemoveProcess } from '../Proxy';
import { inject, observer } from 'mobx-react';
import { IProps } from '../store/Store';
import GlobDef from '../global';


const FlowItemWapper = styled.div`
   margin:10px; 
`
interface IPropsEx extends IProps {
    store2: IFlowItem,
    isFocus: boolean,
}

@inject('store')
@observer
class FlowItem extends Component<IPropsEx, {}> {
    state = {}

    remove = (event: React.MouseEvent<HTMLElement>) => {
        OnRemoveProcess(this.props.store2.lineNumber);
    };

    getText = (e: number) => {
        switch (e) {
            case FlowItemType.FLOW_CLICK:
                return '点击操作';
            case FlowItemType.FLOW_SETTEXT:
                return '设置文字';
            case FlowItemType.FLOW_GETTEXT:
                return '获取文本';
        }
        return '';
    };
    render() {

        return (
            <FlowItemWapper  >
                <Card interactive={true} elevation={Elevation.TWO} style={{ padding: '10px' }}>
                    <div style={{ height: 30 }}>
                        {this.getText(this.props.store2.type)} 
                    <Button icon="cross" 
                    small={true} 
                    style={{ float: 'right' }} 
                    onClick={this.remove}/>
                    </div>
                    <div style={{
                        width: this.props.store?.pic_size.width,
                        height: this.props.store?.pic_size.height,
                        backgroundImage: `url("${GlobDef.res_url}${this.props.store2!.serial}")`,
                        backgroundSize: '100% 100%',
                        border: this.props.isFocus ? `5px solid red` : ``
                    }} />
                    {/* <img src={require('./test.jpg')} /> */}
                </Card>
            </FlowItemWapper>

        );
    }
}

export default FlowItem;