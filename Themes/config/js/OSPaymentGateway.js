

$(document).ready(function () {

    $('#OSPaymentGateway_cmdSave').unbind("click");
    $('#OSPaymentGateway_cmdSave').click(function () {
        $('.processing').show();
        $('.actionbuttonwrapper').hide();
        // lower case cmd must match ajax provider ref.
        nbxget('ospaymentgateway_savesettings', '.OSPaymentGatewaydata', '.OSPaymentGatewayreturnmsg');
    });

    $('.selectlang').unbind("click");
    $(".selectlang").click(function () {
        $('.editlanguage').hide();
        $('.actionbuttonwrapper').hide();
        $('.processing').show();
        $("#nextlang").val($(this).attr("editlang"));
        // lower case cmd must match ajax provider ref.
        nbxget('ospaymentgateway_selectlang', '.OSPaymentGatewaydata', '.OSPaymentGatewaydata');
    });


    $(document).on("nbxgetcompleted", OSPaymentGateway_nbxgetCompleted); // assign a completed event for the ajax calls

    // function to do actions after an ajax call has been made.
    function OSPaymentGateway_nbxgetCompleted(e) {

        $('.processing').hide();
        $('.actionbuttonwrapper').show();
        $('.editlanguage').show();

        if (e.cmd == 'ospaymentgateway_selectlang') {
                        
        }

    };

});

