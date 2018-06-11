function MovieListVM() {
    var that = this;
    //that.Employee = new Employee();
    //that.reset = function () {
    //    that.Employee.FirstName("");
    //    that.Employee.LastName("");
    //    that.Employee.Salary("");
    //};
    that.getMovieList = function () {
        $.ajax({
            url: 'http://localhost:8000/producers/getAllMovies/movies',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var message = data.Message;
                var movies = data.movies;
				var movieTable = $('#movieTable').dynatable({
                dataset: {
                    records: movies
                },
                features: {
                    paginate: true,
                    sort: false,
                    pushState: false,
                    search: false,
                    recordCount: false,
                    perPageSelect: false
                }
            }).data('dynatable');
            }
        });
    };
};