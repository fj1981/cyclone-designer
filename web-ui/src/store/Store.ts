import { action, computed, observable } from "mobx"
import { IImageShowParam, IProject,Point, FlowItemType, Rect, IGlobDef, Size, BUTTON_STATE, BUTTON_ID, PROCESS_STATE, IRunState } from "../component/def.d";
import { IEditDialogProp } from "../component/EditDlg";
import { BeginAddFlowItem,EndAddFlowItem, GetLiveMaxWidth, GetFlowPicSize } from "../Proxy";


class Store {
    @observable public num: number = 0;
    @observable public video_param: IImageShowParam  = {width:300,height:600,src:''};
    @observable public create_flowitem: boolean  = false;
    @observable public hover_rc: Rect[]|null  = null;
    @observable public project: IProject  = {};
    @observable public focus_line: number  = -1;
    @observable public button_state: BUTTON_STATE[]  = [
        BUTTON_STATE.BTN_DISABLE,
        BUTTON_STATE.BTN_DISABLE,
        BUTTON_STATE.BTN_DISABLE,
        BUTTON_STATE.BTN_DISABLE,
        BUTTON_STATE.BTN_DISABLE,
        BUTTON_STATE.BTN_DISABLE,
        BUTTON_STATE.BTN_ENABLE,
    ];

    @observable public process_state: PROCESS_STATE  = PROCESS_STATE.PROCESS_STATUS_UNKNOWN;
    @observable public pic_size: Size  = {width:0,height:0};
    @observable public live_size: Size  = {width:400,height:0};
    @observable public editdlg:IEditDialogProp = {autoFocus: true,
        canEscapeKeyClose: true,
        canOutsideClickClose: false,
        enforceFocus: true,
        isOpen: false,
        usePortal: true,    
        point:{x:0,y:0}};
        
    @observable public glob_prop :IGlobDef = { 
        live_width_rate:0.5,
        live_Height_rate:0.5,
        image_width_rate:0.25,
        image_height_rate:0.25};

    @computed
    public get addNum() {
        return this.num + 10;
    }
    
    // 使用@action 更改被观察者
    @action.bound
    public add() {
        this.num++;
    }

    @action.bound
    public SetVideoParam(param :IImageShowParam) {
        this.video_param = param;
        this.live_size.width = this.video_param.width;
        this.live_size.height= this.video_param.height;
    }

    @action.bound
    public SetHoveerRect(rc :Rect[]) {
        this.hover_rc = rc;
    }

    @action.bound
    public EnableCreateFlowItem(enable :boolean) {
        if(enable) {
            BeginAddFlowItem();
        }
        this.create_flowitem = enable;
        if(enable) {
            this.button_state[BUTTON_ID.BUTTON_CREATE_FLOWITEM] = BUTTON_STATE.BTN_DISABLE;
        }
        else {
            this.button_state[BUTTON_ID.BUTTON_CREATE_FLOWITEM] = BUTTON_STATE.BTN_ENABLE;
        }
        this.UpdateRunButtonstate();
    }

    @action.bound 
    private UpdateRunButtonstate() {
        if(!this.project?.call) {
            this.button_state[BUTTON_ID.BUTTON_RUN] = BUTTON_STATE.BTN_DISABLE;
            return;
        }
        if(this.process_state != PROCESS_STATE.PROCESS_STATUS_RUNNING) {
            this.button_state[BUTTON_ID.BUTTON_RUN]  = this.button_state[BUTTON_ID.BUTTON_CREATE_FLOWITEM];
        }
        else {
            this.button_state[BUTTON_ID.BUTTON_RUN] = BUTTON_STATE.BTN_DISABLE
        }
    }

    @action.bound
    public LoadProject(projs:string) {
        try {
            this.UpdatePicSize();
            let proj = JSON.parse(projs);
            console.log(proj);
            this.project = proj;
            if(proj) {
                this.focus_line =  proj.focusLineNumber;
                this.UpdateRunButtonstate();
            }
           
        } catch (error) {
           console.log(error);
        } 
    }

    public AddNewFlowItem(type:FlowItemType, pt:Point , param: string = '') {
        EndAddFlowItem(type,pt,this.focus_line,param);
        this.button_state[BUTTON_ID.BUTTON_CREATE_FLOWITEM] = BUTTON_STATE.BTN_ENABLE;
        this.UpdateRunButtonstate();
    }

    @action.bound
    public SetEditDlgState(isShow:boolean,pt:Point = {x:0,y:0}) {
        this.editdlg.isOpen = isShow;
        if(isShow) {
            this.editdlg.point = pt;
        }
        console.log(pt);
    }
    @action.bound
    public UpdateLiveMaxWidth() {
        this.live_size.width =  GetLiveMaxWidth();
    }

    @action.bound
    public UpdatePicSize() {
        this.pic_size =  GetFlowPicSize();
    }

    @action.bound
    public UpdateRunState(stateStr:string) {
        try{
            let state:IRunState = JSON.parse(stateStr);
            this.process_state  = state.status;
            this.focus_line = state.process?.focusLineNumber || this.focus_line ;
            this.UpdateRunButtonstate();
        }
        catch(e) {
            console.log(e);
        }

    }
}

export interface IProps {
    store?: Store;
}

export default Store


