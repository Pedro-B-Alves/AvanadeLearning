import React, { useEffect, useState } from "react";
import "./styles/style.css";
import { useHistory } from "react-router-dom";
import { api } from "../../services/api";
import lapis from "../../assets/img/Lapis.svg";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { parseJwt } from "../../services/auth";
import { Header } from "../../components/Navigation/Header";
import { Imagem } from "./imagem";
import GitHub from "../../assets/img/GitHub.svg";
import LinkedIn from "../../assets/img/LinkedIn.svg";

export function Perfil() {
  const history = useHistory();
  const [dadosUserNome, setDadosUserNome] = useState("");
  const [dadosUserImg, setDadosUserImg] = useState("");
  const [dadosUserImgBackground, setDadosUserImgBackground] = useState("");
  const [dadosUserEmpresaCargo, setDadosUserEmpresaCargo] = useState("");
  const [dadosUserSobre, setDadosUserSobre] = useState("");
  const [dadosEstado, setDadosEstado] = useState("");
  const [dadosPais, setDadosPais] = useState("");
  const [dadosConquista, setDadosConquista] = useState("");
  const [dadosRede, setDadosRede] = useState("");
  const [nomeRedirecinar, setNomeRedirecinar] = useState("");

  useEffect(() => {
    getUser(parseJwt().jti);
    getConq(parseJwt().jti);
    getEstado(parseJwt().jti);
    getRedeUser(parseJwt().jti);
  }, []);

  async function getUser(id) {
    const { data, status } = await api.get(`/Usuarios/${id}`);
    // console.log("Entrou no método de Get");
    if (status === 200) {
      await setDadosUserImg(
        "http://52.1.167.147/api/Arquivos/images/" + data.imagem
      );
      await setDadosUserImgBackground(
        "http://52.1.167.147/api/Arquivos/images/" + data.imagemBackground
      );
      await setDadosUserNome(data.nome);
      await setDadosUserSobre(data.sobreMim);
      if (
        !(data.empresa == "Empresa não informada" || data.empresa == null) &&
        !(data.cargo == "Cargo não informado" || data.cargo == null)
      ) {
        await setDadosUserEmpresaCargo(data.empresa + " | " + data.cargo);
      }
      console.log(data);
      console.log("A listagem do usuário funcionou");
    }
  }

  async function getConq(id) {
    const { data, status } = await api.get(`/ConquistasUsuario/${id}`);
    console.log(data);
    if (status === 200) {
      await setDadosConquista(data.idConquistaNavigation.imagem);
      console.log("A listagem das conquistas funcionou");
    }
  }

  async function getEstado(id) {
    const { data, status } = await api.get(`/EstadosUsuario/${id}`);
    // console.log("Entrou no método de Get");
    if (status === 200) {
      await setDadosEstado(data.idEstadoNavigation.nome + ", ");
      await getPais(data.idEstadoNavigation.idPais);
      console.log("A listagem do estado funcionou");
    }
  }

  async function getPais(id) {
    const { data, status } = await api.get(`/Paises/${id}`);
    if (status === 200) {
      await setDadosPais(data.nome);
      console.log("A listagem do pais funcionou");
    }
  }

  async function getRedeUser(id) {
    const { data, status } = await api.get(`/RedesUsuarios/${id}`);
    // console.log("Entrou no método de Get");
    if (status === 200) {
      setNomeRedirecinar(data.link);
      setDadosRede(data.idRedeSocial);
      console.log(data.link);
      console.log("A listagem de rede social funcionou");
    }
  }

  const redirectConq = async (e) => {
    history.push("/");
  };

  //   async function updateInstitute(
  //     id,
  //     nomeFantasia,
  //     razaoSocial,
  //     endereco,
  //     cnpj,
  //     telefone
  //   ) {
  //     try {
  //       const { status } = await api.put(`/instituicoes/${id}`, {
  //         id,
  //         nomeFantasia,
  //         razaoSocial,
  //         endereco,
  //         cnpj,
  //         telefone,
  //       });

  //       if (status === 204) {
  //       }
  //     } catch (error) {}
  //   }

  const success = () =>
    toast.success("Sua instituição foi cadastrada com sucesso!", {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
    });

  return (
    <div className="area">
      <Header></Header>
      <div>
        <img className="areaImgBackground" src={dadosUserImgBackground} />
      </div>
      <div className="areaConteudo">
        <div>
          <section className="areaConteudoUsuario">
            <div className="posicaoBotao">
              <img
                className="botaoEditar"
                src={lapis}
                onClick={redirectConq}
                alt="editar"
              />
            </div>
            <div className="dadosUser">
              <img
                className="imgPerfil"
                src={dadosUserImg}
                alt="imagem de perfil"
              />
              <p className="nome">{dadosUserNome}</p>
              <p className="cargo">{dadosUserEmpresaCargo}</p>
              <p className="local">
                {dadosEstado}
                {dadosPais}
              </p>
            </div>
          </section>
          <br />
          <section className="conquista">
            <div className="posicaoConquista">
              <p className="tituloConquista">Conquista</p>
              <a className="verMais" onClick={redirectConq}>
                Ver Mais &gt;
              </a>
            </div>
            <div className="conq">
              {
                dadosConquista !== "" &&
                <Imagem imagem={dadosConquista} />
              }
            </div>
          </section>
        </div>
        <section className="sobre">
          <div className="posicaoBotao">
            <img
              className="botaoEditar"
              src={lapis}
              onClick={redirectConq}
              alt="editar"
            />
          </div>
          <p className="tituloSobre">Sobre mim</p>
          <p className="textoSobre">{dadosUserSobre}</p>
          {
            dadosRede === 1 &&
            nomeRedirecinar !== "" &&
            <a href={nomeRedirecinar}>
              <img
              className="imgRede"
              src={GitHub}
              alt="GitHub"
              />
            </a>
          }
          {
            dadosRede === 3 &&
            nomeRedirecinar !== "" &&
            <a href={nomeRedirecinar}>
              <img
              className="imgRede"
              src={LinkedIn}
              alt="LinkedIn"
              />
            </a>
          }
        </section>
      </div>
    </div>
  );
}
  