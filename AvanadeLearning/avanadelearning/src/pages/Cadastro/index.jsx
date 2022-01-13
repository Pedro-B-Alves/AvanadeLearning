import React, { useState } from "react";
import "./styles/style.css";
import { FiMail } from "react-icons/fi";
import { FaArrowLeft } from "react-icons/fa";
import { MdOutlineLock } from "react-icons/md";
import { AiOutlineUser } from "react-icons/ai";
import { useHistory } from "react-router";
import { api } from "../../services/api";
import Logo from "../../assets/img/logoPedro.svg";
import { Button } from "../../components/Common/Button";
import { Input } from "../../components/Common/Input";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export function Cadastro() {
  const history = useHistory();
  const [email, setEmail] = useState("");
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  // const userInfo = localStorage.getItem('userToken') !== null && parseJwt();

  const createAccount = async (e) => {
    e.preventDefault();
    const token = localStorage.getItem("userToken");

    if (password == confirmPassword) {
      //console.log("A senha de confirmação era igual a senha passada.");
      try {
        console.log(email, name, password, confirmPassword);

        let form = new FormData();
        form.append("idTipoUsuario", 1);
        form.append("Nome", name);
        form.append("Email", email);
        form.append("Senha", password);

        //console.log("Entrou no Try ao invés do Catch");
        const { data, status } = await api.post("/usuarios", form);

        //console.log("A aplicação passou pela requisição da API");
        if (status === 201) history.push("/login");
      } catch (error) {
        //console.log(error.message);
        //console.log(name);
        errorPopup();
      }
    } else {
      setErrorMessage("Dados Inválidos");
      console.log(errorMessage);
    }
  };

  const redirectLogin = async (e) => {
    history.push("/login");
  };

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

  return (
    <div>
      <div className="contentArea">
        <div className="sectionAreaAround">
          <form onSubmit={(e) => createAccount(e)} className="formFromSignIn">
            <h1>Crie sua conta</h1>
            <div>
              <Input
                type="email"
                placeholder="Seu E-mail"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                icon={<FiMail />}
              />
              <Input
                type="text"
                placeholder="Seu Nome"
                value={name}
                onChange={(e) => setName(e.target.value)}
                icon={<AiOutlineUser />}
              />
              <Input
                type="password"
                placeholder="Sua Senha"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                icon={<MdOutlineLock />}
              />
              <Input
                type="password"
                placeholder="Confirme sua senha"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
                icon={<MdOutlineLock />}
              />
              <p className="termText">
                Ao se registrar, você aceita nossos{" "}
                <a className="gambi">termos de uso</a> e a nossa{" "}
                <a className="gambi">política de privacidade</a>.
              </p>
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
              <Button type="submit">Cadastrar</Button>
            </div>
          </form>
          <div className="sectionWithContent">
            <div className="logoArea">
              <img src={Logo} />
              <h1>Avanade Learning</h1>
            </div>
            <div className="textAreaRegister">
              <h2>Mais de 50 mil Avanade students já estão conectados.</h2>
              <h3>
                Junte-se a milhares de guerreiros e guerreiras e venha fazer
                parte da melhor plataforma de cursos livres
              </h3>
            </div>
            <div className="returnLoginArea">
              <a onClick={redirectLogin} className="linkRedirectLogin">
                <i>{<FaArrowLeft />}</i>Voltar para Login
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
