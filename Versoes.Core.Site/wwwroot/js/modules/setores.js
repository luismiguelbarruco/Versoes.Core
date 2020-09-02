import { api } from '../modules/api.js';
import { modalsucesso, modalerro } from '../modules/modal-helper.js';

export default function initSetores() {

    const apiSetores = api + '/setores';
    const tbodySetor = document.querySelector('#tableSetores tbody');
    const modalModificaSetor = document.querySelector("#modal-setor");

    //Eventos
    modalModificaSetor.querySelector('#formSetor').addEventListener("submit", handleSubmit);

    //Chamada inicial da página de setores
    handleGetAllSetores();






    function handleSubmit(event) {
        event.preventDefault();
        event.stopPropagation();

        if (this.checkValidity()) {
            const Nome = this.querySelector('#nome').value;
            const Id = +this.querySelector('#id').value;
            const Status = +this.querySelector('#status').value;

            // console.log(JSON.stringify({ Id, Nome, Status }));
            if (Id) {
                handlePutSetor({ Id, Nome, Status })
            } else {
                handlePostSetor({ Nome, Status });
            }
        }
        this.classList.add('was-validated');
    }

    function adicionarSetorNaTabela(data) {

        if (!tbodySetor)
            return;

        tbodySetor.innerHTML = "";
        if (!data) {
            const linha = document.createElement('tr');
            linha.innerHTML = ('<td colspan="6" class="text-center text-mcm">Nenhum registro foi encontrado</td>');

            tbodySetor.insertBefore(linha, null);
            return;
        }

        data.forEach((setor) => {
            //console.log(setor);
            const linha = document.createElement('tr');
            const colunaId = document.createElement('td');
            colunaId.innerHTML = "<b>" + setor.id + "</b>";

            const colunaNome = document.createElement('td');
            const contentNome = document.createTextNode(setor.nome);
            colunaNome.appendChild(contentNome);

            const colunaQtdeFuncionario = document.createElement('td');
            const contentQtdeFuncionario = document.createTextNode(setor.totalUsuariosPorSetor);
            colunaQtdeFuncionario.appendChild(contentQtdeFuncionario);

            const colunaStatus = document.createElement('td');

            if (setor.status === 0)
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-success' style='font-size:90%; font-weight:500'>Normal</span>";
            else if (setor.status === 1)
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-secondary' style='font-size:90%; font-weight:500'>Bloqueado </span>";
            else
                colunaStatus.innerHTML = "<span class='badge badge-pill badge-danger' style='font-size:90%; font-weight:500'>Excluído </span>";

            const colunaAcao = document.createElement('td');
            colunaAcao.innerHTML = "<a href='#' data-toggle='modal' data-target='#modal-setor' data-status='" + setor.status + "' data-id='" + setor.id + "' data-nome='" + setor.nome + "'  class='edit mr-1'> <i class='far fa-edit text-primary' ></i>" +
                "<a href='#' data-toggle='modal' data-target='#modal-setor-exclusao' data-status='" + setor.status + "' data-id='" + setor.id + "' data-nome='" + setor.nome + "' > " +
                "<i class='fas fa-trash-alt text-danger ' ></i></a>";

            linha.appendChild(colunaId);
            linha.appendChild(colunaNome);
            linha.appendChild(colunaQtdeFuncionario);
            linha.appendChild(colunaStatus);
            linha.appendChild(colunaAcao);
            tbodySetor.insertBefore(linha, null);
        });

    }

    async function handlePutSetor(dados) {

        try {

            const response = await axios.put(apiSetores, dados);

            if (response.data.success) {
                modalsucesso.fire({
                    text: response.data.message,
                    onClose: () => {
                        $('#modal-setor').modal('hide');
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
                text: 'Erro inesperado ao atualizar setor'
            });
            console.error(err);
        }
    }

    async function handlePostSetor(dados) {

        try {
            const response = await axios.post(apiSetores, dados);

            if (response.data.success) {
                modalsucesso.fire({
                    text: response.data.message,
                    onClose: () => {
                        $('#modal-setor').modal('hide');
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
                text: 'Erro inesperado ao cadastrar setor'
            });
            console.error(err);
        }
    }

    async function handleGetAllSetores() {

        const linha = document.createElement('tr');
        linha.innerHTML = ('<td colspan="5" class="text-center text-mcm">Carregando setores...</td>');
        tbodySetor.insertBefore(linha, null);

        try {
            const response = await axios.get(apiSetores);
            if (response.data.success) {
                adicionarSetorNaTabela(response.data.data);
            } else {
                adicionarSetorNaTabela(null);
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
                adicionarSetorNaTabela(null);
            }
        }
    }


    $('#modal-setor-exclusao').on('show.bs.modal', function(event) {

        const id = +event.relatedTarget.dataset.id;
        const nome = event.relatedTarget.dataset.nome;
        this.querySelector('.setor-nome').innerText = nome;
        this.querySelector('input[name=id]').value = id;




    });
    /*Evento acionado ao abril modal */
    $('#modal-setor').on('show.bs.modal', function(event) {
        handleModalStyleByOperation(event.relatedTarget, this, 'Setor');
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
    $('#modal-setor').on('shown.bs.modal', function() {
        $('#Nome').trigger('focus');
    });

    /*Evento acionado ao fechar modal*/
    $('#modal-setor').on('hide.bs.modal', function(e) {
        document.querySelector('#formSetor').classList.remove('was-validated');
        document.querySelector('#formSetor').reset();
    })

    /* Função para controlar estilo do modal quando for operação de cadastro ou alteração setor */
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