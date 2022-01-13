import styled, { css } from "styled-components";

export const TableSeenWrapper = styled.div`
  padding: 22px 17px;

  .tabletable {
    color: #ffffff;
  }

  details summary {
    background-color: #202024;
  }

  summary::before {
    content: "testes";
  }

  .check {
    background-color: red;
    /* appearance: none; */
    -webkit-appearance: none;
    width: 10px;
    height: 10px;
    border-radius: 9999px;
    margin-bottom: 11.5px;
  }
  .lessonRow div {
    width: 2px;
    height: 15px;
    background-color: burlywood;
  }
  .lessonRow:after {
    /* content: "";
    display: block;
    border: 1px solid #000;
    width: 40px;
    height: 40px;
    margin: 5px auto;
    background-color: #ddd; */
  }
  .lessonRow:before {
    /* content: "";
    display: block;
    border: 1px solid #000;
    width: 40px;
    height: 40px;
    margin: 5px auto;
    background-color: #ddd; */
    position: relative;
    content: "";
    width: 2px;
    height: 16px;
    top: -14px;
    left: 6px;
    background-color: red;
  }

  .check:checked {
    background-color: blue;
    :before {
      background-color: blue;
    }
  }

  .checkColumn {
    display: flex;
    flex-direction: column;
  }
  .lessonRow {
    display: flex;
    width: 100%;
    justify-content: flex-start;
    align-items: center;
  }
  .lessonRow p {
    margin-bottom: 0;
    margin-left: 5px;
  }
  .simpleLessonButton {
    position: relative;
    cursor: pointer;
    width: 10px;
    height: 10px;
    border-radius: 50%;
    border: 0;
    background: #fb5700;
    margin-right: 30px;
  }
  .simpleLessonButton:before {
    content: "";
    width: 2px;
    height: 20px;
    background-color: #fb5700;
    top: -14px;
    left: 6px;
    position: relative;
  }
  .lessonSeenButton {
    position: relative;
    cursor: pointer;
    width: 10px !important;
    height: 10px;
    border: 0px;
    border-radius: 50%;
    margin-right: 30px;
    flex-shrink: 0;
    z-index: 2;
    transition: box-shadow 0.2s ease 0s;
    background: #fb5700;
  }
  .lessonSeenButton:before {
    background: rgb(32, 32, 36);
    border: 2px solid #fb5700;
    border-radius: 50%;

    content: "";
    position: absolute;
    top: 50%;
    left: 50%;
    width: 20px;
    height: 20px;
    transform: translate(-50%, -50%);
  }
  .lessonSeenButton:after {
    background: #fb5700;
    content: "";
    position: absolute;
    top: 0px;
    left: 0px;
    width: 100%;
    height: 100%;
    z-index: 2;
    border-radius: 50%;
  }
  ul {
    list-style-type: none;
  }
  .liAlign {
    display: flex;
    align-items: center;
  }
`;
