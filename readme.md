# Technical task
### Developer Unity/C#
Create a program which has ability to save activity of players. In implementation use next data:
1. Every **“Player”** class has internal identifier and name;
2. Every **“Activity”** class has internal player identifier, activity name and for simplify three kind of activities. They are:
3. Entered the game;
4. In game process;
5. Exited.
As a vault you must use a file system. Number of files and them structure could be whatever. You could **not** use **“sqlite”** or any other database. In implementation provide the ability of multiple thread access to the repository.
For simplify implementation you could use the fixed player list:
* {1, Deadpool};
* {2, Thanos};
* {3, Ultron}.