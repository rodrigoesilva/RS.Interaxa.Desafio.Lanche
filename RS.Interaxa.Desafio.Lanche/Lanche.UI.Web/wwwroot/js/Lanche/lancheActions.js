document.getElementById("DataCadastro").readOnly = true;
document.getElementById("DataCadastro").style.color = "#c0c0c0";

document.getElementById("Preco").readOnly = true;
document.getElementById("Preco").style.color = "#c0c0c0";

$("#lblPrecoTotal").text(parseFloat($("#Preco").val()).toFixed(2).replace(".", ","));

function AddIngrediente(idIngrediente, nomeIngrediente, precoIngrediente) {

    let qtd = Number($("#ingrQtd_" + idIngrediente).text());

    if (qtd < 10)
        qtd++;
    else
        Swal.fire(
            'Limite de Itens',
            'O maximo é 10 ' + nomeIngrediente + 's',
            'error'
        );
    $("#ingrQtd_" + idIngrediente).text(qtd);

    let valAtual = parseFloat($("#Preco").val());
    var valPreco = parseFloat(precoIngrediente.replace(",", "."));

    var total = roundNumber(valAtual + valPreco, 12);

    $("#lblPrecoTotal").text(total.toFixed(2).replace(".", ","));
    $("#Preco").attr('value', total.toFixed(2));

}

function RemoveIngrediente(idIngrediente, nomeIngrediente, precoIngrediente) {
    let qtd = Number($("#ingrQtd_" + idIngrediente).text());

    if (qtd > 0)
        qtd--;
    else
        Swal.fire(
            'Limite de Itens',
            nomeIngrediente + ' no minimo Zero',
            'error'
        );

    $("#ingrQtd_" + idIngrediente).text(qtd);

    let valAtual = parseFloat($("#Preco").val());
    var valPreco = parseFloat(precoIngrediente.replace(",", "."));

    var total = roundNumber(valAtual - valPreco, 12);

    $("#lblPrecoTotal").text(total.toFixed(2).replace(".", ","));
    $("#Preco").attr('value', total.toFixed(2));
}

function roundNumber(number, decimals) {
    var newnumber = new Number(number).toFixed(parseInt(decimals));
    return parseFloat(newnumber);
}

function validateForm(_form) {

    if (fnIsStringEmpty(_form.Id.value)) {
        Swal.fire(
            'Validação',
            'Id está vazio',
            'error'
        );
        return;
    }
    else if (fnIsStringEmpty(_form.DataCadastro.value)) {
        Swal.fire(
            'Validação',
            'Data de Cadastro está vazio',
            'error'
        );
        return;
    }
    else if (fnIsStringEmpty(_form.Nome.value)) {
        Swal.fire(
            'Validação',
            'Nome está vazio',
            'error'
        );
        return;
    }
    else if (fnIsStringEmpty(_form.Preco.value)) {
        Swal.fire(
            'Validação',
            'Preço está vazio',
            'error'
        );
        return;
    }
    else {

        let ingredientes = [];

        for (var i = 0; i < arrayIdsIngredientes.length; i++) {

            let idIngrediente = arrayIdsIngredientes[i];
            let qtd = Number($("#ingrQtd_" + idIngrediente).text());

            if (qtd > 0) {
                ingredientes.push({ "IdIngrediente": idIngrediente, "NomeIngrediente": "NaoImporta", "QtdIngrediente": qtd });
            }
        }

        if (ingredientes.length == 0) {
            Swal.fire(
                'Validação',
                'O lanche deve ter ao menos um ingrediente',
                'error'
            );
            return;
        }

        var lancheJson = {
            'Id': _form.Id.value,
            'DataCadastro': _form.DataCadastro.value,
            'Nome': _form.Nome.value,
            'Preco': _form.Preco.value,
            'Ingredientes': ingredientes
        };

        var token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            type: 'POST',
            url: '/Lanches/Edit/' + _form.Id.value,
            dataType: 'JSON',
            async: true,
            data: {
                __RequestVerificationToken: token,
                id: _form.Id.value,
                lanche: lancheJson
            },
            success: function (response) {
                console.log(response);
                $("#Preco").val(response.preco);
                //Swal.fire(
                //    'Custo',
                //    'O valor do lanche é R$' + response.preco,
                //    'info'
                //);

                Swal.fire(
                    'Sucesso',
                    'O valor do lanche foi atualizado R$' + response.preco,
                    'success'
                );
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR.responseText.split("'"));
                console.log(errorThrown.message);
                console.log(textStatus);
            }
        });
    }
}

function fnIsStringEmpty(texto) {
    return false;
}