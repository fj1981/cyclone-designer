import React, { Component } from "react";
import { TitleBar } from "react-desktop/windows";

export default class extends Component {
  static defaultProps = {
    color: "#106EBE",
    theme: "light"
  };

  constructor(props) {
    super(props);
    this.state = { isMaximized: false };
  }

  close = () => {window.NanUI.hostWindow.close()}
  minimize = () => console.log("minimize");
  toggleMaximize = () =>
    this.setState({ isMaximized: !this.state.isMaximized });

  render() {
    return (
      <TitleBar
        title='Cyclone RPA Personal'
        controls
        isMaximized={this.state.isMaximized}
        theme={this.props.theme}
        background={this.props.color}
        onCloseClick={this.close}
        onMinimizeClick={this.minimize}
        onMaximizeClick={this.toggleMaximize}
        onRestoreDownClick={this.toggleMaximize}
      />
    );
  }
}
