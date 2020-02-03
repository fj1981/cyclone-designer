import React, { Component } from 'react'
import { observer, inject } from 'mobx-react'
import styled from 'styled-components'
import { Divider } from '@blueprintjs/core'
import PhoneLive from './PhoneLive'
import CreatePanel from './CreatePanel'
import FlowList from './FlowList'


const ContentArea = styled.div`
  flex: 1;
  display: flex;
  border:1px solid rgb(200,200,200);
  max-height: calc(100vh - 250px);
`

const StateShow = styled.div`
    display: flex;
    height:100%;
    padding:10px;

    flex: 1;
`

const LiveShow = styled.div`
    display: flex;
    min-width:500px;
    padding: 10px;
    height:100%;
    flex-direction: column;
    border:1px solid rgb(255,0,0);
    justify-content: flex-end;
`


@inject('store')
@observer
export default class Content extends Component {
  static propTypes = {
  }

  render() {
    return (
      <ContentArea>
        <StateShow > 
          <FlowList/>
        </StateShow>
        <Divider />
        <LiveShow>
          <PhoneLive />
           <CreatePanel/> 
        </LiveShow>
      </ContentArea>
    )
  }
}
