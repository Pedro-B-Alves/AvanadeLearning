import React from "react";
import { FormFiveWrapper } from "./styles/FormFiveWrapper.js";
import { Input } from "../../Common/Input";
import { Button } from "../../Common/Button";
export function FormF({
  title,
  onSubmit,
  type,
  placeholder,
  state,
  method,
  icon,
  type2,
  placeholder2,
  state2,
  method2,
  icon2,
  type3,
  placeholder3,
  state3,
  method3,
  icon3,
  type4,
  placeholder4,
  state4,
  method4,
  icon4,
  type5,
  placeholder5,
  state5,
  method5,
  icon5,
  updateMethod,
  button1,
  button2,
  ...props
}) {
  return (
    <FormFiveWrapper>
      <form onSubmit={onSubmit} className="formFiveBody">
        <h1 className="formFiveTitle">Cadastro de {title}</h1>

        <div className="inputsAreaComponent">
          <Input
            type={type}
            placeholder={placeholder}
            value={state}
            onChange={method}
            icon={icon}
          />
          <Input
            type={type2}
            placeholder={placeholder2}
            value={state2}
            onChange={method2}
            icon={icon2}
          />
          <Input
            type={type3}
            placeholder={placeholder3}
            value={state3}
            onChange={method3}
            icon={icon3}
          />
          <Input
            type={type4}
            placeholder={placeholder4}
            value={state4}
            onChange={method4}
            icon={icon4}
          />
          <Input
            type={type5}
            placeholder={placeholder5}
            value={state5}
            onChange={method5}
            icon={icon5}
          />
          <Button type="submit">Cadastrar</Button>
        </div>
      </form>
    </FormFiveWrapper>
  );
}
