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

    $(".cellphone-num").each(function () {
        $(this).mask('(00) 00000-0000', { reverse: true });
    });

    $(".cep-num").each(function () {
        $(this).mask('00000-000', { reverse: true });
    });

    //    let keyword = $("input[name='filter']").val();

    //    console.log(keyword)

    //    $(".index-table").unmark({
    //        done: function () {
    //            $(".index-table").mark(keyword);
    //        }
    //    });

    //    $("input[name='filter']").on("input", mark);
    //}
});