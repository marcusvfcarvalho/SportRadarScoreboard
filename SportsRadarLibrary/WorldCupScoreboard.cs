namespace SportRadarLibrary;

public class WorldCupScoreboard
{
    readonly List<Match> _matches = [];

    /// <summary>
    /// Adds a new Match to the scoreboard, with start date and time as now.
    /// </summary>
    /// <param name="homeTeam">Name of the Home Teeam</param>
    /// <param name="awayTeam">Name of the Away Teeam</param>
    /// <param name="homeScore">Score of the Home Team</param>
    /// <param name="awayScore">Score of the Away Team</param>
    /// <returns>The reference to the created Match.</returns>
    public MatchReference StartMatch(string homeTeam, string awayTeam, int homeScore = 0, int awayScore = 0)
    {
        if (_matches.Any(x=>x.AwayTeam == awayTeam && x.HomeTeam==homeTeam))
        {
            throw new Exception("Match already added");
        }

        var match = new Match()
        {
            HomeTeam = homeTeam,
            AwayTeam = awayTeam,
            HomeTeamScore = homeScore,
            AwayTeamScore = awayScore,
            StartDateTime = DateTime.Now,
        };

        _matches.Add(match);

        return CreateReference(match);
    }

    /// <summary>
    /// Updates the score of an ongoing match
    /// </summary>
    /// <param name="matchId">Match Id</param>
    /// <param name="homeScore">The Score of the Home Team</param>
    /// <param name="awayScore">The Score of the Away Team</param>
    /// <returns>The reference to the match updated</returns>
    /// <exception cref="Exception">When the Match is not found</exception>
    public MatchReference UpdateScore(Guid matchId, int homeScore, int awayScore)
    {
        var match = _matches.Find(x=> x.Id == matchId);
        if (match != null)
        {
            match.HomeTeamScore = homeScore;
            match.AwayTeamScore = awayScore;
            return CreateReference(match);
        }
        else
        {
            throw new Exception("Match does not exist");
        }
    }

    /// <summary>
    /// Finish a match and removes it from scoreboard
    /// </summary>
    /// <param name="matchId">Id of the match</param>
    public void FinishMatch(Guid matchId)
    {
        var match = _matches.Find(x=> x.Id == matchId); 
        if (match != null)
        {
            _matches.Remove(match);
        }
    }

    /// <summary>
    /// List all ongoing matches orderd by highest score and time of start
    /// </summary>
    /// <returns>Ordered list</returns>
    public List<MatchReference> ListMatches() => _matches.OrderByDescending(x => x.HomeTeamScore + x.AwayTeamScore)
        .ThenByDescending(x => x.StartDateTime)
        .Select(x=> CreateReference(x))
        .ToList();

    private static MatchReference CreateReference(Match match)
    {
        return new MatchReference(match.Id, match.HomeTeam, match.AwayTeam, match.HomeTeamScore, match.AwayTeamScore);
    }
}
