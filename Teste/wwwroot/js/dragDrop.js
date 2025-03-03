var uploadFiles = {
    data: [],
    get get() {
        return this.data;
    },
    set set(valor) {
        this.data = valor;
    }
};

var idxImagens = {
    data: 0,
    get get() {
        return this.data;
    },
    set set(valor) {
        this.data = valor;
    }
};

var preview = {
    data: null,
    get get() {
        return this.data;
    },
    set set(valor) {
        this.data = valor;
    }
};

var dragDrop = {
    init: function (selecaoId) {
        const inputFile = document.getElementById(`inputFile-${selecaoId}`);
        const tablePreview = document.getElementById(`tablePreview-${selecaoId}`);
        const dropContainer = document.getElementById(`dropContainer-${selecaoId}`);

        uploadFiles.set = [];
        idxImagens.set = 0;
        preview.set = tablePreview;

        dropContainer.ondragover = dropContainer.ondragenter = function (evt) {
            evt.preventDefault();
        };

        dropContainer.ondrop = function (evt) {
            dragDrop.incluirUpload(evt.dataTransfer.files, selecaoId);
            evt.preventDefault();
        };

        inputFile.addEventListener('change', evt => {
            dragDrop.incluirUpload(evt.target.files, selecaoId);
        });
    },
    incluirUpload: function (files, selecaoId) {
        let getFiles = [];
        let upload = uploadFiles.get;
        const total = files.length;

        for (let x = 0; x < total; x++) {
            let file = files[x];
            if (dragDrop.podeFazerUpload(file)) {
                getFiles.push(file);
                upload.push(file);
            }
        }

        uploadFiles.set = upload;

        if (getFiles.length > 0) {
            dragDrop.preencherReview(getFiles, selecaoId);
        }

        $(`#inputFile-${selecaoId}`).val('');
        return;
    },
    podeFazerUpload: function (file) {
        if (!file) {
            alert('Arquivo não selecionado.');
            return false;
        }

        if (file.type !== 'image/jpeg' &&
            file.type !== 'image/jpg' &&
            file.type !== 'image/gif' &&
            file.type !== 'image/png') {
            alert(`${file.name} somente imagem (jpeg/jpg/gif/png) sao permitidas.`);
            return false;
        }

        const size = Math.round(file.size / 1024 / 1024);
        if (size > 10) {
            alert(`${file.name} maior que 10 MB.`);
            return false;
        }

        return true;
    },
    preencherReview: function (upload, selecaoId) {
        let district = '';
        let index = idxImagens.get;
        let tablePreview = preview.get;

        if (index === 0) {
            district = '<tr><th>Arquivo</th><th class=\'text-center\' width=\'20\'>Tamanho</th></tr>';
        }

        const total = upload.length;

        for (let x = 0; x < total; x++) {
            let fileName = upload[x].name;

            district = `${district}<tr id=\'linha-${selecaoId}_${index}\'>`;
            district = `${district}<td><span id=\'fileName_${index}\'>${fileName}</span></td>`;
            district = `${district}<td class=\'text-center\'>${Math.round(upload[x].size / 1024 / 1024)} MB</td>`;
            district = `${district}</tr>`;

            index++;
        }

        tablePreview.insertAdjacentHTML('beforeend', district);

        idxImagens.set = index;
        preview.set = tablePreview;
    },
    uploadInputFiles: function (selecaoId) {
        $(`#inputFile-${selecaoId}`).click();
    },
    obterUpload: function () {
        return uploadFiles.get;
    },
    salvarArquivos: function (selecaoId) {
        const files = dragDrop.obterUpload();
        const total = files.length;

        if (total === 0) {
            return;
        }

        const compararTotal = total - 1;

        for (let i = 0; i < total; i++) {

            let fileData = new FormData();
            fileData.append('file', files[i]);
            fileData.append('selecaoId', selecaoId);

            fetch("/Formulario/SalvarArquivo", {
                method: "POST",
                body: fileData
            })
                .then(response => response.json())
                .then(data => {
                    if (i === compararTotal) {
                        alert('Arquivos salvos com sucesso!');
                        window.location.href = "/Formulario";
                    }
                })
                .catch(error => console.error("Erro no upload:", error));
        }
    }
};