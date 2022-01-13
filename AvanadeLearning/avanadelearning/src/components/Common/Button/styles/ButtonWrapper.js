import styled, { css } from "styled-components";

const GhostButton = css`
  background-color: transparent;
  border: none;
  color: #ffffff;
`;
const BorderButton = css`
  border: 2px solid #fb5700;
  background-color: transparent;
  color: #fb5700;
`;
const BannerButton = css`
  border: 2px solid #ffffff;
  background-color: transparent;
  color: #ffffff;
`;
const DefaultButton = css`
  background-color: #fb5700;
  border: none;
  color: #ffffff;
`;
const Visible = css`
  display: none;
`;

const ListSeen = css`
  border-radius: 999px;
  width: 20px;
  height: 20px;
  padding: 0;
  
`;

export const ButtonWrapper = styled.button`
  padding: 22px 17px;
  border-radius: 8px;
  font-weight: 700;
  font-family: "Poppins", sans-serif;
  cursor: pointer;
  width: 100%;
  ${({ ghost, border, banner, disable, listSeen }) => {
    if (ghost) return GhostButton;
    if (border) return BorderButton;
    if (banner) return BannerButton;
    if (disable) return Visible;
    if (listSeen) return ListSeen;
    return DefaultButton;
  }};
`;
