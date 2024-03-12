namespace SportRadarLibrary;

public record MatchReference(Guid Id, string HomeTeam, string AwayTeam, int HomeTeamScore, int AwayTeamScore)
{
}
