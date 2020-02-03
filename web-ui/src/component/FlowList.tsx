import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { observer, inject } from 'mobx-react'
import { Divider } from '@blueprintjs/core'
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
        let variables = this.props?.store?.project?.call?.expr;
        if(variables) {
            console.log(variables);
            return variables.map(
                e => { 
                    let store ={store:e};
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
