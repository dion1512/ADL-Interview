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
        var today = new Date();
        if ([6, 0].includes(day)) {
            e.preventDefault();
            this.value = '';
            alert('You cannot book an engineer callout on a weekend');
        }
        else if (date < today.addDays(2)) {
            e.preventDefault();
            this.value = '';
            alert('You must book at least 2 working days in advance');
        }
        else {
            var dayName = date.toLocaleDateString("en-GB", { weekday: 'long' });
            $.ajax({
                type: "GET",
                url: "/Home/GetSchedule",
                data: "day=" + dayName + "&date=" + date.toISOString()
            }).done(function (data) {
                debugger;
                var timeArray = data.data;
                var bookingArray = data.existingBookings;
                var bookingArray = data.existingBookings;
                var timeArrayLength = timeArray.length;
                var bookingArrayLength = bookingArray.length
                $('#timebox')
                    .append($("<label></label>").prop({
                        for: 'TimeSlot'
                    }).html("Choose a time <span data-bs-toggle=\"tooltip\" data-bs-placement=\"top\" data-bs-custom-class=\"custom-tooltip\" data-bs-title=\"Time slots that are disabled have already been booked\">(Why can't I select my time slot?)</span>"))
                    .append($("<select></select>").prop({
                        id: 'TimeSlot',
                        name: 'TimeSlot',
                        class: 'form-control'
                    })
                    );
                const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
                const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
                if (timeArrayLength > 0) {

                    var slot;

                    for (var i = 0, timelen = timeArrayLength; i < timelen; i++) {
                        var conflict = false;
                        slot = timeArray[i];
                        if (bookingArrayLength > 0) {
                            debugger;
                            for (var b = 0, bookinglen = bookingArrayLength; b < bookinglen; b++) {
                                booking = bookingArray[b];
                                var time = new Date(Date.parse(booking.dateBookedStart)).toLocaleTimeString([], { hour: "2-digit", minute: "2-digit" });
                                if (time == slot.appointmentTimeStart) {
                                    conflict = true;
                                }
                            }
                        }
                        $('#TimeSlot').append($("<option></option>").prop({
                            value: slot.appointmentTimeStart,
                            text: slot.appointmentTimeStart + " - " + slot.appointmentTimeEnd,
                            disabled: conflict
                        }).data("toggle", "tooltip"));
                        delete conflict;
                    }
                }
            });
        }
    });


}
function getDayName(dateStr, locale) {
    var date = new Date(dateStr);
    return date.toLocaleDateString(locale, { weekday: 'long' });
}
Date.prototype.addDays = function (days) {
    this.setDate(this.getDate() + parseInt(days));
    return this;
};