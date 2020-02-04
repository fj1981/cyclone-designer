import React, { Component } from 'react'
import { observer, inject } from 'mobx-react'
import styled from 'styled-components'
import FlowItem from './FlowItem'
import { IProps } from '../store/Store'

const FlowListWrapper = styled.div`
    display: flex;
    width:0;
    height:100%;
    align-items: center;  
    flex-basis: 100%;
    flex-shrink: 0;
    white-space: nowrap;
    overflow-x: auto;
`
const Blank= styled.div` 
    width:200px;
    height:100%;
    white-space:pre;
`


@inject('store')
@observer
export default class FlowList extends Component<IProps> {
    static propTypes = {
    }
    GetList = () => {
        let variables = this.props.store?.project?.call?.expr;
        let focus_line = this.props.store?.focus_line;
        if(variables) {
            return variables.map(
                e => { 
                    let store ={store2:e,
                         isFocus:false}
                    store.isFocus = (e.lineNumber === focus_line) || false;
                    return <FlowItem key={e.lineNumber}  {...store} /> }
            );
        }
        else {
        }
    }

    render() {
        return (
        <FlowListWrapper data-prj={this.props?.store?.project.call}>
            {this.GetList()}
            <Blank >         </Blank> 
         </FlowListWrapper>
        )
    }
}
