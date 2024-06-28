

$(document).ready(function () {
    // Initialize DataTables
    $("#example1").DataTable({
        "responsive": true,
        "lengthChange": false,
        "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');

    $('#example2').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true
    });

    $('#contactForm').on('submit', function (event) {
        event.preventDefault(); // Prevent default form submission

        // Serialize form data
        var formData = $(this).serialize();

        // Send form data using AJAX
        $.ajax({
            type: 'POST',
            url: '/Website/Contact', // Adjust this URL based on your routing
            data: formData,
            success: function (response) {
                if (response.success) {
                    Swal.fire({
                        title: "Action Successful!",
                        text: "Message has been sent!",
                        icon: "success",
                        confirmButtonText: "OK"
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.reload();
                        }
                    });
                } else {
                    Swal.fire({
                        title: "Error!",
                        text: "There was an error sending your message.",
                        icon: "error",
                        confirmButtonText: "OK"
                    });
                }
            },
            error: function () {
                Swal.fire({
                    title: "Error!",
                    text: "There was an error sending your message.",
                    icon: "error",
                    confirmButtonText: "OK"
                });
            }
        });
    });

});



/* 
$('#btndelete').on('click', function (event) {
    Swal.fire({
        title: "Action Succesfull!",
        text: "Shippment Details has been created!",
        icon: "success",
        confirmButtonText: "OK",
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.reload();
        }
    });
});
*/

// ------------- ALL WORK FOR CREATE ------------- //

// ----- VALIDATION WORK ON ONE FEILD NAME ----- //
/*
function validatecontrols() {
    var isEmpty = false;
    var address = $('#txtshippingaddress').val();
    var method = $('#selectshippingmethod').val();
    var tracking = $('#txttrackingnumber').val();
    var datetime = $('#dateandtime').val();
    if (!address || !method || !tracking || !datetime) {
        isEmpty = true;
        $('#errormsg').text('This is a required field!');
        if (!address) $('#txtshippingaddress').addClass('border-danger');
        if (!method) $('#selectshippingmethod').addClass('border-danger');
        if (!tracking) $('#txttrackingnumber').addClass('border-danger');
        if (!datetime) $('#dateandtime').addClass('border-danger');
    } else {
        $('#errormsg').empty();
        $('#txtshippingaddress').removeClass('border-danger');
        $('#selectshippingmethod').removeClass('border-danger');
        $('#txttrackingnumber').removeClass('border-danger');
        $('#dateandtime').removeClass('border-danger');
    }

    return !isEmpty;
}

$(document).ready(function () {
    $('#btnsubmit').on('click', function (event) {
        if (!validateControls()) {
            event.preventDefault();
            return;
        }
        Swal.fire({
            title: "Action Succesfull!",
            text: "Shippment Details has been created!",
            icon: "success",
            confirmButtonText: "OK",
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.reload();
            }
        });
    });
});
*/

// ----- REMOVE VALIDATION WORK ON ONE FEILD NAME ----- //

/*
$('#txtshippingaddress').on('change', function () {
    var address = $('#txtshippingaddress').val();
    
    if (!address) {
        $('#errormsg').text(`This is a required field!`);
        $('#txtshippingaddress').addClass('border-danger');
    }
    else {
        $('#errormsg').empty();
        $('#txtshippingaddress').removeClass('border-danger');
    }
});
$('#txtshippingaddress').on('change', function () {
    var method = $('#selectshippingmethod').val();
    
    if (!method) {
        $('#errormsg').text(`This is a required field!`);
        $('#selectshippingmethod').addClass('border-danger');
    }
    else {
        $('#errormsg').empty();
        $('#selectshippingmethod').removeClass('border-danger');
    }
});
$('#txtshippingaddress').on('change', function () {
    var tracking = $('#txttrackingnumber').val();
    
    if (!tracking) {
        $('#errormsg').text(`This is a required field!`);
        $('#txttrackingnumber').addClass('border-danger');
    }
    else {
        $('#errormsg').empty();
        $('#txttrackingnumber').removeClass('border-danger');
    }
});
$('#txtshippingaddress').on('change', function () {
    var datetime = $('#dateandtime').val();
    
    if (!datetime) {
        $('#errormsg').text(`This is a required field!`);
        $('#dateandtime').addClass('border-danger');
    }
    else {
        $('#errormsg').empty();
        $('#dateandtime').removeClass('border-danger');
    }
});

*/
