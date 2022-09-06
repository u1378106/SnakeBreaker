# SnakeBreaker


The software architecture used in the game can be considered as a layered software architecture, since the game functionalities are managed at different layers. The GameManager acts as the controller where as the UI and game features are handled independently. There are certain scenarios where event driven architecture fundamentals were also used, which were called whenever a specific event gets triggered.
 
The reason behind using this software architecture is to keep game codes as separate as possible, which can be governed by a single class. This helps in keeping the code clean and achieve decoupling till a certain level. The layers also help maintain code readability and makes it easier to understand the program.

I learnt that keeping the architecture layered can help in managing the code independently, which does not affect other classes and features. The presentation, application and data layer can be understood more clearly as each of them is distinguished with the help of this architecture.

There were certain scenarios where the classes needed to be dependent on each other. Keeping things in layers makes the application rigid while sharing information. Thus, I would like to make use of patterns which solves the issues keeping code organized and structured.

## _Here is a code analysis:_
-	GameManager – Manages the high-level game related features. The GameManager class owns the properties related to the ball, such as getting the status if ball is served. Determines the win-lose condition and maintain the trajectory
-	Snake – Base class for snake object, maintains the snake position and speed
-	SnakeHandler – This class handles the creation of snakes dynamically in the game. The variables are private but serialized, to expose to the editor. This class takes snake-body, snake-head and snake-tail as gameobject variables and attaches them together to stitch into a single snake. The head is instantiated first, followed by a loop which randomly decides the number of body parts and then ends with attaching a tail. Once created, all the snake parts are attached to a parent ‘Snake’ object to maintain the hierarchy. This class also decides the number of snakes to spawn
-	Trajectory – Responsible for creating the trajectory using the ‘Dot’ prefab. Hides and generates dots to determine the initial direction of shooting the ball
-	Platform – Class which handles the platform gameobject. Main functions of this class manages the movement of platform using keyboard events and also identify the bounds to keep the platform within the screen bounds
-	Ball – Ball class handles the properties related to ball gameobject. The ball velocity is determined here and the class checks velocity to prevent ball from rolling in the same direction forever. Detects collision to determine events for destroying snake and losing the game
-	InteractionManager – This class is responsible for handling the UI interactions. The interfaces are implemented here to detect the mouse hovering positions, which notifies the animation to be played in the UI layer
-	AudioManager – Acts as a single class to manages all the audios being played in the game. The variables are kept public to access audios through entire game lifecycle
