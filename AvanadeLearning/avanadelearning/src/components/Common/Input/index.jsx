import React from "react";
import { InputWrapper } from "./styles/InputWrapper";

export function Input({ type, placeholder, value, method, icon, ...props }) {
  return (
    <InputWrapper>
      {icon}
      <input
        type={type}
        placeholder={placeholder}
        value={value}
        onChange={method}
        {...props}
      />
    </InputWrapper>
  );
}
