import React, { Component } from 'react'
import { Button, Card, Elevation } from "@blueprintjs/core";
import styled from 'styled-components';
import { IFlowItem } from './def.d';
import { getGlobal } from 'mobx/lib/internal';
import GlobDef from '../global';


const FlowItemWapper = styled.div`
   margin:10px; 
`
interface IProps2 {
    store:IFlowItem
}
class FlowItem extends Component<IProps2,{}> {
    state = {}
    render() {
        return (
            <FlowItemWapper  >
            <Card  interactive={true} elevation={Elevation.TWO}>
                <div style={{
                    width:this.props.store?.size?.width || 400,
                    height:this.props.store?.size?.height || 700,
                    backgroundImage:`url("${GlobDef.res_url}${this.props.store!.serial}")`,backgroundSize:'100% 100%'}}/>
                {/* <img src={require('./test.jpg')} /> */}
            </Card>
            </FlowItemWapper>

        );
    }
}

export default FlowItem;