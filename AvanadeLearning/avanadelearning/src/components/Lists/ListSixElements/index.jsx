import React from "react";
import { ListSixElementsWrapper } from "./styles/ListSixElementsWrapper";

export function ListSixElements({
  title,
  children,
  ...props
}) {

  return (
    <ListSixElementsWrapper>
      <div className="TableWrapperHeader">
        <h1>{title}</h1>
      </div>
      <div className="TableWrapperBody">
        <table>{children}</table>
      </div>
    </ListSixElementsWrapper>
  );
}


// export function Table({ title, children }) {
//   return (
//     <TableWrapper>
//       <TableWrapper.Header>
//         <Text variant="subtitle" color="primaryText">
//           {title}
//         </Text>
//       </TableWrapper.Header>
//       <TableWrapper.Body>
//         <table>{children}</table>
//       </TableWrapper.Body>
//     </TableWrapper>
//   );
// }
