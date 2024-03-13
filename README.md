### **SportRadar WorldCup Scoreboard**
This repository contains the code of a simple scoreboard class that mantains and lists ongoing matches.

# **WorldCupScoreboard Class**
The **WorldCupScoreboard** class is a component of the SportRadarLibrary namespace designed to manage and display information about ongoing World Cup matches. It provides functionality for adding, updating, finishing matches, and listing ongoing matches in a sorted order based on scores and start times.
## **Methods**
### **StartMatch**
csharp![ref1]Copy code

public MatchReference StartMatch(string homeTeam, string awayTeam, int homeScore = 0, int awayScore = 0) 

Adds a new match to the scoreboard with the provided home and away teams, and optionally their scores.

Returns a reference to the created match.
### **UpdateScore**
```

public MatchReference UpdateScore(Guid matchId, int homeScore, int awayScore) 

```
Updates the score of an ongoing match identified by the provided match ID.

Returns a reference to the updated match.

Throws an exception if the match is not found.
### **FinishMatch**
```
public void FinishMatch(Guid matchId) 
```
Marks a match as finished and removes it from the scoreboard based on the provided match ID.
### **ListMatches**
```
public List<MatchReference> ListMatches() 

```
Lists all ongoing matches ordered by the highest score and time of start.

Returns an ordered list of match references.
## **Class Members**
### **Fields**
**\_matches**: A list of ongoing matches managed by the scoreboard.
### **Private Methods**
**CreateReference**: Creates a match reference object from a given match instance.
## **Usage**
```

// Example usage of the WorldCupScoreboard 
class var scoreboard = new WorldCupScoreboard(); 
// Starting a match 
var matchReference = scoreboard.StartMatch("Home Team", "Away Team"); 
// Updating the score of a match 
scoreboard.UpdateScore(matchReference.Id, 2, 1); 
// Finishing a match 
scoreboard.FinishMatch(matchReference.Id); 
// Listing ongoing matches 
var ongoingMatches = scoreboard.ListMatches();
```
