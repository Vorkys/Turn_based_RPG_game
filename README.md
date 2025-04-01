# ASCII Adventure
This project is a program developed by only myself as part of my Bachelor. The project is open-source and is playable on any PC that can run .exe and has .NET 9.0 installed.

## Dependecies
- only dependency is .NET 9.0 downloadable at: https://dotnet.microsoft.com/en-us/download/dotnet/9.0
---
## Technical documentation

### Class diagram:
![class diagram drawio](https://github.com/user-attachments/assets/7587ffa3-1dcc-474d-b87b-1bcc50430753)

### Stats informations:
https://insightmaker.com/insight/66TUuG7nGjIy44KP4LMVEi/BP-design

### Nodes, Spells and Items:
https://docs.google.com/spreadsheets/d/1gUhlrCLBu2qNzamf21vJsLRPSi-7dqDCMxIDyiMQlVk/edit?gid=0#gid=0
---
## Want to add your own content?

### Create your own map
1. make sure the root folder has a folder "Assets" in root
2. inside "Assets" create a txt file and fill it with signs (each node type is represented by 1 unique sign)
3. adapt the switch inside of "MapMaker" program to create wanted Nodes (from NodeManager)
4. run the "MapMaker" program with the file name as parameter
5. inside "Assets" should be a new JSON file called "SERIALIZED_{txt file name}.json" (this should be the map you created in a format the main game can use)
6. copy the new json file into "Maps" folder in game program roots folder
7. then in game program change the wanted map name to yours and the game should boot your map

### Create your own Node, Enemy, Spell or Item
1. in game project open folder "Source" then "Managers" and open the Manager you want
2. add public static instance you want to add
3. for example if you added a new Enemy make sure you add him into Node that should Spawn him
4. recreate a map json for it to be in the game (viz **Create your own map**)
5. copy into "Maps" folder and change name in game program
6. run (publish) and enjoy!
---
### Playtester form:
- playtime (time)
- what he liked (free text)
- what he didnt like (free text)
- what would he recommend/change (free text)
- is he a dev? (yes/no)
- does he think the code is readable and easy to add content to? (yes/no)
- more comments (free text)
