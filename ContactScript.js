// JavaScript source code

function DisplayHelloWorld(executionContext) {
    var formContext = executionContext.getFormContext();
    var firstName = formContext.getAttribute("firstname").getValue()
    alert("Hello" + firstName)
}
