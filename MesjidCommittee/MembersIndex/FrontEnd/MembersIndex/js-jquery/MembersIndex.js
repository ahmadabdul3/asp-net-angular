$(document).ready(function () {
   /* $('.slim-scroll').slimScroll({
        height: '450px'
    });*/
    $('.slim-scroll').slimScroll({
        height: '450px'
    });

    $(document).on('click', '.modal-closer', function () {
        hideModals();
    });
    $('#add-member-button').on('click', function () {
        showModalBg();
    });
    //$('body').on('click', '.edit-closer', function () {
    //    $('#right-edit-panel').animate({ width: 0 }, 400);
    //    adata-ngular.element($('#adata-ngular-controller')).scope().clearPersonData();
    //    $('.table-row-inner-box').removeClass('selected-row');
    //});
    $('body').on('click', '.table-row-inner-box', function () {
        $('.table-row-inner-box').removeClass('selected-row');
        $(this).addClass('selected-row');
    });
});
function showModalBg() {
    $('.modal-bg').fadeIn(300);
}

function showAddModal() {
    $('.add-member-modal').fadeIn(300);
}
function showEditModal() {
    $('#edit-member-modal').fadeIn(300);
}
function hideModals() {
    $('.modal-bg').fadeOut(300);
    $('.add-member-modal').fadeOut(300);
    $('#edit-member-modal').fadeOut(300);
}
function showError(message) {
    $('#error-modal-message').text(message);
    $('#error-modal').fadeIn(300).delay(4000).fadeOut(500);
}