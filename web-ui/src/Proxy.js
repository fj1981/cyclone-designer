function Log(val) {
    if(true) {
        console.log(val);
    }
}

export function OnNewFile() {
    if(window.OnNewFile) {
        window.OnNewFile();
    }
}

export function OnOpenFile() {
    if(window.OnOpenFile) {
        window.OnOpenFile();
    }
}

export function OnSaveFile(str) {
    if(window.OnSaveFile) {
        window.OnSaveFile(str);
    }
}

export function OnRun() {
    if(window.OnRun) {
        window.OnRun();
    }
}

export function OnPause() {
    if(window.OnPause) {
        window.OnPause();
    }
}

export function OnStop() {
    if(window.OnStop) {
        window.OnStop();
    }
}

export function OnMouseHover(mousePos) {
    if(window.OnMouseHover) {
        window.OnMouseHover(JSON.stringify(mousePos));
    }
}

export function OnRemoveProcess(lineNum) {
    if(window.OnRemoveProcess) {
        window.OnRemoveProcess(lineNum);
    }
}

export function BeginAddFlowItem() {
    Log('BeginAddFlowItem');
    if(window.BeginAddFlowItem) {
        window.BeginAddFlowItem();
    }
}

export function EndAddFlowItem(type,pt,preLineNumber,param) {
    Log('EndAddFlowItem');
    if(window.EndAddFlowItem) {
        let str = JSON.stringify({type,pt,preLineNumber,param});
        console.log(str);
        window.EndAddFlowItem(str);
    }
}

export function GetFlowPicSize(){
   if(window.GetFlowPicSize) {
       return window.GetFlowPicSize();
   }
   return {width:200,height:350};
}


export function GetLiveMaxWidth(){
    if(window.GetLiveMaxWidth) {
        return window.GetLiveMaxWidth();
    }
    return 270;
 }
 

 export function GetPrjName(){
    if(window.GetPrjName) {
        return window.GetPrjName();
    }
    return 'unknown';
 }
 