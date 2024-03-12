namespace SportRadarLibrary;

internal class Match
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartDateTime =  DateTime.Now;
    public string HomeTeam { get; set; } = "";
    public string AwayTeam { get; set; } = "";
    public int HomeTeamScore { get; set; }
    public int AwayTeamScore { get; set; }
}
