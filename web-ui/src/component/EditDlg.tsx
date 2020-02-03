import React, { FormEvent } from "react";
import { Dialog, Classes,  Button,  Intent, InputGroup } from "@blueprintjs/core";
import { observer, inject } from "mobx-react";
import { IProps } from '../store/Store'
import { Point, FlowItemType } from "./def.d";


export interface IEditDialogProp {
    autoFocus: boolean;
    canEscapeKeyClose: boolean;
    canOutsideClickClose: boolean;
    enforceFocus: boolean;
    isOpen: boolean;
    usePortal: boolean;
    point:Point;
}

@inject('store')
@observer
class EditDlg extends React.Component<IProps> {

    private inputValue:(HTMLInputElement |any) = null;
    //private handleOpen = () => this.setState({ isOpen: true });
    private handleClose = () => {
        this.props.store!.SetEditDlgState(false);
        if(this.inputValue) {
            console.log(this.inputValue.value); 
        }
    };
    private handleClose2 = () => {
        this.handleClose();
        if(this.inputValue) {
            console.log(this.inputValue.value); 
            this.props.store!.AddNewFlowItem(FlowItemType.FLOW_SETTEXT,this.props.store!.editdlg.point ,this.inputValue.value);
        }
    };
    private handleFilterChange= (event: FormEvent<HTMLElement>)=> {

    } 
    render() {
        return (
            <Dialog
                icon="info-sign"
                onClose={this.handleClose}
                title="请输入文本"
                {...this.props.store!.editdlg}
            >
                <div className={Classes.DIALOG_BODY}>
                <InputGroup id="text-input"  autoComplete="false" inputRef={input => this.inputValue = input} placeholder="输入文字" />
                </div>
                <div className={Classes.DIALOG_FOOTER}>
                    <div className={Classes.DIALOG_FOOTER_ACTIONS}>
                        <Button  intent={Intent.PRIMARY} onClick={this.handleClose2}>确认</Button>
                    </div>
                </div>
            </Dialog>
        );
    }
}

export default EditDlg;