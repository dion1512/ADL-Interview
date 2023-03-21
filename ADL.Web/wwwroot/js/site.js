// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    handleDatePicker();
    
});
function handleDatePicker() {
    // Block weekends
    $("#DateBooked").on('input', function (e) {
        var date = new Date(this.value);
        var day = date.getUTCDay();
        if ([6, 0].includes(day)) {
            e.preventDefault();
            this.value = '';
            alert('Weekends not allowed');
        }
        var dayName = date.toLocaleDateString("en-GB", { weekday: 'long' });
        $.ajax({
            type: "GET",
            url: "/Home/GetSchedule",
            data: "day=" + dayName
        }).done(function (data) {
            debugger;
            var timeArray = data.data;
            var arrayLength = timeArray.length;
            $('#timebox')
                .append(
                    $(document.createElement('label')).prop({
                        for: 'TimeSlot'
                    }).html('Choose a time')
                )
                .append(
                    $(document.createElement('select')).prop({
                        id: 'TimeSlot',
                        name: 'TimeSlot',
                        class: 'form-control'
                    })
                )
            if (arrayLength > 0) { 
                var slot;
                for (var i = 0, len = arrayLength; i < len; i++) {
                    slot = timeArray[i];
                    $('#TimeSlot').append($(document.createElement('option')).prop({
                        value: slot.appointmentTimeStart,
                        text: slot.appointmentTimeStart + " - " + slot.appointmentTimeEnd
                    }))
                }
            }
        });
    });


}
function getDayName(dateStr, locale) {
    var date = new Date(dateStr);
    return date.toLocaleDateString(locale, { weekday: 'long' });
}