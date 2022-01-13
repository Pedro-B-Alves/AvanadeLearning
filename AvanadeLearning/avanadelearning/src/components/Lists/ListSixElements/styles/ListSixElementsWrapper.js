import styled, { css } from "styled-components";

export const ListSixElementsWrapper = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  background-color: #2b2b2f;
  padding: 24px;
  width: 700px;
  border-radius: 8px;

  .TableWrapperHeader {
    box-shadow: 0 4px 6px 0 rgb(12 0 46 / 6%);
    background-color: #2b2b2f;
    color: #ffffff;
    font-size: 16px;
    text-align: center;
    padding-bottom: 20px;
    border-bottom: solid #f1f1f1 4px;
    margin-bottom: 20px;
  }

  .TableWrapperBody {
    background-color: #2b2b2f;
    color: #ffffff;
  }
`;
