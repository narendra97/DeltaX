function Employee() {
    var that = this;
    that.FirstName = ko.observable("");
    that.LastName = ko.observable("");
    that.Gender = ko.observable("0");
    that.Salary = ko.observable("");
}