import { api } from '../modules/api.js';
import { modalsucesso, modalerro } from '../modules/modal-helper.js';

export default function initSetores() {

    const apiSetores = api + '/setores';
    document.querySelector('#formSetor').addEventListener("submit", handleSubmit);


    function handleSubmit(event) {
        event.preventDefault();
        event.stopPropagation();

        if (this.checkValidity()) {
            const Nome = this.querySelector('#Nome').value;
            const Id = +this.querySelector('#Id').value;
            const Status = +this.querySelector('#Status').value;

            // console.log(JSON.stringify({ Id, Nome, Status }));
            if (Id) {
                handlePutSetor({ Id, Nome, Status })
            } else {
                handlePostSetor({ Nome, Status });
            }
        }
        this.classList.add('was-validated');
    }

    async function handlePutSetor(dados) {

        try {
            const response = await axios.put(apiSetores, dados);

            if (response.data.success) {
                modalsucesso.fire({
                    text: response.data.message,
                    onClose: () => {
                        $('#modal-setor').modal('hide');
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
    };

    async function handlePostSetor(dados) {

        try {
            const response = await axios.post(apiSetores, dados);

            if (response.data.success) {
                modalsucesso.fire({
                    text: response.data.message,
                    onClose: () => {
                        $('#modal-setor').modal('hide');
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
    };

    function listarSetores() {
        axios.get(apiSetores)
            .then(function(response) {
                console.log(response);
            });
    }

    /*Evento acionado ao abril modal */
    $('#modal-setor').on('show.bs.modal', function(event) {
        handleModalStyleByOperation(event.relatedTarget, this, 'Setor');
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