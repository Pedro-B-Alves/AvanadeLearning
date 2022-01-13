import "./styles/style.css";
import { api } from "../../../services/api";

// importando icones do react
import { MdClose, MdEdit } from "react-icons/md";
import { IoImagesOutline } from "react-icons/io5";
import { MdOutlineDescription } from "react-icons/md";
import { AiOutlineClockCircle } from "react-icons/ai";
import { BsBank2 } from "react-icons/bs";

//https://stock.adobe.com/br/images/id/200844990?as_campaign=Flaticon&as_content=api&as_audience=idp&tduid=c6ebecb0f44c74f81130ec7b58cc9b30&as_channel=affiliate&as_campclass=redirect&as_source=arvato

//insert into aula values ('youtube.com/watch?v=Gq02CTw-Oc8', 'Nesta aula vamos aprender tudo que voce precisa saber sobre administração', 'adm.pdf', 'Administração')

import { useHistory } from "react-router-dom";
import { FormF } from "../../../components/Forms/FormFive";
import "react-toastify/dist/ReactToastify.css";
import { ListSixElements } from "../../../components/Lists/ListSixElements/index";
import React, { useEffect, useState } from "react";
import { ToastContainer, toast } from "react-toastify";


export function CadastrarCurso() {
    const history = useHistory();
    const [idCurso, setIdCurso] = useState("");
    const [idInstituicao, setInstituicao] = useState("");
    const [nome, setName] = useState("");
    const [descricao, setDescricao] = useState("");
    const [imagem, setImagem] = useState("");
    const [horas, setHoras] = useState("");
    const [video, setVideo] = useState("");
    const [listaCurso, setListaCurso] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    // redireciona para a tela de cursos
    const redirectBack = async (e) => {
        history.push("/curso");
    };

    //renderiza 
    useEffect(() => {
        getCursos();
    }, []);

    //mapeando a lista de cursos
    async function getCursos() {

        const { data, status } = await api.get("/Cursos");
        // console.log("Entrou no método de Get");
        if (status === 200) {
            setListaCurso(data);
            console.log(data);
            console.log("Listagem de cursos feita com sucesso!");
        }
    }

    // retorna uma string vazia setando todos os dados
    function limparDados() {
        setInstituicao("");
        setName("");
        setDescricao("");
        setHoras("");
        setImagem("");
    }

    // deletar cursos
    async function deleteCurse(id) {
        try {
            const { status } = await api.delete(`/Cursos/${id}`);
            if (status === 204) {
                deleteCurse();
                getCursos();
            }
        } catch (error) {
            deleteError();
        }
    }



    // chamada para o cadastro de cursos
    const createCurse = async (e) => {
        e.preventDefault();
        console.log("entrou no metodo")
        try {
            const { data, status } = await api.post("/cursos", {
                idInstituicao: idInstituicao,
                nome: nome,
                descricao: descricao,
                imagem: imagem,
                horas: horas,
            });

            if (status === 201) {
                localStorage.setItem("userToken", data.token);
                console.log("O curso foi cadastrado com sucesso!");
                console.log(data);

                await getCursos();

                //retorna uma popup de sucesso
                success();
                limparDados();
            }

        } catch (error) {
            // retorna um popup de erro
            errorPopup();
        }
    }

    //atualiza os cursos existentes
    const updateCurse = async (id) => {
        setIsLoading(true);

        try {
            const { data, status } = await api.put(`/Cursos/${id}`, {
                idInstituicao: idInstituicao,
                nome: nome,
                descricao: descricao,
                imagem: imagem,
                horas: horas,
            });

            if (status === 204) {
                localStorage.setItem("userToken", data.token);
                console.log("O curso foi atualizado com sucesso!");
                console.log(data);

                success();
            }
        } catch (error) {
            updateError(error);
        }
    }

    //#region Popups de aviso
    const success = () =>
        toast.success("Seu curso foi cadastrado com sucesso!", {
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

    const updateError = () => {
        toast.error("Infelizmente seu curso não pode ser atualizado!", {
            position: "top-right",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
        });
    }

    const updateSuccess = () => {
        toast.success("Seu curso foi atualizado com sucesso!", {
            position: "top-right",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
        });
    }

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
        toast.success("Seu curso foi excluído com sucesso!", {
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
        <div className="curseScreen">
            <div className="contentArea">
                <div className="displayColumn">
                    <div className="curseReturn">
                        <a onClick ={redirectBack}>Voltar</a>
                    </div>
                    {/* Seção formulário */}
                    <div className="curseRow">
                        <div classNama="colunmForm">
                            <FormF
                                title="Cursos"
                                title1="id da Instituição"
                                type="number"
                                placeholder="Id Instituição"
                                state={idInstituicao}
                                method={(e) => setInstituicao(e.target.value)}
                                icon={<BsBank2 />}

                                title2="Curso"
                                type2="text"
                                placeholder2="Curso"
                                state2={nome}
                                method2={(e) => setName(e.target.value)}
                                icon2={<MdOutlineDescription />}

                                title3="descrição"
                                type3="text"
                                placeholder3="Descrição"
                                state3={descricao}
                                method3={(e) => setDescricao(e.target.value)}
                                icon3={<MdOutlineDescription />}

                                title4="imagem"
                                // type4="file"
                                type4="file"
                                placeholder4="Imagem"
                                state4={imagem}
                                method4={(e) => setImagem(e.target.value)}
                                icon4={<IoImagesOutline />}

                                title5="horas"
                                type5="number"
                                placeholder5="Horas"
                                state5={horas}
                                method5={(e) => setHoras(e.target.value)}
                                icon5={<AiOutlineClockCircle />}

                                onSubmit={createCurse}
                            >
                            </FormF>


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

                        {/* Tabela da listagem de cursos */}
                        <ListSixElements title="Listagem dos cursos">
                            <tr >
                                <th>id da Instituição</th>
                                <th>Curso</th>
                                <th>Descriçao</th>
                                <th>Imagem</th>
                                <th>Horas</th>
                            </tr>
                            {/* Lista dos cursos existentes */}
                            {listaCurso.map((curso) => (
                                <tr key={curso.idCurso} className="trBody">
                                    <td>{curso.idInstituicao}</td>
                                    <td>{curso.nome}</td>
                                    <td>{curso.descricao}</td>
                                    <td>{curso.imagem}</td>
                                    <td>{curso.horas}</td>

                                    {/* <td>{curso.pontos}</td> */}
                                    <td>
                                        <div id="icons">
                                            <MdEdit
                                                onClick={() => {
                                                    setInstituicao(curso.idInstituicao);
                                                    setName(curso.nome);
                                                    setDescricao(curso.descricao);
                                                    setImagem(curso.imagem);
                                                    setHoras(curso.horas);
                                                    
                                                }}
                                                className="icon edit-icon"
                                                onClick={() => updateCurse(curso.idCurso)}

                                            />

                                            <MdClose
                                                // onClick={() => deleteCursos(curso.idCurso)}
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
    )
}