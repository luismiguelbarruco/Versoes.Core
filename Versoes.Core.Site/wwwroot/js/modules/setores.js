import { api } from '../modules/api.js';

export default function initSetores() {
    const apiSetores = api + '/setores';

    document.querySelector('#formSetor').addEventListener("submit", handleSubmit);

    function handleSubmit(event) {
        event.preventDefault();
        event.stopPropagation();

        if (this.checkValidity()) {

            const dados = [];
            const Nome = this.querySelector('#Nome').value;
            const Id = this.querySelector('#Id').value;
            const Status = this.querySelector('#Status').value;
            dados.push({ Id, Nome, Status });
            gravarDados(dados);

        }
        this.classList.add('was-validated');
    }

    function gravarDados(dados) {

        if (dados.Id) {

        } else {
            console.log(dados);


            axios.post(apiSetores, dados, {
                    headers: {
                        "Content-Type": "application/json;charset=UTF-8"
                    }
                })
                .then(function(response) {
                    console.log(response);
                });
        }
    }

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