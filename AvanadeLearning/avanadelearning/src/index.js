import React from "react";
import ReactDOM from "react-dom";
import { Login } from "./pages/Login";
import { Cadastro } from "./pages/Cadastro";
import { Home } from "../src/pages/Home/home";
import { Curso } from "./pages/Curso/curso";
import { Instituicao } from "./pages/Forms/Instituicao";
import { Aula } from "./pages/Aula";
import { CadastrarCurso } from "./pages/Forms/Curso";
import { Perfil } from "./pages/Perfil";
import "./index.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

export const routing = (
  <Router>
    <Switch>
      <Route path="/login" component={Login} />
      <Route path="/cadastro" component={Cadastro} />
      <Route path="/curso" component={Curso} />
      <Route path="/postCurso" component={CadastrarCurso} />
      <Route path="/instituicao" component={Instituicao} />
      <Route path="/aula/:idCurso/:nome" component={Aula} />
      <Route path="/Perfil" component={Perfil} />
      <Route path="*" component={Home} />
    </Switch>
  </Router>
);

ReactDOM.render(routing, document.getElementById("root"));
