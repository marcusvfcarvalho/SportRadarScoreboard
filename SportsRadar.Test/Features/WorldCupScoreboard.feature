Feature: WorldCupScoreboard

Scenario: Create a new Scoreboard
	Given I created a Scoreboard
	When I list ongoing matches
	Then I get an empty score

Scenario: Add a new match score
	Given I created a Scoreboard
	When  I add a match between home team "Country 1" and away team "Country 2" 
	And   When I list the scoreboard
	Then I get the correct list

Scenario: Add a duplicate match
	Given I created a Scoreboard
	When  I add a match between home team "Country 1" and away team "Country 2" 
	And   I add a match between home team "Country 1" and away team "Country 2" 
	Then I get and exception with message "Match already added"

Scenario: Update a match
    Given I created a Scoreboard
	And I have the following match on the scoreboard:
	| Home Team | Away Team | Home Team Score | Away Team Score |
	| Country 1 | Country 2 | 0               | 0               |
	When I update the score to Home 1 and Away 0
	Then I get the following score
	| Home Team | Away Team | Home Team Score | Away Team Score |
	| Country 1 | Country 2 | 1               | 0               |

Scenario: Finishing a match 
  Given I created a Scoreboard
	And I have the following match on the scoreboard:
	| Home Team | Away Team | Home Team Score | Away Team Score |
	| Country 1 | Country 2 | 3               | 0               |
	When I finish the match
	Then I get an empty scoreboard

Scenario: Listing all ongoing matches
Given I created a Scoreboard
And I have the following match on the scoreboard:
	| Home Team | Away Team | Home Team Score | Away Team Score |
	| Mexico    | Canada    | 0               | 5               |
	| Spain     | Brazil    | 10              | 2               |
	| Germany   | France    | 2               | 2               |
	| Uruguay   | Italy     | 6               | 6               |
	| Argentina | Australia | 3               | 1               |
When I list the ongoing maches I get the following list:
	| Home Team | Away Team | Home Team Score | Away Team Score |
	| Uruguay   | Italy     | 6               | 6               |
	| Spain     | Brazil    | 10              | 2               |
	| Mexico    | Canada    | 0               | 5               |
	| Argentina | Australia | 3               | 1               |
	| Germany   | France    | 2               | 2               |


