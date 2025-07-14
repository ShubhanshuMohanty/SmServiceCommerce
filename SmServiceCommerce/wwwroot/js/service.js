
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/service/getall' },
        "columns": [
            { data: 'id', "width": "25%" },
            { data: 'serviceName', "width": "25%" },
            {
                data: 'id',
                render: function (data, type, row) {
                    return `<div class="text-center">
                                <a href="/admin/service/upsert?id=${data}" class='btn btn-primary mx-2' style='cursor:pointer; width:100px;'>
                                    <i class="fas fa-edit"></i> Edit
                                </a>
                                <a onClick=Delete('/admin/service/delete/${data}') class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class="fas fa-trash-alt"></i> Delete
                                </a>
                            </div>`;
                },
                "width": "50%"
            },
        ]
    });
}
