var CustomerIndex = (function () {

    var customerTableDataEndpoint = '/customer/gettabledate';
    var customerDetailsEndpoint = '/customer/details/';

    var customersTable = null;

    function init() {
        selectElements();
        initCustomersTable();
    }

    function selectElements() {
        customersTable = $('#customer-list-table');
    }

    function initCustomersTable() {
        customersTable = customersTable.DataTable({
            columns: [
                {
                    title: 'Name', data: 'name', orderable: true, width: '15%', render: function (data, type, parent, meta) {
                        if (parent['status'] === 'Active') {
                            return '<a href="' + customerDetailsEndpoint + parent['id'] + '">' + data + '</a>';
                        } else {
                            return '<a class="disabled">' + data + '</a>';
                        }
                        
                    }
                },
                {
                    title: 'Sex', data: 'sex', orderable: true, width: '10%'
                },
                {
                    title: 'Telephone', data: 'telephone', orderable: true, width: '10%'
                },
                {
                    title: 'Created ', data: 'created', orderable: true, width: '10%'
                },
                {
                    title: 'Status ', data: 'status', orderable: true, width: '10%'
                },
                {
                    title: 'Options', data: 'status', orderable: false, width: '20%', render: function (data, type, parent, meta) {
                        return formatTableOptions(parent['id'], data);
                    }
                }
            ],
            serverSide: true,
            searching: false,
            processing: true,
            order: [[0, 'asc']],
            pageLength: 25,
            paging: true,
            pagingType: "full_numbers",
            bDestroy: true,
            language: {
                zeroRecords: "No customers to display"
            },
            ajax: {
                url: customerTableDataEndpoint,
                type: 'POST'
            },
            drawCallback: tableOptionsHandlers
        });

        function formatTableOptions(id, status) {
            var oppositeStatusString = '';
            if (status === 'Active') {
                oppositeStatusString = 'Deactivate';
            } else {
                oppositeStatusString = 'Activate';
            }

            var result = '<button type="button" class="btn btn-danger btn-sm custom-btn-margin delete-customer-btn" id="' + id + '">Delete</button>';
            result += '<button type="button" class="btn btn-secondary btn-sm change-customer-status-btn" id="' + id + '">'
                + oppositeStatusString + '</button>';
            return result;
        }
    }

    function tableOptionsHandlers() {
        $('.delete-customer-btn').on('click', removeCustomer);
        $('.change-customer-status-btn').on('click', changeCustomerStatus);
    }

    function removeCustomer(event) {
        var id = event.target.id;
        $.ajax({
            url: '/customer/delete',
            type: 'DELETE',
            data: {
                id: id
            },
            success: function (res) {
                toastr.success(res);
                customersTable.ajax.reload();
            }
        });
    }

    function changeCustomerStatus(event) {
        var id = event.target.id;

        $.ajax({
            url: '/customer/changeStatus',
            type: 'PUT',
            data: {
                id: id
            },
            success: function (res) {
                toastr.success(res);
                customersTable.ajax.reload();
            }
        });
    }

    return {
        init: init
    };
})();