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

export function OnSaveFile() {
    if(window.OnSaveFile) {
        window.OnSaveFile();
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

export function BeginAddFlowItem() {
    Log('BeginAddFlowItem');
    if(window.BeginAddFlowItem) {
        window.BeginAddFlowItem();
    }
}

export function EndAddFlowItem(type,pt,param) {
    Log('EndAddFlowItem');
    if(window.EndAddFlowItem) {
        window.EndAddFlowItem(JSON.stringify({type,pt,param}));
    }
}

