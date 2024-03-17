$(document).ready(function () {
    document.title = 'Qmq - Monitor';

    $(".data").mask('99/99/9999 99:99:99');
    GetQmqInHeaderMessageType();
    GetQmqOutHeaderMessageType();

    $("#btnSearchMessageIn").click(function () {        
        var MessageTypeQmqInHeader = $("#MessageTypeQmqInHeader").val();
        var dtIni = $("#dtIni").val();
        var dtFin = $("#dtFin").val();

        GetDataQmqInHeaderByMessageTypeAndPeriod(MessageTypeQmqInHeader,dtIni,dtFin);
    });

    $("#btnSearchMessageOut").click(function () {
        var MessageTypeQmqOutHeader = $("#MessageOutType").val();
        var dtIniOut = $("#dtIniOut").val();
        var dtFinOut = $("#dtFinOut").val();

        GetDataQmqOutHeaderByMessageTypeAndPeriod(MessageTypeQmqOutHeader, dtIniOut, dtFinOut);
    });

    $("#btnCleanMessageIn").click(function () {
        $("#MessageTypeQmqInHeader").val("");
        $("#dtIni").val("");
        $("#dtFin").val("");
        destroyDataTable("tbMessageInBody");
        $("#tbMessageInBody").html("");        
    });

    $("#btnCleanMessageOut").click(function () {        
        $("#MessageOutType").val("");
        $("#dtIniOut").val("");
        $("#dtFinOut").val("");
        destroyDataTable("tbMessageOutBody");
        $("#tbMessageOutBody").html("");
    });

    $("#closeModal").click(function () {
        $("#MessageIdModal").html("");        
    });

    $(".updatePage").click(function () {
        var url = $("#Index").val();
        window.location.href = url;
    });
});

function GetDataQmqInHeaderByMessageTypeAndPeriod(MessageType, dtIni, dtFin)
{
    
    var url = $("#GetDataQmqInHeaderByMessageType").val();
    var data = "MessageType=" + MessageType + "&dtIni=" + dtIni + "&dtFin=" + dtFin;
    $.ajax({
        type: 'GET',
        dataType: 'html',
        url: url,
        data: data,
        success: function (response) {
            $("#tbMessageInBody").html(response);
            createDataTable("tbMessageInBody");
        },

    }).done(function (response) {

    }).fail(function (jqXHR, textStatus) {
        console.log("Request failed: " + textStatus);
        //$("#modal-loading").modal('hide');
        console.log("Ocorreu um erro!");
    }).always(function () {
        //$("#modal-loading").modal('hide');
    });
}

function GetDataQmqOutHeaderByMessageTypeAndPeriod(MessageType, dtIni, dtFin)
{
    var url = $("#GetDataQmqOutHeaderByMessageType").val();
    var data = "MessageType=" + MessageType +"&dtIni="+dtIni+"&dtFin="+dtFin;
    $.ajax({
        type: 'GET',
        dataType: 'html',
        url: url,
        data: data,
        success: function (response) {
            $("#tbMessageOutBody").html(response);
            createDataTable("tbMessageOutBody");
        },

    }).done(function (response) {

    }).fail(function (jqXHR, textStatus) {
        console.log("Request failed: " + textStatus);
        //$("#modal-loading").modal('hide');
        console.log("Ocorreu um erro!");
    }).always(function () {
        //$("#modal-loading").modal('hide');
    });

}

function GetQmqInHeaderMessageType()
{
    var url = $("#GetQmqInHeaderMessageType").val();
    var data = $("#MessageTypeQmqInHeader").val();
    $.ajax({
        type: 'GET',
        dataType: 'html',
        url: url,
        data: data,
        success: function (response) {            
            $("#MessageTypeQmqInHeader").html(response);            
        },

    }).done(function (response) {

    }).fail(function (jqXHR, textStatus) {
        console.log("Request failed: " + textStatus);
        //$("#modal-loading").modal('hide');
        console.log("Ocorreu um erro!");
    }).always(function () {
        //$("#modal-loading").modal('hide');
    });
}

function GetQmqOutHeaderMessageType()
{
    var url = $("#GetQmqOutHeaderMessageType").val();
    var data = null;
    $.ajax({
        type: 'GET',
        dataType: 'html',
        url: url,
        data: data,
        success: function (response) {        
            $("#MessageOutType").html(response);
        },

    }).done(function (response) {

    }).fail(function (jqXHR, textStatus) {
        console.log("Request failed: " + textStatus);
        //$("#modal-loading").modal('hide');
        console.log("Ocorreu um erro!");
    }).always(function () {
        //$("#modal-loading").modal('hide');
    });
}

