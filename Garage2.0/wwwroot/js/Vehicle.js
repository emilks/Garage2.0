$(document).ready(function () {
    function setVehicle(id, label) {
        $("#Vehicle_Id").val(id);
        $("#Vehicle_RegNo").val(label);
    }

    $('#Vehicle_RegNo').autocomplete({
        source: '/vehicles/search',
        minLength: 2,
        focus: function (event, ui) {
            $("#Vehicle_RegNo").val(ui.item.regNo);
            return false;
        },
        success: function (data) {
            response($.map(data.d, function (item) {
                return {
                    label: item.regNo, // Set the display lebel for the searched list of vehicle registration numbers which we're getting from server side coding.
                    value: item.id // Set the raw value of each shown items.
                }
            }));
        },
        select: function (event, ui) {
            setVehicle(ui.item.id, ui.item.regNo);
            return false;
        }
    })
        .autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<div>RegNo:" + item.regNo + " Type:" + item.vehicleTypeCatogeries + " Member:" + item.memberName + "</div>")
                .appendTo(ul);
        };
});