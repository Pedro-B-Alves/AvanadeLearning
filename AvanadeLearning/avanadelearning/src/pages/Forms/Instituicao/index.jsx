import React, { useEffect, useState } from "react";
import "./styles/style.css";
import { useHistory } from "react-router-dom";
import { FormF } from "../../../components/Forms/FormFive";
import { api } from "../../../services/api";
import { FiMail, FiPhone } from "react-icons/fi";
import { MdOutlineLock, MdLocationPin, MdClose, MdEdit } from "react-icons/md";
import { AiOutlineUser } from "react-icons/ai";
import { HiOutlineDocumentText } from "react-icons/hi";
import { FaRegNewspaper } from "react-icons/fa";
import { ListSixElements } from "../../../components/Lists/ListSixElements/index";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Button } from "../../../components/Common/Button";

export function Instituicao() {
  const history = useHistory();
  const [idInstitute, setIdInstitute] = useState("");
  const [fantasyName, setFantasyName] = useState("");
  const [socialReason, setSocialReason] = useState("");
  const [adress, setAdress] = useState("");
  const [CNPJ, setCNPJ] = useState("");
  const [phone, setPhone] = useState("");
  const [listInstution, setListInstitution] = useState([]);

  useEffect(() => {
    getInstitutions();
  }, []);

  const createInstitute = async (e) => {
    e.preventDefault();

    console.log("entrou no método");
    try {
      const { data, status } = await api.post("/instituicoes", {
        NomeFantasia: fantasyName,
        RazaoSocial: socialReason,
        Endereco: adress,
        CNPJ,
        Telefone: phone,
      });

      if (status === 201) {
        localStorage.setItem("userToken", data.token);
        console.log("A instituição foi cadastrada");
        console.log(data);

        await getInstitutions();
        success();
        limparDados();
      }
    } catch (error) {
      errorPopup();
    }
  };

  async function getInstitutions() {
    const { data, status } = await api.get("/instituicoes");
    // console.log("Entrou no método de Get");
    if (status === 200) {
      setListInstitution(data);
      console.log(data);
      console.log("A listagem de instituições funcionou");
    }
  }

  const redirectBack = async (e) => {
    history.push("/cadastro");
  };

  async function updateInstitute(
    id,
    nomeFantasia,
    razaoSocial,
    endereco,
    cnpj,
    telefone
  ) {
    try {
      const { status } = await api.put(`/instituicoes/${id}`, {
        id,
        nomeFantasia,
        razaoSocial,
        endereco,
        cnpj,
        telefone,
      });

      if (status === 204) {
      }
    } catch (error) {}
  }

  async function deleteInstitute(id) {
    try {
      const { status } = await api.delete(`/instituicoes/${id}`);
      if (status === 204) {
        deleteSuccess();
        getInstitutions();
      }
    } catch (error) {
      let errorReason = error;
      deleteError();
    }
  }
  function limparDados() {
    setFantasyName("");
    setSocialReason("");
    setAdress("");
    setCNPJ("");
    setPhone("");
  }
  //#region Popups de aviso
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
  const errorPopup = () =>
    toast.error(
      "Infelizmente houve algum erro no seu cadastro, tente novamente.",
      {
        position: "top-right",
        autoClose: 5000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
      }
    );
  const deleteError = () => {
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
  const deleteSuccess = () => {
    toast.success("Sua instituição foi excluída com sucesso!", {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
    });
  };
  //#endregion
  return (
    <div className="instituteScreen">
      <div className="contentArea">
        <div className="displayColumn">
          <div className="instituteReturn">
            <a onClick={redirectBack}>Voltar</a>
          </div>
          <div className="instituteRow">
            <div className="formColumn">
              <FormF
                title="instituição"
                onSubmit={createInstitute}
                type="text"
                placeholder="Nome Fantasia"
                state={fantasyName}
                method={(e) => setFantasyName(e.target.value)}
                icon={<AiOutlineUser />}
                type2="text"
                placeholder2="Razão Social"
                state2={socialReason}
                method2={(e) => setSocialReason(e.target.value)}
                icon2={<FaRegNewspaper />}
                type3="text"
                placeholder3="Endereço"
                state3={adress}
                method3={(e) => setAdress(e.target.value)}
                icon3={<MdLocationPin />}
                type4="number"
                placeholder4="CNPJ"
                state4={CNPJ}
                method4={(e) => setCNPJ(e.target.value)}
                icon4={<HiOutlineDocumentText />}
                type5="number"
                placeholder5="Telefone"
                state5={phone}
                method5={(e) => setPhone(e.target.value)}
                icon5={<FiPhone />}
              ></FormF>
              {/* <Button disable={false} onClick={updateInstitute}>
                Atualizar
              </Button> */}
              <ToastContainer
                position="top-right"
                autoClose={5000}
                hideProgressBar={false}
                newestOnTop={false}
                closeOnClick
                rtl={false}
                pauseOnFocusLoss
                draggable
                pauseOnHover
              />
            </div>

            <ListSixElements title="Listagem de instituições">
              <tr>
                {/* <th>ID Instituição</th> */}
                <th>Nome Fantasia</th>
                <th>Razão Social</th>
                <th>Enredeço</th>
                <th>CNPJ</th>
                <th>Telefone</th>
                <th>Ações</th>
              </tr>
              {listInstution.map((item) => (
                <tr key={item.idInstituicao} className="trBody">
                  {/* <td>{item.idInstituicao}</td> */}
                  <td>{item.nomeFantasia}</td>
                  <td>{item.razaoSocial}</td>
                  <td>{item.endereco}</td>
                  <td>{item.cnpj}</td>
                  <td>{item.telefone}</td>
                  <td>
                    <div id="icons">
                      <MdEdit
                        onClick={() => {
                          setFantasyName(item.nomeFantasia);
                          setSocialReason(item.razaoSocial);
                          setAdress(item.endereco);
                          setCNPJ(item.cnpj);
                          setPhone(item.telefone);
                        }}
                        className="icon edit-icon"
                      />
                      <MdClose
                        onClick={() => deleteInstitute(item.idInstituicao)}
                        className="icon close-icon"
                      />
                    </div>
                  </td>
                </tr>
              ))}
            </ListSixElements>
          </div>
        </div>
      </div>
    </div>
  );
}
