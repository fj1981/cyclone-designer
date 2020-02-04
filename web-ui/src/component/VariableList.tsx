import React from "react";
import { IProps } from "../store/Store";
import Variable from "./Variable";
import { inject, observer } from "mobx-react";
import styled from 'styled-components'

const VariableListWrapper = styled.div`
    height:100%;
    overflow-x: auto;
    padding:20px;
`

@inject('store')
@observer
class VariableList extends React.Component<IProps> {
    GetList = () => {
        let variables =this.props.store?.project.variable;
        console.log(variables);
        if(variables) {
            console.log(variables);
            return variables.map(
                e => { 
                    console.log({...e});
                    return <Variable key={e.lineNumber} {...e} /> }
            );
        }
        else {
        }
     }

    render() {
        return (
            <VariableListWrapper >
                {this.GetList()||''}
            </VariableListWrapper>
        );
    }
}

export default VariableList;