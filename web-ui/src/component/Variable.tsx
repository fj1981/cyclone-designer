import React, { Props } from 'react';
import { inject } from 'mobx-react';
import { IVariable } from './def.d';
import { IProps } from '../store/Store';
import { Tag } from '@blueprintjs/core';



interface ITProps extends IProps, IVariable {
}

@inject('store')
class Variable extends React.Component<ITProps> {
    constructor(props:ITProps) {
        super(props);
        this.state = {  };
        console.log(props);
    }
    render() {
        return (
            <span> <Tag large={true} >{this.props.value} </Tag></span>
        );
    }
}

export default Variable;