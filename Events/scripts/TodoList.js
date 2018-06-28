$(function () {
    $("#grid").jqGrid({
        url: "/EventsData/EData/GetTodoLists",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['EventDataid', 'Name', 'Address', 'District', 'City', 'Eid'],
        colModel: [
            { key: true, hidden: true, name: 'EventDataid', index: 'EventDataid', editable: true },
            { key: false, name: 'Name', index: 'Name', editable: true },
            { key: false, name: 'Address', index: 'Address', editable: true },
            { key: false, name: 'District', index: 'District', editable: true },
            { key: false, name: 'City', index: 'City', editable: true },
        { key: true, hidden: true, name: 'Eid', index: 'Eid', editable: true },],
        pager: jQuery('#pager'),
        rowNum: 10,
        rowList: [10, 20, 30, 40],
        height: '100%',
        viewrecords: true,
        caption: 'Todo List',
        emptyrecords: 'No records to display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            EventDataid: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#pager', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            // edit options
            zIndex: 100,
            url: '/EventsData/EData/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            // add options
            zIndex: 100,
            url: "/EventsData/EData/Create",            
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            // delete options
            zIndex: 100,
            url: "/EventsData/EData/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete this task?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        }

        );
});

