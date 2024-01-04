$("#frmGenerateActivitionCode").submit(function (e) {
    var btnSendSMS = $("#frmGenerateActivitionCode").find("#btnGenerateActivitionCode");
    if (btnSendSMS.prop("disabled")) {
        e.preventDefault();
        return false;
    }
    if ($(this).valid()) {
        btnSendSMS.prop("disabled", true);

        var minute = 2, second = 60;
        btnSendSMS.text((minute < 10 ? "0" + minute : minute) + ":" + (second < 10 ? "0" + (second) : second));
        var myVar = setInterval(myTimer, 1000);

        function myTimer() {
            if (second - 1 == -1) {
                second = 60;
                minute--;
            } else {
                second--;
            }
            if (second <= 0 && minute <= 0) {
                btnSendSMS.prop("disabled", false);
                btnSendSMS.text("ارسال مجدد");
                clearInterval(myVar);
                return;
            }
            btnSendSMS.text((minute < 10 ? "0" + minute : minute) + ":" + (second < 10 ? "0" + second : second));
        }
    }   
});