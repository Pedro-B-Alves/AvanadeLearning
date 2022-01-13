import styled, { css } from 'styled-components';

export const InputWrapper = styled.div`
  display: flex;
  align-items: center;
  gap: 16px;  
  background-color: #111111;
  border: solid 2px #111111;
  border-radius: 5px;
  padding: 0 18px;
  font-size: 24px;
  margin-bottom: 12px;
  /* width: 100% ; */
  svg {
      color: #c1c1c1;
    }
  input {
    border: none;
    outline: none;
    color: #ffffff;
    background-color: transparent;
    padding: 18px 0;
    width: 100%;
  }

  &:focus-within {
    border: solid 2px #FB5700;

    svg {
      color: #FB5700;
    }
  }
`;