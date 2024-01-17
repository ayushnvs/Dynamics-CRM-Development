// JavaScript source code

// Prevent Auto-save
formOnSave = function (executionContext) {
    var eventArgs = executionContext.getEventArgs();
    if (eventArgs.getSaveMode() == 70) {
        eventArgs.preventDefault()
    }
}

// Validate Phone US format
function MainPhoneOnChange(executionContext) {
    var formContext = executionContext.getFormContext();
    var phoneNumber = formContext.getAttribute("telephone1").getValue();

    var expression = /((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}/;
    if (!expression.test(phoneNumber)) {
        //alert("Enter phone number in US format e.g. (123) 456-7890 OR 123-456-7890");
        notificationMsg = "Enter phone number in US format e.g. \n(123) 456-7890\n123-456-7890"
        formContext.getControl("telephone1").setNotification(notificationMsg, "telephonemsg")
        //formContext.ui.setFormNotification("INFO message", "INFO", "formnotification1")
    }
    else {
        formContext.getControl("telephone1").clearNotification("telephonemsg")
        //formContext.ui.clearFormNotification("formnotification1")
    }
}
