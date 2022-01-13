import styled, { css } from "styled-components";

export const FormFiveWrapper = styled.div`
  display: flex;
  align-items: center;
  width: 500px;

  .formFiveBody h1 {
    color: #ffffff;
    margin-bottom: 40px;
  }
  .formFiveBody {
    display: flex;
    align-items: center;
    flex-direction: column;
    background-color: #2b2b2f;
    /* width: 570px; */
    padding: 60px;
    border-radius: 8px;
  }
  input::-webkit-outer-spin-button,
  input::-webkit-inner-spin-button {
    -webkit-appearance: none;
    margin: 0;
  }
  .inputsAreaComponent {
    width: 100%;
  }
`;
