import React, { useState } from "react";
import { TableSeenWrapper } from "./styles/TableSeenWrapper";
import { Button } from "../Button";
import {
  Timeline,
  Container,
  YearContent,
  BodyContent,
  Section,
  Description,
} from "vertical-timeline-component-react";
export function TableSeen({ lessonTitle, children }) {
  const [listLesson, setListLesson] = useState("");

  const customTheme = {
    yearColor: "#405b73",
    lineColor: "#d0cdc4",
    dotColor: "#262626",
    borderDotColor: "#d0cdc4",
    titleColor: "#405b73",
    subtitleColor: "#bf9765",
    textColor: "#262626",
  };

  return (
    <TableSeenWrapper>
      <div className="tabletable">
        {/* <label for="show">
          <span>Teste</span>
        </label>
        <input type="radio" id="show" name="group" />
        <label for="hide">
          <span>Testando</span>
        </label>
        <input type="radio" id="hide" name="group" />
        <span id="content">Content</span> */}
        <details open>
          <summary>{lessonTitle}</summary>
          <ul>
            <li className="liAlign">
              <button className="lessonSeenButton"></button>
              <a>1 React.js criando a solução</a>
            </li>
            <li className="liAlign">
              <button className="simpleLessonButton"></button>
              <a>2 React.js ajustando a responsividade</a>
            </li>
            <li className="liAlign">
              <button className="simpleLessonButton"></button>
              <a>3 React.js Criando componentes</a>
            </li>
          </ul>
        </details>
      </div>
    </TableSeenWrapper>
  );
}
