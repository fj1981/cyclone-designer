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
    modify: number,
    dirty: boolean,
    rect: Rect[],
    type: number,
    input?: string[],
    output?: string[],
    expr?: IFlowItem[],
    size?: Size
}

export interface IProject {
    variable?: IVariable[],
    call?: IFlowItem
}

export interface Point {
    x: number;
    y: number;
}

export interface Rect {
    left: number;
    top: number;
    right: number;
    bottom: number;
}

export interface Size {
    width: number;
    height: number;
}

export enum FlowItemType {
    FLOW_CLICK = 1,
    FLOW_SETTEXT = 2,
    FLOW_GETTEXT = 3
}

export enum BUTTON_ID {
    BUTTON_NEW = 0,
    BUTTON_OPEN = 1,
    BUTTON_SAVE = 2,
    BUTTON_RUN = 3,
    BUTTON_PAUSE = 4,
    BUTTON_STOP = 5,
    BUTTON_CREATE_FLOWITEM = 6,
}

export enum BUTTON_STATE {
    BTN_DISABLE = 0,
    BTN_ENABLE = 1
}

export enum PROCESS_STATE {
    PROCESS_STATUS_UNKNOWN = 0,
    PROCESS_STATUS_READY = 1,
    PROCESS_STATUS_START = 2,
    PROCESS_STATUS_RUNNING = 3,
    PROCESS_STATUS_PAUSE = 4,
    PROCESS_STATUS_STOP = 5,
    PROCESS_STATUS_FAILED = 6,
    PROCESS_STATUS_OVER = 7
}

export interface IGlobDef {
    live_width_rate: number;
    live_Height_rate: number;
    image_width_rate: number;
    image_height_rate: number;
}

/*Call*/
export interface IProcessDetail {
    dirty: boolean;
    input: any;
    lineNumber: number;
    modify: number;
    output?: any;
    rect: Rect[];
    result?: string;
    serial: string;
    type: number;
}

/*Process*/
export interface IProcessState {
    call?: IProcessDetail;
    focusLineNumber: number;
    variable: any;
}

/*tsModel3*/
export interface IRunState {
    process?: IProcessState;
    status: PROCESS_STATE;
}


export { }