$(document).ready(function () {
    $(".selection-btn").click(function () {
        $(this).toggleClass("selected");

        const selecaoId = $(this).data("id");

        const selecao = verifcarContainer(`#selecaoId-${selecaoId}`);
        if (selecao.length === 0) {
            $.get("Formulario/ObterSelecao", { selecaoId: selecaoId }, function (data) {
                const container = verifcarContainer("#section2-container");
                $("#section2-container").html(container + data);
            });
            return;
        }

        $(`#selecaoId-${selecaoId}`).remove();
        return;
    });
});

function verifcarContainer(item) {
    const container = $(item).html();
    return container ? container : "";
}