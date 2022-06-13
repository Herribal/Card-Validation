$(function () {
    var cardTable = $("#cardList");

    cardTable.dataTable({
        lengthMenu: [5, 10, 15, 20],
        pageLenght: 10,
        responsive: {
            details: {
                type: "column",
                target: "td:not(:last-child)"
            }
        },
        order: [2, "desc"],
        autoWidth: true,
        bPaginate: true,
        ajax: {
            url: "/Home/CardData",
            type: "POST",
            data: {

            },
            dataSrc: function (json) {
                cardTable.show();
                return json.Data;
            }
        },
        oLanguage: {
            "sEmptyTable": "No cards available"
        },
        columns: [
            {
                targets: 0,
                data: null,
                sortable: false,
                searchable: false,
                render: function (row, type, val, meta) { return "" },
                sClass: "dt-darker control all"
            },
            {
                name: "CardNumber",
                data: "CardNumber",
                title: "Card Number",
                sortable: true,
                searchable: true,
                sClass: "dt-darker min-table-p"
            },
            {
                name: "CardType",
                data: "CardType",
                title: "Card Type",
                sortable: true,
                searchable: true,
                sClass: "dt-darker min-table-p"
            },
            {
                name: "CardCreateDate",
                data: "CardCreateDate",
                title: "Create Date",
                sortable: true,
                searchable: true,
                sClass: "dt-darker min-table-p"
            }
        ]
    });

    $("#cardList").removeClass("no-footer");
})