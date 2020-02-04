import React from 'react'
import { observer, inject } from 'mobx-react'
import styled from 'styled-components'
import { Divider } from '@blueprintjs/core'
import PhoneLive from './PhoneLive'
import CreatePanel from './CreatePanel'
import FlowList from './FlowList'
import { IProps } from '../store/Store'


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
    min-width:${props => (props as IProps).store!.live_size.width + 40}px;
    padding: 10px;
    height:100%;
    flex-direction: column;
    border:1px solid rgb(128,0,0);
    justify-content: flex-end;
    align-content: center;
`


@inject('store')
@observer
export default class Content extends React.Component<IProps> {
  static propTypes = {
  }

  render() {
    return (
      <ContentArea>
        <StateShow > 
          <FlowList/>
        </StateShow>
        <Divider />
        <LiveShow style={{width:`${this.props.store?.live_size.width||400+40}px`}} {...this.props}>
          <PhoneLive />
           <CreatePanel/> 
        </LiveShow >
      </ContentArea>
    )
  }
}
