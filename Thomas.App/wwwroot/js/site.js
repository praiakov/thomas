$(document).ready(function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        language: 'pt-BR',
        todayBtn: "linked",
        autoclose: true,
        todayHighlight: true,
        orientation: "bottom auto"
    });
});

$(document).ready(function () {
    $('.form-check-input').bootstrapToggle({
        on: 'Sim',
        off: 'Não'
    });
});
