$("#DoctorFees").change(function () {
    var Med = parseInt($("#MedicineFees").val());
    var OC = parseInt($("#OperationCharges").val());
    var LF = parseInt($("#LabFees").val());
    var DF = parseInt($("#DoctorFees").val());


    $("#TotalAmount").val(Med + OC + LF + DF);

});

$("#TotalDays").change(function () {
    var Med = parseInt($("#MedicineFees").val());
    var OC = parseInt($("#OperationCharges").val());
    var LF = parseInt($("#LabFees").val());
    var DF = parseInt($("#DoctorFees").val());
    var RC = parseInt($("#RoomCharges").val());
    var TD = parseInt($("#TotalDays").val());


    $("#TotalAmount").val(Med + OC + LF + DF + RC*TD);

});

$(document).ready(function () {
    $("#AppointmentDate").datepicker({
        dateFormat: "dd-mm-yy",
        minDate: -0,
        maxDate: "+0M +0D"

    });
});
//function(AppointmentDate) {
//    var CurrentDate = Date.now();
//    var AppointmentDate = moment("#AppointmentDate");

//    if (!(AppointmentDate > CurrentDate))
//        alert("Invalid Date");
//    else
//        $("#AppointmentDate").val(AppointmentDate);
//}


