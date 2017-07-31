app.controller("StartStudyCtrl", function (StartStudyService) {

    //vm - viewModel
    var vm = this;

    vm.isOpen = false;

    vm.today = new Date();

    vm.startStudy = {
        studyDate: null
    };

    vm.initializationStudyDate = function() {
        StartStudyService.getCurrentDate().then(function(data) {
            vm.startStudy.studyDate = new Date(data.data);
        });
    };

    vm.initializationStudyDate();

    vm.addDate = function(dateStudy) {
        StartStudyService.startStudyDate(dateStudy)
            .then(function(greeting) {
                toastr.success("Success!");
            }).catch(function(error) {
                toastr.error("Please try again letter!", "Something went wrong!");
            });
    };
});