// JavaScript source code
function AccountLoad(executionContext) {


    var formContext = executionContext.getFormContext();
    formContext.ui.setFormNotification("Create proper form", "INFO", "clearaccountnotif");
    //alert("hello you are loading account form");
    formContext.getControl("telephone1").setDisabled(true);
    formContext.getControl("fax").setVisible(false);
}
function AccountSave() {
    alert("you are saving account");
}
function Accountnamechange(executionContext) {
    var formContext = executionContext.getFormContext();
    //getting value
    var accountName = formContext.getAttribute("name").getValue();
    alert("name changed");
    //if
    formContext.getAttribute("telephone1").setValue("12345677");
}
function ValidatePhoneNumber(executionContext) {
    var formContext = executionContext.getFormContext();
    var phone = formContext.getAttribute("telephone1").getValue();


    if (/^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$/.test(phone)) {
        //alert("Enter proper phone number");
        formContext.getControl("telephone1").setNotification("Enter proper phone number", "clearnotif")

    }
    else {
        formContext.getControl("telephone1").clearNotification("clearnotif");

    }
}
function DescriptiontoUpperCase(executionContext) {
    var formContext = executionContext.getFormContext();
    var desc = formContext.getAttribute("description").getValue();
    formContext.getAttribute("description").setValue(desc.toUpperCase());
}