function GetMessageInBodyByMessageId(MessageId)
{
    var url = $("#GetMessageInBodyByMessageId").val();
    var data = "MessageId="+MessageId;
    $.ajax({
        type: 'GET',
        dataType: 'html',
        url: url,
        data: data,
        success: function (response) {
            $("#tbMessageBodyModal").html(response);            
            $("#modalMessageBody").modal();
            $("#MessageIdModal").html(MessageId);
            createDataTable("tbMessageBodyModal");
        },

    }).done(function (response) {

    }).fail(function (jqXHR, textStatus) {
        console.log("Request failed: " + textStatus);
        //$("#modal-loading").modal('hide');
        console.log("Ocorreu um erro!");
    }).always(function () {
        //$("#modal-loading").modal('hide');
    });
}

function GetMessageOutBodyByMessageId(MessageId) {
    var url = $("#GetMessageOutBodyByMessageId").val();
    var data = "MessageId=" + MessageId;
    $.ajax({
        type: 'GET',
        dataType: 'html',
        url: url,
        data: data,
        success: function (response) {
            $("#tbMessageBodyModal").html(response);
            createDataTable("tbMessageBodyModal");
            $("#MessageIdModal").html(MessageId);
            $("#modalMessageBody").modal();
        },

    }).done(function (response) {

    }).fail(function (jqXHR, textStatus) {
        console.log("Request failed: " + textStatus);
        //$("#modal-loading").modal('hide');
        console.log("Ocorreu um erro!");
    }).always(function () {
        //$("#modal-loading").modal('hide');
    });
}


function createDataTable(tableName, paging = true, ordering = false) {

   var datatable = $("#" + tableName).DataTable({

        buttons: [            
            { extend: 'copy', text: '<i class="fa fa-copy"></i>Copiar' },
            { extend: 'excel', text: '<i class="fa fa-file-excel"></i>Excel' },
            { extend: 'csv', text: '<i class="fa fa-list"></i>CSV' },
            { extend: 'colvis', text: 'Colunas' },



       ],
       "language": {
           "emptyTable": "Nenhum registro encontrado",
           "info": "Mostrando de _START_ at&eacute; _END_ de _TOTAL_ registros",
           "infoEmpty": "Mostrando 0 at&eacute; 0 de 0 registros",
           "infoFiltered": "(Filtrados de _MAX_ registros)",
           "infoThousands": ".",
           "loadingRecords": '<i class="fa fa-spinner fa-spin fa-1x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Carregando</span> ',
           "processing": '<i class="fa fa-spinner fa-spin fa-1x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Processando</span> ',
           "sLengthMenu": "Mostrar _MENU_ registros",
           "zeroRecords": "Nenhum registro encontrado",
           "search": "Pesquisar",
           "paginate": {
               "next": "<i class='fa fa-caret-right'></i>",
               "previous": "<i class='fa fa-caret-left'></i>",
               "first": "Primeiro",
               "last": "Último"
           },
           "select": {
               "rows": {
                   "_": "Selecionado %d linhas",
                   "1": "Selecionado 1 linha"
               },
               "cells": {
                   "1": "1 célula selecionada",
                   "_": "%d células selecionadas"
               },
               "columns": {
                   "1": "1 coluna selecionada",
                   "_": "%d colunas selecionadas"
               }
           },
           "searchPanes": {
               "clearMessage": "Limpar Tudo",
               "collapse": {
                   "0": "Pain&eacute;is de Pesquisa",
                   "_": "Pain&eacute;is de Pesquisa (%d)"
               },
               "count": "{total}",
               "countFiltered": "{shown} ({total})",
               "emptyPanes": "Nenhum Painel de Pesquisa",
               "loadMessage": "Carregando Pain&eacute;is de Pesquisa...",
               "title": "Filtros Ativos",
               "showMessage": "Mostrar todos",
               "collapseMessage": "Fechar todos"
           }

       },

        "responsive": true, "lengthChange": false, "autoWidth": true,
        "paging": true,
        "lengthChange": false,
        "searching": true,
        "ordering": false,
        "info": true,
        "autoWidth": true,
        "responsive": true,
        "bDestroy": true,

    }).buttons().container().appendTo('#' + tableName + '_wrapper .col-md-6:eq(0)');


    $('#' + tableName+ ' tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            datatable.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

}

function destroyDataTable(tableName) {
    $('#' + tableName).DataTable().destroy();
}
