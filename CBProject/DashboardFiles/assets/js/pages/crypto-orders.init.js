try {
    $(".select2-search-disable").select2({ minimumResultsForSearch: 1 / 0 }), $(document).ready(function () { $(".datatable").DataTable(), $(".dataTables_length select").addClass("form-select form-select-sm") });
} catch (error) {
    console.log(`Error: ${error}`);
}