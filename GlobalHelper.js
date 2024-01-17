// JavaScript source code

var Helper = window.Helper || {};

(function () {
    this.disableAutoSave = function (executionContext) {
        console.log("Disabling Auto Save...")
        var eventArgs = executionContext.getEventArgs();
        if (eventArgs.getSaveMode() == 70) {
            eventArgs.preventDefault()
        }
    }
}).call(Helper)