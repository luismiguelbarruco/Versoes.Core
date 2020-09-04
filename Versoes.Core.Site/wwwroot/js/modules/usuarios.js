import { api } from '../modules/api.js';
import { modalsucesso, modalerro } from '../modules/modal-helper.js';

export default function initUsuarios() {

    const apiUsuarios = api + '/usuarios';
    const tbodyUsuario = document.querySelector('#tableUsuarios tbody');
    const modalModificaUsuario = document.querySelector("#modal-usuario");

    //Eventos
    modalModificaUsuario.querySelector('#formUsuario').addEventListener("submit", handleSubmit);

    //Chamada inicial da página de usuarios
    handleGetAllUsuarios();






    function handleSubmit(event) {
        event.preventDefault();
        event.stopPropagation();

        if (this.checkValidity()) {
            const Nome = this.querySelector('#nome').value;
            const Id = +this.querySelector('#id').value;
            const Status = +this.querySelector('#status').value;

            // console.log(JSON.stringify({ Id, Nome, Status }));
            if (Id) {
                handlePutUsuario({ Id, Nome, Status })
            } else {
                handlePostUsuario({ Nome, Status });
            }
        }
        this.classList.add('was-validated');
    }

    function adicionarUsuarioNaTabela(data) {
        console.log(data);
        if (!tbodyUsuario)
            return;

        tbodyUsuario.innerHTML = "";
        if (!data) {
            const linha = document.createElement('tr');
            linha.innerHTML = ('<td colspan="6" class="text-center text-mcm">Nenhum registro foi encontrado</td>');

            tbodyUsuario.insertBefore(linha, null);
            return;
        }

        data.forEach((usuario) => {
            //console.log(usuario);
            const linha = document.createElement('tr');
            const colunaId = document.createElement('td');
            colunaId.innerHTML = "<b>" + usuario.id + "</b>";

            const colunaSigla = document.createElement('td');
            const contentSigla = document.createTextNode(usuario.sigla);
            colunaSigla.appendChild(contentSigla);


            const colunaNome = document.createElement('td');
            const contentNome = document.createTextNode(usuario.nome);
            colunaNome.appendChild(contentNome);

            const colunaSetor = document.createElement('td');
            const contentSetor = document.createTextNode(usuario.setor.nome);
            colunaSetor.appendChild(contentSetor);

            const colunaStatus = document.createElement('td');

            if (usuario.status === 0)
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-success' style='font-size:90%; font-weight:500'>Normal</span>";
            else if (usuario.status === 1)
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-secondary' style='font-size:90%; font-weight:500'>Bloqueado </span>";
            else
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-danger' style='font-size:90%; font-weight:500'>Excluído </span>";

            const colunaAcao = document.createElement('td');
            colunaAcao.innerHTML = "<a href='#' data-toggle='modal' data-target='#modal-usuario' data-status='" + usuario.status + "' data-id='" + usuario.id + "' data-nome='" + usuario.nome + "'  class='edit mr-1'> <i class='far fa-edit text-primary' ></i>" +
                "<a href='#' data-toggle='modal' data-target='#modal-usuario-exclusao' data-status='" + usuario.status + "' data-id='" + usuario.id + "' data-nome='" + usuario.nome + "' > " +
                "<i class='fas fa-trash-alt text-danger ' ></i></a>";

            linha.appendChild(colunaId);
            linha.appendChild(colunaSigla);
            linha.appendChild(colunaNome);
            linha.appendChild(colunaSetor);
            linha.appendChild(colunaStatus);
            linha.appendChild(colunaAcao);
            tbodyUsuario.insertBefore(linha, null);
        });

    }

    async function handlePutUsuario(dados) {

        try {

            const response = await axios.put(apiUsuarios, dados);

            if (response.data.success) {
                modalsucesso.fire({
                    text: response.data.message,
                    onClose: () => {
                        $('#modal-usuario').modal('hide');
                        window.location.reload();
                    }
                });
            } else {
                modalerro.fire({
                    text: response.data.message
                });
            }

        } catch (err) {
            modalerro.fire({
                text: 'Erro inesperado ao atualizar usuario'
            });
            console.error(err);
        }
    }

    async function handlePostUsuario(dados) {

        try {
            const response = await axios.post(apiUsuarios, dados);

            if (response.data.success) {
                modalsucesso.fire({
                    text: response.data.message,
                    onClose: () => {
                        $('#modal-usuario').modal('hide');
                        window.location.reload();
                    }
                });
            } else {
                modalerro.fire({
                    text: response.data.message
                });
            }

        } catch (err) {
            modalerro.fire({
                text: 'Erro inesperado ao cadastrar usuario'
            });
            console.error(err);
        }
    }

    async function handleGetAllUsuarios() {

        const linha = document.createElement('tr');
        linha.innerHTML = ('<td colspan="5" class="text-center text-mcm">Carregando usuarios...</td>');
        tbodyUsuario.insertBefore(linha, null);

        try {
            const response = await axios.get(apiUsuarios);
            if (response.data.success) {
                adicionarUsuarioNaTabela(response.data.data);
            } else {
                adicionarUsuarioNaTabela(null);
                modalerro.fire({
                    text: response.data.message
                });
            }
        } catch (error) {
            handleErrorApi(error);
        }
    }

    function handleErrorApi(error) {
        if (error.response) {
            if (error.response.status === 401) {
                modalerro.fire({
                    title: "Não autorizado",
                    text: 'Usuário não está autenticado para este recurso.',
                    onClose: () => {
                        document.location.href = '/Usuario/Login';
                    }
                });
            } else {
                console.log(error.config);
                modalerro.fire({
                    text: 'Falha de comunicação com a API'
                });
                adicionarUsuarioNaTabela(null);
            }
        }
    }


    $('#modal-usuario-exclusao').on('show.bs.modal', function(event) {

        const id = +event.relatedTarget.dataset.id;
        const nome = event.relatedTarget.dataset.nome;
        this.querySelector('.usuario-nome').innerText = nome;
        this.querySelector('input[name=id]').value = id;




    });
    /*Evento acionado ao abril modal */
    $('#modal-usuario').on('show.bs.modal', function(event) {
        handleModalStyleByOperation(event.relatedTarget, this, 'usuário');
        const id = +event.relatedTarget.dataset.id;
        const nome = event.relatedTarget.dataset.nome;
        const status = +event.relatedTarget.dataset.status;

        if (!isNaN(id)) {
            this.querySelector('input[name=id]').value = id;
            this.querySelector('input[name=nome]').value = nome;
            this.querySelector('select[name=status]').value = status;
        }




    });

    //gambiarra para ter foco no primeiro campo do modal, ver depois outra forma de fazer
    $('#modal-usuario').on('shown.bs.modal', function() {
        $('#Nome').trigger('focus');
    });

    /*Evento acionado ao fechar modal*/
    $('#modal-usuario').on('hide.bs.modal', function(e) {
        document.querySelector('#formUsuario').classList.remove('was-validated');
        document.querySelector('#formUsuario').reset();
    })

    /* Função para controlar estilo do modal quando for operação de cadastro ou alteração usuario */
    function handleModalStyleByOperation(botaoAcionado, modal, entidade) {
        const modalheader = modal.querySelector(".modal-header");
        const modaltitle = modal.querySelector('.modal-title');
        const modalSubmit = modal.querySelector('button[type=submit]');

        if (botaoAcionado.classList.contains('btn-success')) {
            modalheader.className = 'modal-header bg-success';
            modaltitle.innerHTML = '<i class="fas fa-plus"></i> Novo ' + entidade;
            modalSubmit.className = 'btn btn-success';
            modal.querySelector(".js-status").setAttribute('style', 'display:none');

        } else {
            modalheader.className = 'modal-header bg-primary';
            modaltitle.innerHTML = '<i class="far fa-edit"></i> Modificar ' + entidade;
            modalSubmit.className = 'btn btn-primary';
            modal.querySelector(".js-status").setAttribute('style', 'display:block');
        }
    }

}