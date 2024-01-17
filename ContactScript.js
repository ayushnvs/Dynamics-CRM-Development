// JavaScript source code

function FormOnLoad(executionContext) {
    var formContext = executionContext.getFormContext();
    var formType = formContext.ui.getFormType();
    if (formType == 2) {
        var lookupArray = formContext.getAttribute("parentcustomerid").getValue()

        if (lookupArray[0] != null) {
            var guidOfAccount = lookupArray[0].id
            var nameOfAccount = lookupArray[0].name
            var entityType = lookupArray[0].entityType

            formContext.ui.setFormNotification("Guid of Account is " + guidOfAccount, "INFO", "1")
            formContext.ui.setFormNotification("Name of Account is " + nameOfAccount, "INFO", "2")
            formContext.ui.setFormNotification("Entity Type is " + entityType, "INFO", "3")
        }
    }
   
}
