(function () {
    app.service("StartStudyService", startStudyService);

    startStudyService.$inject = ["$http"];

    function startStudyService($http) {

        this.startStudyDate = function (model) {
            var url = "/home/addStartStudyDate";
            return $http.post(url, model);
        };

        this.getCurrentDate = function() {
            var url = "/home/getCurrentDate";
            return $http.get(url);
        };

    }
})();