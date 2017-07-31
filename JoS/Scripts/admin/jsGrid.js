var MyDateField = function (config) {
    jsGrid.Field.call(this, config);
};

MyDateField.prototype = new jsGrid.Field({
    css: "date-field",
    align: "center",

    sorter: function (date1, date2) {
        return new Date(date1) - new Date(date2);
    },

    itemTemplate: function (value) {
        if (value === null) {   
            return "No date";
        }
        var date = parseInt(value.substr(6));
        return new Date(date).toLocaleDateString();
    },

    filterTemplate: function () {
        this._fromPicker = $("<input placeholder='From date'>").datepicker();
        this._toPicker = $("<input placeholder='To date'>").datepicker();
        return $("<div>").append(this._fromPicker).append(this._toPicker);
    },

    filterValue: function () {
        return {
            from: this._fromPicker.datepicker("option", "dateFormat", "mm/dd/yy").val(),
            to: this._toPicker.datepicker().val()
    };
    }
});

jsGrid.fields.date = MyDateField;

$("#jsGrid").jsGrid({
    width: "100%",
    height: "400px",

    paging: true,
    autoload: true,
    pageLoading: true,
    pageSize: 10,
    pageIndex: 1,

    autosearch: true,
    sorting: true,
    filtering: true,

    noDataContent: "No Record Found",


    controller: {
        loadData: function (filter) {
            var d = $.Deferred();
            return $.ajax({
                type: "GET",
                url: "/Admin/GetAllUsers",
                data: filter,
                dataType: "json",
                success: function (response) {
                    d.resolve(response);
                }
            });
        }
    },

    fields: [
        { name: "Id", type: "number", width: 40, title: "ID" },
        { name: "Name", type: "text", width: 100, title: "Name" },
        { name: "LastName", type: "text", width: 100, title: "Last Name" },
        { name: "Age", type: "text", width: 30, title: "Age" },
        { name: "Email", type: "text", width: 200, title: "Email" },
        { name: "RegisteredDate", type: "date", width: 100, title: "Registered Date" },
        { name: "StartStudy.StudyDate", type: "date", width: 100, title: "Start Study Date" },
        { type: "control", deleteButton: false, editButton: false }
    ]
});