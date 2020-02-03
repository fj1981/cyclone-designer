import React from 'react'
import { observer, inject } from 'mobx-react'
import { IProps } from '../store/Store'
import { Menu, MenuItem, MenuDivider, ContextMenu } from '@blueprintjs/core';
import styled from 'styled-components';
import { Point, FlowItemType } from './def.d';
import { OnMouseHover } from '../Proxy';

const PhoneLiveWapper = styled.div`
    align-content: center;
    flex: 1;
    white-space: nowrap;
    overflow-y: auto;
    flex-direction: row;
`

@inject('store')
@observer
class PhoneLive extends React.Component<IProps, { isContextMenuOpen: boolean }> {

  drawRects(ctx: CanvasRenderingContext2D | null) {
    if (!ctx) {
      return;
    }
    let rcs = this.props.store?.hover_rc;
    ctx.strokeStyle = '#FF0000';
    rcs?.forEach(rc => {
      ctx.strokeRect(rc.left / 2, rc.top / 2, (rc.right - rc.left) / 2, (rc.bottom - rc.top) / 2);
    });
  }

  updateCanvas() {
    const ctx = (this.refs.canvas as HTMLCanvasElement).getContext('2d');
    if (!ctx) {
      return;
    }
    let width = this.props.store!.video_param.width;
    let height = this.props.store!.video_param.height;
    var img = new Image();
    let This = this;
    img.onload = function () {
      ctx.drawImage(img, 0, 0);
      if(This.props.store?.create_flowitem) {

        This.drawRects(ctx);
      }
      else {
        ctx.fillStyle = 'rgba(64,64,64,0.4)'; // 设置颜色
        ctx.fillRect(0, 0, width, height);
      }
    }
    if (this.props.store!.video_param.src !== '') {
      img.src = this.props.store!.video_param.src;

    }
    else {
      ctx.fillStyle = 'rgb(64,64,64)'; // 设置颜色
      ctx.fillRect(0, 0, width, height);
    }

    if(this.props.store?.create_flowitem) {
      this.drawRects(ctx);
    }
  }
  
  constructor(props: IProps) {
    super(props);
    this.GetMouserPos = this.GetMouserPos.bind(this);
    this.drawRects = this.drawRects.bind(this);
  }
  componentDidMount() {
    if (this.props.store!.create_flowitem) {
      (this.refs.canvas as HTMLElement).focus();
    }
    this.updateCanvas();
    // window.addEventListener('resize', this.onResize)
  }
  componentWillUnmount() {
    // window.removeEventListener('resize', this.onResize)
  }

  componentWillUpdate() {
    this.updateCanvas();
  }
  private ptlastClick: Point = { x: 0, y: 0 };

  private GetMouserPos(e: React.MouseEvent<HTMLElement>): Point {
    var rect = (this.refs.canvas as HTMLElement).getBoundingClientRect();
    return {
      x:
        Math.round(e.clientX - rect.left), y: Math.round(e.clientY - rect.top)
    };
  }

  private handleMouseMove = (e: React.MouseEvent<HTMLCanvasElement>) => {
    if (!this.props.store!.create_flowitem) {
      return;
    }
    OnMouseHover(this.GetMouserPos(e));
  }

  pts: Point[] = [];
  private handleClick = (e: React.MouseEvent<HTMLCanvasElement>) => {
    if (!this.props.store!.create_flowitem) {
      return;
    }
    this.showContextMenuImpl(e)
    //this.pts.push(this.GetMouserPos(e));
    //this.forceUpdate();
  }

  private EnableActionButton = () => {
    this.props.store!.EnableCreateFlowItem(false);
  }

  private handleMenuClick = (e: React.MouseEvent<HTMLElement>) => {
    this.props.store!.AddNewFlowItem(FlowItemType.FLOW_CLICK, this.ptlastClick);
    // this.EnableActionButton();
  }

  private handleMenuSetText = (e: React.MouseEvent<HTMLElement>) => {
    this.props.store!.SetEditDlgState(true, this.ptlastClick);
  }

  private handleMenuGetText = (e: React.MouseEvent<HTMLElement>) => {
    this.props.store!.AddNewFlowItem(FlowItemType.FLOW_GETTEXT, this.ptlastClick);
  }

  private handleCancle = (e: React.MouseEvent<HTMLElement>) => {
    this.EnableActionButton();
  }

  private showContextMenuImpl = (e: React.MouseEvent<HTMLCanvasElement>) => {
    this.ptlastClick = this.GetMouserPos(e);
    console.log(this.ptlastClick);
    e.preventDefault();
    if (!this.props.store!.create_flowitem) {
      return;
    }
    // invoke static API, getting coordinates from mouse event
    ContextMenu.show(
      <Menu>
        <MenuItem icon="widget-button" text="模拟点击" onClick={this.handleMenuClick} />
        <MenuItem icon="new-text-box" text="设置文本" onClick={this.handleMenuSetText} />
        <MenuItem icon="search-text" text="读取文本" onClick={this.handleMenuGetText} />
        <MenuDivider />
        <MenuItem icon="cross" text="取消" onClick={this.handleCancle} />
      </Menu>,
      { left: e.clientX, top: e.clientY },
      () => this.setState({ isContextMenuOpen: false }),
    );
    // indicate that context menu is open so we can add a CSS class to this element
    this.setState({ isContextMenuOpen: true });
  };
  private onResize() {
    ContextMenu.hide();
    this.setState({ isContextMenuOpen: false });
  }
  render() {
    return (
      <PhoneLiveWapper>
        <canvas ref="canvas"
          width={this.props.store!.video_param.width}
          height={this.props.store!.video_param.height}
          data-img={this.props.store!.video_param.src}
          data-rc={this.props.store!.hover_rc}
          onMouseMove={this.handleMouseMove}
          onClick={this.handleClick}
          // onContextMenu={this.showContextMenu}
          style={{ border: "2px solid #185ABD" }}
        />

      </PhoneLiveWapper>
    )
  }
}

export default PhoneLive; 