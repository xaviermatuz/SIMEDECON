﻿function AppendRow(row, Id, ID_Atleta, Prueba, Resultado, Fecha_Y_Lugar, Evento) {
    //Bind ID.
    $(".cdeid", row).find("span").html(Id);

    //Bind atleta.
    $(".atletaid", row).find("span").html(ID_Atleta);

    //Bind Prueba.
    $(".prueba", row).find("span").html(Prueba);
    $(".prueba", row).find("input").val(Prueba);

    //Bind Resultado.
    $(".resultado", row).find("span").html(Resultado);
    $(".resultado", row).find("input").val(Resultado);

    //Bind FYL.
    $(".fyl", row).find("span").html(Fecha_Y_Lugar);
    $(".fyl", row).find("input").val(Fecha_Y_Lugar);

    //Bind Evento.
    $(".evento", row).find("span").html(Evento);
    $(".evento", row).find("input").val(Evento);

    row.find(".edit").show();
    row.find(".elimina").show();
    // $("#tblCDE").append(row);
};
//Add event handler.
$("body").on("click", "#btnaddcdf", function () {
    var txtresultado = $("#txtresultado2");
    var txtfyl = $("#txtfyl2");
    var txtevento = $("#txtevento2");
    var txtatleta = $('#atleta').val();
    var f = new Date();
    var fecha = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    $.ajax({
        type: "POST",
        url: "/HistorialMedico/InsertarCDF",
        data: '{ Evento: "' + txtevento.val() + '", FechayLugar: "' + txtfyl.val() + '", Resultado: "' + txtresultado.val() + '", ID_Atleta: "' + txtatleta + '", Fecha_de_Registro: "' + fecha + '", Fecha_de_Actualizacion: "' + fecha + '", Estado: "' + true + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var row = $("#tblCDE tr:last-child");
            if ($("#tblCDE tr:last-child span").eq(0).html() != "&nbsp;") {
                row = row.clone();
            }
            addrow4(r.ID, r.ID_Atleta, r.Resultado, r.FechayLugar, r.Evento);
            // AppendRow(row,r.ID, r.ID_Atleta, r.Prueba, r.Resultado, r.Fecha_Y_Lugar, r.Evento);
            txtresultado.val("");
            txtfyl.val("");
            txtevento.val("");
        }
    });
});




function addrow4(id, idatleta, resultado, fyl, evento) {
    //campo = '<tr><td style="display:none;"> <span> ' + id + '</span> <input type="text" style="display:none;" value="' + id + '" id="idcde"  /></td><td style="display:none;"><span>' + idatleta + '</span></td><td style="text-align:center;"><span>' + prueba + '</span><input type="text" style="display:none;" value="' + prueba + '" /></td><td style="text-align:center;"><span>' + resultado + '</span><input type="text" style="display:none;" value="' + resultado + '"/></td><td style="text-align:center;"><span>' + fyl + '</span><input type="text" style="display:none;" value="' + fyl + '"/></td><td style="text-align:center;"><span>' + evento + '</span><input type="text" style="display:none;" value="' + evento + '" id="idcde"  /></td><td style="text-align:center;"><button class="btn bg-orange btn-circle waves-effect waves-circle waves-float edit" type="button"><i class="fa fa-edit fa-md"></i></button><a class="actualizar" style="display:none">Update</a><a class="cancel" href = "javascript:;" style = "display:none" > Cancel</a ><button class="btn btn-danger btn-circle waves-effect waves-circle waves-float elimina" type="button"><i class="fa fa-trash fa-md"></i></button></td></tr>';
    campo = '<tr><td style="display:none;"> <span> ' + id + '</span> <input type="text" style="display:none;" value="' + id + '" id="idcde"  /></td>' +
        '<td style="display:none;"><span>' + idatleta + '</span></td>' +
        '<td style="text-align:center;"><span>' + evento + '</span><input type="text" style="display:none;" value="' + evento + '" id="idcde"  /></td>' +
        '<td style="text-align:center;"><span>' + resultado + '</span><input type="text" style="display:none;" value="' + resultado + '"/></td>' +
        '<td style="text-align:center;"><span>' + fyl + '</span><input type="text" style="display:none;" value="' + fyl + '"/></td>' +
        '<td style="text-align:center;">' +
        '<button class="btn bg-orange btn-circle waves-effect waves-circle waves-float edit" type="button"><i class="fa fa-edit fa-md"></i></button>' +
        ' <button style="display:none" class="btn bg-green btn-circle waves-effect waves-circle waves-float actualizar" type="button"><i class="fa fa-check fa-sm"></i></button>' +
        '<button style="display:none" class="btn bg-red btn-circle waves-effect waves-circle waves-float cancelar" type="button"><i class="fa fa-times fa-sm"></i></button>' +
        '<button class="btn btn-danger btn-circle waves-effect waves-circle waves-float elimina" type="button"><i class="fa fa-trash fa-md"></i></button></td ></tr > ';
    $("#tblCDF").append(campo);
}

$("body").on("click", "#tblCDF .elimina", function () {
    id = $(this).parents("tr").find("td").eq(0).html();
    cde = $(this).parents("tr").find("input").val();
    var row = $(this).closest("tr");
    var ID = row.find("span").html();


    if (confirm("Desea eliminar la seleccion")) {
        $(this).parents("tr").fadeOut("normal", function () {
            $.ajax({
                type: "POST",
                url: "/HistorialMedico/DeleteCDF",
                data: '{id: ' + ID + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if ($("#tblCDE tr").length > 2) {
                        id.remove();
                    } else {
                        row.find(".Delete").hide();
                        row.find("span").html('&nbsp;');
                    }
                }
            });
        })
    }
});

//funcion editar
$("body").on("click", "#tblCDF .edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".actualizar").show();
    row.find(".cancelar").show();
    row.find(".elimina").hide();
    $(this).hide();
});
//funcion actualizar
$("body").on("click", "#tblCDF .actualizar", function () {
    var row = $(this).closest("tr");
    var f = new Date();
    var fecha = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            span.html(input.val());
            span.show();
            input.hide();
        }
    });
    var ID = row.find("span").html();
    //
    _row = $(this).parents("tr");
    var cols = _row.children("td");
    //

    var cdf = {};
    cdf.ID = ID;
    cdf.ID_Atleta = $(cols[1]).text().trim();
    cdf.Resultado = $(cols[2]).text().trim();
    cdf.FechayLugar = $(cols[3]).text().trim();
    cdf.Evento = $(cols[4]).text().trim();
    cdf.Fecha_de_Actualizacion = fecha;
    row.find(".edit").show();
    row.find(".elimina").show();
    row.find(".cancelar").hide();
    $(this).hide();
    $.ajax({
        type: "POST",
        url: '/HistorialMedico/ActualizarCDF',
        data: '{CDF:' + JSON.stringify(cdf) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.success) {
                alert(response.responseText);
            }
            else {
                alert(response.responseText + "else");
            }

        }//function

    });
});

//evento cancelar
$("body").on("click", "#tblCDF .cancelar", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".edit").show();
    row.find(".elimina").show();
    row.find(".actualizar").hide();
    $(this).hide();
}); 