class Movie {
    private string movieID;
    public string MovieID {
        get { return movieID; }
        set { movieID = value; }
    }

    private string title;
    public string Title {
        get { return title; }
        set { title = value; }
    }

    private string director;
    public string Director {
        get { return director; }
        set { director = value; }
    }

    private int duration; // in minutes
    public int Duration {
        get { return duration; }
        set { duration = value; }
    }

    private int rating;
    public int Rating {
        get { return rating; }
        set { rating = value; }
    }

    public Movie(
        string movieID,
        string title,
        string director,
        int duration,
        int rating
    ) {
        MovieID = movieID;
        Title = title;
        Director = director;
        Duration = duration;
        Rating = rating;
    }
}