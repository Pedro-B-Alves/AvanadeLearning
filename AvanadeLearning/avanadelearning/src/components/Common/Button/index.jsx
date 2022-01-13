import React from "react";
import { ButtonWrapper } from "./styles/ButtonWrapper";

export function Button({
  children,
  ghost,
  border,
  banner,
  tag,
  buttonVisible,
  listSeen,
  ...props
}) {
  return (
    <ButtonWrapper
      ghost={ghost}
      border={border}
      banner={banner}
      as={tag}
      disable={buttonVisible}
      listSeen={listSeen}
      {...props}
    >
      {children}
    </ButtonWrapper>
  );
}
