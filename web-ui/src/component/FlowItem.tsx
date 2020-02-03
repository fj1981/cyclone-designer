import React, { Component } from 'react'
import { Button, Card, Elevation } from "@blueprintjs/core";
import styled from 'styled-components';
import { IFlowItem } from './def.d';
import { getGlobal } from 'mobx/lib/internal';
import GlobDef from '../global';


const FlowItemWapper = styled.div`
   margin:10px; 
`
interface IPropsEx {
    store2:IFlowItem,
    isFocus:boolean
}
class FlowItem extends Component<IPropsEx,{}> {
    state = {}
    render() {
        return (
            <FlowItemWapper  >
            <Card  interactive={true} elevation={Elevation.TWO}>
                <div style={{
                    width:this.props.store2?.size?.width || 400,
                    height:this.props.store2?.size?.height || 700,
                    backgroundImage:`url("${GlobDef.res_url}${this.props.store2!.serial}")`,
                    backgroundSize:'100% 100%',
                    border:this.props.isFocus? `5px solid red`:``}}/>
                {/* <img src={require('./test.jpg')} /> */}
            </Card>
            </FlowItemWapper>

        );
    }
}

export default FlowItem;