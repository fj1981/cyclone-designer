export interface IImageShowParam {
    width: number,
    height: number,
    src: string
}

export interface IVariable {
    lineNumber: number,
    dirty: boolean,
    name: string,
    value: string,
    modify: number
}

export interface IFlowItem {
    lineNumber: number
    serial: string,
    modify:number,
    dirty: boolean,
    rect: Rect[],
    type: number,
    input?:string[],
    output?:string[],
    expr?:IFlowItem[],
    size?:Size
}

export interface IProject {
    variable?:IVariable[],
    call?:IFlowItem
}

export interface Point {
    x:number;
    y:number;
}

export interface Rect {
    left:number;
    top:number;
    right:number;
    bottom:number;
}

export interface Size {
    width:number;
    height:number;
}

export enum FlowItemType {
    FLOW_CLICK = 1,
    FLOW_SETTEXT = 2,
    FLOW_GETTEXT = 3
}

export interface IGlobDef {
    live_width_rate:number;
    live_Height_rate:number;
    image_width_rate:number;
    image_height_rate:number;
}

export {}