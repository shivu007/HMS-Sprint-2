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

