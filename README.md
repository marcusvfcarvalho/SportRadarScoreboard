### **SportRadar WorldCup Scoreboard**
This repository contains the code of a simple scoreboard class that mantains and lists ongoing matches.

# **WorldCupScoreboard Class**
The **WorldCupScoreboard** class is a component of the SportRadarLibrary namespace designed to manage and display information about ongoing World Cup matches. It provides functionality for adding, updating, finishing matches, and listing ongoing matches in a sorted order based on scores and start times.
## **Methods**
### **StartMatch**

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

## **Design Choices**
### **Classes and Records**
In the design of the WorldCupScoreboard class, a deliberate choice was made to utilize two types of classes: MatchReference and Match. This decision was motivated by the intention to enforce encapsulation and data integrity within the class's functionality.

The MatchReference class is designed as an immutable record. It serves as a lightweight, read-only representation of a match, containing essential information such as team names and scores. By making MatchReference immutable, external users are prevented from modifying match data directly, ensuring that the integrity of match information is maintained throughout its lifecycle.

On the other hand, the Match class is mutable and serves as a container for ongoing match data. It includes properties for storing dynamic information such as scores and start times. By encapsulating match data within a mutable class, direct modification from external sources is restricted, and users are encouraged to interact with match data through the designated methods provided by the WorldCupScoreboard class.

### **Dealing with non-existing matches**
In the provided code for the WorldCupScoreboard class, two distinct strategies are employed when dealing with non-existent matches in the scoreboard: exception handling in the UpdateScore method and ignoring the absence of the match in the FinishMatch method.

In the UpdateScore method, an exception is thrown when attempting to update the score of a match that does not exist. This approach ensures that any attempt to update a non-existent match is immediately brought to the attention of the caller, allowing for proper error handling and ensuring data integrity.

Conversely, in the FinishMatch method, no exception is thrown if the match specified for finishing does not exist. Instead, the method simply proceeds without taking any action. This strategy may be suitable in scenarios where failing to find a match to finish is not considered critical, and the method can gracefully handle such situations without disrupting the application's flow.
