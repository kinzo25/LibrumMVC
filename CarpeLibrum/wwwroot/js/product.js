$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall'},
        "columns": [
            { data: 'name', "width":"15%" },
            { data: 'position', "width": "15%" },
            { data: 'salary', "width": "15%" },
            { data: 'department', "width": "15%" },
            { data: 'gory.name', "width": "15%" }
        ]
    });
}
