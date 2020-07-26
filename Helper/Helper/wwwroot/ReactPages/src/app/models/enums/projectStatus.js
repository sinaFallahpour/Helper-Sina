export var ProjectStatus;
(function (ProjectStatus) {
    //انجام شده
    ProjectStatus[ProjectStatus["Done"] = 0] = "Done";
    //درحال انجام
    ProjectStatus[ProjectStatus["inProgress"] = 1] = "inProgress";
    //باید انجام شود
    ProjectStatus[ProjectStatus["Todo"] = 2] = "Todo";
})(ProjectStatus || (ProjectStatus = {}));
//# sourceMappingURL=projectStatus.js.map