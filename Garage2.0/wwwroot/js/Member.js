$(document).ready(function () {
    function setMember(id, label) {
        $("#Member_Id").val(id);
        $("#Member_Name").val(label);
    }

    $('#Member_Name').autocomplete({
        source: '/members/search',
        minLength: 2,
        focus: function (event, ui) {
            $("#Member_Name").val(ui.item.name);
            return false;
        },
        success: function (data) {
            response($.map(data.d, function (item) {
                return {
                    label: item.name, // Set the display lebel for the searched list of member names which we're getting from server side coding.
                    value: item.id // Set the raw value of each shown items.
                }
            }));
        },
        select: function (event, ui) {
            setMember(ui.item.id, ui.item.name);
            return false;
        }
    })
        .autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<div>Name:" + item.name + " PrN:" + item.personNr + "</div>")
                .appendTo(ul);
        };
});