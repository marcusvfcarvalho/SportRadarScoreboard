using NUnit.Framework;
using SportRadarLibrary;
using System;

namespace SportsRadar.Test.StepDefinitions
{
    [Binding]
    public class WorldCupLiveScoreStepDefinitions
    {
        WorldCupScoreboard? _scoreboard;
        List<MatchReference>? _matchList;
        MatchReference? _currentMatch;
        Exception? _error;

        [Given(@"I created a Scoreboard")]
        public void GivenICreatedAScoreboard()
        {
            _scoreboard = new WorldCupScoreboard();
        }


        [When(@"I list ongoing matches")]
        public void WhenIListOngoingMatches()
        {
            _matchList = _scoreboard?.ListMatches();
        }

        [Then(@"I get an empty score")]
        public void ThenIGetAnEmptyScore()
        {
            Assert.AreEqual(0, _matchList?.Count);
        }

        [When(@"I add a match between home team ""([^""]*)"" and away team ""([^""]*)""")]
        public void WhenIAddAMatchBetweenHomeTeamAndAwayTeam(string homeTeam, string awayTeam)
        {
            try
            {
                _currentMatch = _scoreboard?.StartMatch(homeTeam, awayTeam);
            } catch (Exception ex)
            {
                _error = ex;
            }
        }

        [When(@"When I list the scoreboard")]
        public void WhenWhenIListTheScoreboard()
        {
            _matchList = _scoreboard?.ListMatches();
        }

        [Then(@"I get the correct list")]
        public void ThenIGetTheCorrectScore()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, _matchList.Count());
                Assert.AreEqual("Country 1", _matchList.First().HomeTeam);
                Assert.AreEqual("Country 2", _matchList.First().AwayTeam);

            });

        }

        [Given(@"I have the following match on the scoreboard:")]
        public void GivenIHaveTheFollowingMatchOnTheScoreboard(Table table)
        {
            foreach (var row in table.Rows)
            {
                _currentMatch = _scoreboard!.StartMatch(row[0], row[1], Convert.ToInt32(row[2]), Convert.ToInt32(row[3]));
                Thread.Sleep(100);
            }

        }

        [When(@"I update the score to Home (.*) and Away (.*)")]
        public void WhenIUpdateTheScoreToHomeAndAway(int homeScore, int awayScore)
        {
           _scoreboard!.UpdateScore(_currentMatch!.Id, homeScore, awayScore);   
        }

        [Then(@"I get the following score")]
        public void ThenIGetTheFollowingScore(Table table)
        {
            var listMatches = _scoreboard!.ListMatches();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, listMatches!.Count());
                Assert.AreEqual(1, listMatches!.First().HomeTeamScore);
                Assert.AreEqual(0, listMatches!.First().AwayTeamScore);

            });

        }

        [When(@"I finish the match")]
        public void WhenIFinishTheMatch()
        {
            _scoreboard!.FinishMatch(_currentMatch!.Id);
        }

        [Then(@"I get an empty scoreboard")]
        public void ThenIGetAnEmptyScoreboard()
        {
           Assert.AreEqual(0, _scoreboard!.ListMatches().Count());   
        }

        [When(@"I list the ongoing maches I get the following list:")]
        public void WhenIListTheOngoingMachesIGetTheFollowingList(Table expectedTable)
        {
            Table scoreboardTable = new("Home Team","Away Team","Home Team Score","Away Team Score");
            var orderedMatches = _scoreboard!.ListMatches();


            foreach (var match in orderedMatches) {
                scoreboardTable.AddRow(match.HomeTeam, match.AwayTeam, match.HomeTeamScore.ToString(), match.AwayTeamScore.ToString());
            }

            Assert.AreEqual(expectedTable.RowCount, scoreboardTable.RowCount, "Row count does not match");

            for (int i = 0; i < expectedTable.RowCount; i++)
            {
                CollectionAssert.AreEqual(expectedTable.Rows[i].Values, scoreboardTable.Rows[i].Values, $"Row {i + 1} values do not match");
            }

        }

        [Then(@"I get and exception with message ""([^""]*)""")]
        public void ThenIGetAndExceptionWithMessage(string errorMessage)
        {
            Assert.NotNull(_error);
            Assert.AreEqual(errorMessage, _error!.Message);
        }

    }
}
