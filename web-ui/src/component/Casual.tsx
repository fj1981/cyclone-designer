import { inject, observer } from 'mobx-react';
import * as React from "react"
import {IProps}  from '../store/Store';

// interface IProps {
//     store?: Store;
// }

@inject("store") // 将store注入
@observer   // 将Casual类转化为观察者，只要被观察者跟新，组件将会刷新
class Casual extends React.Component<IProps, {}> {

    constructor(props: IProps) {
        super(props)
    }
    public render() {
        return (
            <div>
                <h1>{this.props.store!.num}</h1>
                <button onClick={this.onClickAdd}>增加num</button>
            </div>
        )
    }

    public onClickAdd = () => {
        this.props.store!.add()
    };
}

export default Casual

