# Snake 3D
The Sanke 3D, is a game developed using Unity. The snake grows by a length of 1 every time it eats food on the map. 1 food spawns on the map at the start of the game and every time the snake eats the food - a new food piece gets spawned somewhere else on the map. The game is over when the snake collides with the edge of the map.

Dummy assets are used to create the game.

# Game Control
Using 4 arrows of the keyboard to control the snake's move. the default movement of the sake is in the Right Direction.

# Direction
Left Arrow - Left
Right Arrow - Right
Up Arrow - Up
Down Arrow - Down

If the snake hits the wall the snake will die, and a Game Over Popup will display.
Food will be generated randomly in the defined area. The variety of the food items are read from a JSON file from the Resource and add the food property to the new. food generated once the snake ate the food. 

Once the snake's head collides with food, the score will increment by the defined amount in the parameters set by the data for that type of food. If you eat the food of the same color as the previous one, that food’s score will be multiplied by the current streak “colliding with the same color”.

Two Scene is used to develop this game. The Main Scene contains the top score value and Game Start Buton. By click start game the Game Play scene will load the game starts automatically.


# Extra Tools used
Newtonsoft Json.dll is used for parsing JSON data string.


# video link

https://www.youtube.com/watch?v=N-ZS_oF7Z2g
