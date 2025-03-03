function adicionarItem(selecaoId) {
    const dados = obterDadosIniciais(selecaoId);

    let html = verifcarContainerSelecao(`#campoId-${dados.ultimoCampoId}`, dados.selecao);
    if (html.length === 0) {
        return;
    }

    const campoId = dados.ultimoCampoId + 1;
    const containerCampos = verifcarContainerSelecao("#containerCampos", dados.selecao);

    html = html.replace(`selectedCampoIds-${(dados.ultimoCampoId - 1)}`, `selectedCampoIds-${dados.ultimoCampoId}`);
    html = html.replace(`Item ${dados.ultimoCampoId}`, `Item ${campoId}`);

    $("#containerCampos", dados.selecao).html(containerCampos + `<div id="campoId-${campoId}">${html}</div>`);

    $("#ultimoCampoId", dados.selecao).val(campoId);
}

function salvarItem(selecaoId) {
    const dados = obterDadosIniciais(selecaoId);

    let campoIds = [];
    for (let i = 0; i < dados.ultimoCampoId; i++) {
        campoIds.push(parseInt($(`#selectedCampoIds-${i}`, dados.selecao).val()));
    }

    $.post("Formulario/SalvarSelecao", { SelecaoId: selecaoId, CampoIds: campoIds }, function () {
        retornoSalvar("Selecao salva com sucesso!");
    });
}

function retornoSalvar(mensagem) {
    alert(mensagem);
    window.location.href = "/Formulario";
}

function abrirModal(item, selecaoId, campoId, formularioId) {
    const selecao = $(`#selecaoId-${selecaoId}`);

    $('#modal-body', selecao).modal('show');
    $("#modal-title", selecao).html(`Item ${item}`);
    $("#selectedCampoId", selecao).val(campoId);
    $("#formularioId", selecao).val(formularioId);
}

function fecharModal(selecaoId) {
    const selecao = $(`#selecaoId-${selecaoId}`);
    $('#modal-body', selecao).modal('hide');
}

function salvarModal(selecaoId) {
    const selecao = $(`#selecaoId-${selecaoId}`);
    const campoId = parseInt($("#selectedCampoId", selecao).val());
    const formularioId = parseInt($("#formularioId", selecao).val());

    $.post("Formulario/SalvarItem", { SelecaoId: selecaoId, CampoId: campoId, FormularioId: formularioId }, function () {
        retornoSalvar("Item salvo com sucesso!");
    });
}


function obterDadosIniciais(selecaoId) {
    const selecao = $(`#selecaoId-${selecaoId}`);
    const ultimoCampoId = parseInt($("#ultimoCampoId", selecao).val());
    return { selecao, ultimoCampoId };
}

function verifcarContainerSelecao(item, selecao) {
    const container = $(item, selecao).html();
    return container ? container : "";
}