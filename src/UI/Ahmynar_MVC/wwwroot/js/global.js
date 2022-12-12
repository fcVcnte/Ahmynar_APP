$(document).ready(function () {
    $("#qttRows").text($("tbody").find("tr").length)

    $(".cpf-cnpj").each(function () {
        if ($(this).text().trim().length === 11) {
            $(this).mask('000.000.000-00', { reverse: true });
        }
        else {
            $(this).mask('00.000.000/0000-00', { reverse: true });
        }
    });

    $(".cpf-num").mask('000.000.000-00');
    $(".cnpj-num").mask('00.000.000/0000-00');
    $(".rg-num").mask('00.000.000-0');
    $(".cellphone-num").mask('(00) 00000-0000');    
    $(".phone-num").mask('(00) 0000-0000');
    $(".cep-num").mask('00000-000');
    $(".money-num").mask('000.000,00', { reverse: true });
    $(".budget-num").mask('000000');
    $(".so-num").mask('00000');

    let searchWord = function () {
        let keyword = $("input[name='filter']").val();

        console.log(keyword)

        $(".index-table").unmark({
            done: function () {
                $(".index-table").mark(keyword);
            }
        });
    }
    $("input[name='filter']").on("input", searchWord);
});