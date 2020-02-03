import { action, computed, observable } from "mobx"
import { IImageShowParam, IProject,Point, FlowItemType, Rect, IGlobDef } from "../component/def.d";
import { IEditDialogProp } from "../component/EditDlg";
import { BeginAddFlowItem,EndAddFlowItem } from "../Proxy";


class Store {
    // 被观察者，你可以理解成Vuex中的State，也就是说，声明一些想要观察的状态，变量。
    // 被观察者可以是：JS基本数据类型、引用类型、普通对象、类实例、数组和映射
    @observable public num: number = 0;
    @observable public video_param: IImageShowParam  = {width:500,height:1000,src:''};
    @observable public create_flowitem: boolean  = false;
    @observable public hover_rc: Rect[]|null  = null;
    @observable public project: IProject  = {};
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
            
            let proj = JSON.parse(projs);
            console.log(proj);
            this.project = proj;
        } catch (error) {
           console.log(error);
        } 
    }

    public AddNewFlowItem(type:FlowItemType, pt:Point , param: string = '') {
        EndAddFlowItem(type,pt,param);
    }

    @action.bound
    public SetEditDlgState(isShow:boolean,pt:Point = {x:0,y:0}) {
        this.editdlg.isOpen = isShow;
        this.editdlg.point = pt;
    }

}

export interface IProps {
    store?: Store;
}

export default Store


