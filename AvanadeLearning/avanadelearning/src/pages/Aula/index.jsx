import React, { useState, useEffect } from "react";
import "./styles/style.css";
import { useParams } from "react-router";
import { useHistory, useLocation } from "react-router-dom";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Button } from "../../components/Common/Button";
import { api } from "../../services/api";
import { Title } from "../../components/Common/Title";
import { Description } from "../../components/Common/Description";
import { TableSeen } from "../../components/Common/TableSeen";
import { Header } from "../../components/Navigation/Header";
import ReactDOM from "react-dom";

export function Aula(props) {
  const history = useHistory();
  const { idCurso } = useParams();
  const { idAula } = useParams();
  const { nome } = useParams();
  const [aula, setAula] = useState([]);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [lessonLink, setLessonLink] = useState("");
  const [lessonTitle, setLessonTitle] = useState("");
  const [videoID, setVideoID] = useState("");
  const [description, setVideoDescription] = useState("");
  const [lessonInfo, setLessonInfo] = useState({});

  useEffect(() => {
    BuscarModulo();
  }, []);

  const LoadPage = async (id) => {
    try {
      await GetLessonInfo(id);
    } catch (error) {
      await loadDataError();
    }
  };

  const buscarAulaModulo = async (idModulo) => {
    const resposta = await api.get(`AulaModulos/modulo/${idModulo}`);

    setAula(resposta.data.idAulaNavigation);
    GetLessonInfo(resposta.data.idAula);
    console.log(resposta.data.idAula);
  };

  const BuscarModulo = async () => {
    const resposta = await api.get(`/modulos/modulo/${idCurso}`);

    await buscarAulaModulo(resposta.data.idModulo);
  };

  const GetLessonInfo = async (id) => {
    try {
      const { data, status } = await api.get(`/aulas/${id}`);
      if (status === 200) {
        setLessonInfo(data);
        setLessonLink("https://www.youtube.com/embed/" + data.video + "?rel=0");
        console.log("link" + lessonLink);
      }
    } catch (error) {
      loadDataError();
    }
  };

  const loadDataError = () => {
    toast.error("Infelizmente houve um erro na Exclusão", {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
    });
  };

  return (
    <div>
      <Header></Header>
      <div className="videoPageContent">
        <div className="contentArea">
          <div className="videoColumn">
            <div className="lessonArea">
              <iframe
                src={lessonLink}
                allow="fullscreen;"
                frameBorder="0"
                width="700"
                height="420"
              />
              {/* AREA DE CURSO ASSISTIDO, FALTANDO COMPONENTE */}
              {/* <TableSeen>Teste</TableSeen> */}
            </div>
            <div className="videoInfoArea">
              {/* <Link to={`/ad/${ad.idAnuncio}`}> */}
              {/* <Title>{nome}</Title> */}
              <h2>{props.idCurso}</h2>

              <Title>{lessonInfo.titulo}</Title>
              <h2>Descrição</h2>
              <div className="hrContentArea">
                <hr className="lightHr"></hr>
                <hr className="whiteHr"></hr>
              </div>
              <Description>{aula.descricao}</Description>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
