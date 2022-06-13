var cardLabel = $("#cardLabel");
var cardTypeCode = $("#cardTypeCode");

const cardCode = {
    "Visa": "VI",
    "MasterCard": "MC",
    "Amex": "AE",
    "Discover": "DC",
    "Other": "OT",
}

$(function () {
    cardLabel.hide();
});

$("#cardNumberId").on('change keydown paste input', function () {
    var input = $("#cardNumberId").val();

    GetCardType(input);
});

function GetCardType(number) {
    // visa
    var re = new RegExp("^4");
    if (number.match(re) !== null) {
        cardTypeCode.val("VI");
        cardLabel.html("Visa");
        cardLabel.show();
        return;
    }        

    // Mastercard 
    re = new RegExp("^5[1-5][0-9]{2}");
    if (number.match(re) !== null) {
        cardTypeCode.val("MC");
        cardLabel.html("Mastercard");
        cardLabel.show();
        return;
    }        

    // AMEX
    re = new RegExp("^3[47]");
    if (number.match(re) !== null) {
        cardTypeCode.val("AE");
        cardLabel.html("AMEX");
        cardLabel.show();
        return;
    }        

    // Discover
    re = new RegExp("^(6011|622(12[6-9]|1[3-9][0-9]|[2-8][0-9]{2}|9[0-1][0-9]|92[0-5]|64[4-9])|65)");
    if (number.match(re) !== null) {
        cardTypeCode.val("DC");
        cardLabel.html("Discover");
        cardLabel.show();
        return;
    }        

    // Visa Electron
    re = new RegExp("^(4026|417500|4508|4844|491(3|7))");
    if (number.match(re) !== null) {
        cardTypeCode.val("VI");
        cardLabel.html("Visa Electron");
        cardLabel.show();
        return;
    }

    cardTypeCode.val("OT");
    cardLabel.html("");
    cardLabel.hide();
    return;
}