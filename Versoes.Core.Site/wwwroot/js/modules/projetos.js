import { api } from '../modules/api.js';
import { modalsucesso, modalerro } from '../modules/modal-helper.js';

export default function initProjetos() {

    const apiProjetos = api + '/projetos';
    const tbodyProjeto = document.querySelector('#tableProjetos tbody');
    const modalModificaProjeto = document.querySelector("#modal-projeto");

    //Eventos
    modalModificaProjeto.querySelector('#formProjeto').addEventListener("submit", handleSubmit);

    //Chamada inicial da página de projetos
    handleGetAllProjetos();






    function handleSubmit(event) {
        event.preventDefault();
        event.stopPropagation();

        if (this.checkValidity()) {
            const Nome = this.querySelector('#nome').value;
            const Id = +this.querySelector('#id').value;
            const Status = +this.querySelector('#status').value;

            if (Id) {
                handlePutProjeto({ Id, Nome, Status })
            } else {
                handlePostProjeto({ Nome, Status });
            }
        }
        this.classList.add('was-validated');
    }

    function adicionarProjetoNaTabela(data) {

        if (!tbodyProjeto)
            return;

        tbodyProjeto.innerHTML = "";
        if (!data) {
            const linha = document.createElement('tr');
            linha.innerHTML = ('<td colspan="6" class="text-center text-mcm">Nenhum registro foi encontrado</td>');

            tbodyProjeto.insertBefore(linha, null);
            return;
        }

        data.forEach((projeto) => {
            const linha = document.createElement('tr');
            const colunaId = document.createElement('td');
            colunaId.innerHTML = "<b>" + projeto.id + "</b>";

            const colunaNome = document.createElement('td');
            const contentNome = document.createTextNode(projeto.nome);
            colunaNome.appendChild(contentNome);

            const colunaStatus = document.createElement('td');

            if (projeto.status === 0)
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-success' style='font-size:90%; font-weight:500'>Normal</span>";
            else if (projeto.status === 1)
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-secondary' style='font-size:90%; font-weight:500'>Bloqueado </span>";
            else
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-danger' style='font-size:90%; font-weight:500'>Excluído </span>";

            const colunaAcao = document.createElement('td');
            colunaAcao.innerHTML = "<a href='#' data-toggle='modal' data-target='#modal-projeto' data-status='" + projeto.status + "' data-id='" + projeto.id + "' data-nome='" + projeto.nome + "'  class='edit mr-1'> <i class='far fa-edit text-primary' ></i>" +
                "<a href='#' data-toggle='modal' data-target='#modal-projeto-exclusao' data-status='" + projeto.status + "' data-id='" + projeto.id + "' data-nome='" + projeto.nome + "' > " +
                "<i class='fas fa-trash-alt text-danger ' ></i></a>";

            linha.appendChild(colunaId);
            linha.appendChild(colunaNome);
            linha.appendChild(colunaStatus);
            linha.appendChild(colunaAcao);
            tbodyProjeto.insertBefore(linha, null);
        });

    }

    async function handlePutProjeto(dados) {

        try {

            const response = await axios.put(apiProjetos, dados);

            if (response.data.success) {
                modalsucesso.fire({
                    text: response.data.message,
                    onClose: () => {
                        $('#modal-projeto').modal('hide');
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
                text: 'Erro inesperado ao atualizar projeto'
            });
            console.error(err);
        }
    }

    async function handlePostProjeto(dados) {

        try {
            const response = await axios.post(apiProjetos, dados);

            if (response.data.success) {
                modalsucesso.fire({
                    text: response.data.message,
                    onClose: () => {
                        $('#modal-projeto').modal('hide');
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
                text: 'Erro inesperado ao cadastrar projeto'
            });
            console.error(err);
        }
    }

    async function handleGetAllProjetos() {

        const linha = document.createElement('tr');
        linha.innerHTML = ('<td colspan="5" class="text-center text-mcm">Carregando projetos...</td>');
        tbodyProjeto.insertBefore(linha, null);

        try {
            const response = await axios.get(apiProjetos);
            if (response.data.success) {
                adicionarProjetoNaTabela(response.data.data);
            } else {
                adicionarProjetoNaTabela(null);
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
                adicionarProjetoNaTabela(null);
            }
        }
    }


    $('#modal-projeto-exclusao').on('show.bs.modal', function(event) {

        const id = +event.relatedTarget.dataset.id;
        const nome = event.relatedTarget.dataset.nome;
        this.querySelector('.projeto-nome').innerText = nome;
        this.querySelector('input[name=id]').value = id;




    });
    /*Evento acionado ao abril modal */
    $('#modal-projeto').on('show.bs.modal', function(event) {
        handleModalStyleByOperation(event.relatedTarget, this, 'Projeto');
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
    $('#modal-projeto').on('shown.bs.modal', function() {
        $('#Nome').trigger('focus');
    });

    /*Evento acionado ao fechar modal*/
    $('#modal-projeto').on('hide.bs.modal', function(e) {
        document.querySelector('#formProjeto').classList.remove('was-validated');
        document.querySelector('#formProjeto').reset();
    })

    /* Função para controlar estilo do modal quando for operação de cadastro ou alteração de projeto */
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