import { action, computed, observable } from "mobx"
import { IImageShowParam, IProject,Point, FlowItemType, Rect, IGlobDef, Size } from "../component/def.d";
import { IEditDialogProp } from "../component/EditDlg";
import { BeginAddFlowItem,EndAddFlowItem, GetLiveMaxWidth, GetFlowPicSize } from "../Proxy";


class Store {
    @observable public num: number = 0;
    @observable public video_param: IImageShowParam  = {width:300,height:600,src:''};
    @observable public create_flowitem: boolean  = false;
    @observable public hover_rc: Rect[]|null  = null;
    @observable public project: IProject  = {};
    @observable public focus_line: number  = -1;
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
            }
           
        } catch (error) {
           console.log(error);
        } 
    }

    public AddNewFlowItem(type:FlowItemType, pt:Point , param: string = '') {
        EndAddFlowItem(type,pt,this.focus_line,param);
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
        console.log(`444444444 ${JSON.stringify(this.pic_size)}`);
    }
}

export interface IProps {
    store?: Store;
}

export default Store


