import React from "react";
import { Button } from "../../Common/Button";
import { HeaderWrapper } from "./styles/HeaderWrapper";
import { useHistory, Link } from "react-router-dom";
import { Avatar } from "../../Common/Avatar";
import { parseJwt, usuarioAutenticado } from "../../../services/auth";
import logo from "../../../assets/img/Logo.svg";
export function Header() {
  const history = useHistory();
  const userLoggedIn = usuarioAutenticado();
  const userInfo = localStorage.getItem("userToken") !== null && parseJwt();

  function handleSignout() {
    localStorage.removeItem("userToken");
    history.push("/");
  }

  console.log(userInfo.imagem);
  console.log(`http://52.1.167.147/api/Arquivos/images/${userInfo.imagem}`);

  return (
    <HeaderWrapper>
      <div className="contentAreaHeader">
        <div className="firstBlock">
          <div className="divLogo">
            <Link to="/">
              <img src={logo}></img>
            </Link>
          </div>
          <div
            style={{
              display: "flex",
              alignItems: "center",
              justifyContent: "space-between",
              gap: "40px",
            }}
          >
            {userLoggedIn && (
              <>
                <Link to="/">Home</Link>
                <Link to="/curso">Cursos</Link>
              </>
            )}
          </div>
          <div
            style={{
              display: "flex",
              alignItems: "center",
              // justifyContent: "space-between",
              gap: "24px",
              // border: "solid 2px green",
            }}
          >
            {userLoggedIn ? (
              <>
                {/* <Link to="/">Inicio</Link> */}
                <div
                  className="header-avatar"
                  style={{
                    display: "flex",
                    alignItems: "center",
                    gap: "24px",
                  }}
                >
                  <span
                    style={{
                      display: "flex",
                      alignItems: "center",
                      wordBreak: "keep-all",
                      width: "auto",
                    }}
                  >
                    Bem-vindo, {userInfo.nome.split(" ")[0]}!
                  </span>
                  <Link to="/perfil">
                    <Avatar
                      photo={`http://52.1.167.147/api/Arquivos/images/${userInfo.imagem}`}
                    />
                  </Link>
                  <Button
                    ghost
                    onClick={handleSignout}
                    style={{ width: "auto" }}
                  >
                    Sair
                  </Button>
                </div>
              </>
            ) : (
              <>
                <span
                  style={{
                    display: "flex",
                    alignItems: "center",
                    wordBreak: "keep-all",
                    width: "auto",
                    visibility: "hidden",
                  }}
                >
                  Bem-vindo,!
                </span>
                <Link to="/perfil" style={{ visibility: "hidden" }}>
                  <Avatar />
                </Link>

                <Button onClick={() => history.push("/login")} ghost>
                  Entrar
                </Button>
                {/* <Button>Quero anunciar</Button> */}
              </>
            )}
          </div>
        </div>
      </div>
    </HeaderWrapper>
  );
}
