

$(document).ready(function () {

    $('#OS_PaymentGateway_cmdSave').unbind("click");
    $('#OS_PaymentGateway_cmdSave').click(function () {
        $('.processing').show();
        $('.actionbuttonwrapper').hide();
        // lower case cmd must match ajax provider ref.
        nbxget('os_paymentgateway_savesettings', '.OS_PaymentGatewaydata', '.OS_PaymentGatewayreturnmsg');
    });

    $('.selectlang').unbind("click");
    $(".selectlang").click(function () {
        $('.editlanguage').hide();
        $('.actionbuttonwrapper').hide();
        $('.processing').show();
        $("#nextlang").val($(this).attr("editlang"));
        // lower case cmd must match ajax provider ref.
        nbxget('os_paymentgateway_selectlang', '.OS_PaymentGatewaydata', '.OS_PaymentGatewaydata');
    });


    $(document).on("nbxgetcompleted", OS_PaymentGateway_nbxgetCompleted); // assign a completed event for the ajax calls

    // function to do actions after an ajax call has been made.
    function OS_PaymentGateway_nbxgetCompleted(e) {

        $('.processing').hide();
        $('.actionbuttonwrapper').show();
        $('.editlanguage').show();

        if (e.cmd == 'os_paymentgateway_selectlang') {
                        
        }

    };

});

