# Getalld
 GameProgamming/editot
A brief description of what this project does and who it s for.
This is Get all d games,which is a plafotrmer game fo pc or laptop.The game
consist of a theif which found him self in a mysterious fantasy world and he lost all the diamonds he stole,the theif needs help 
to collect all the diaomnds back,but one need to avoid all the obstacles found in the game world.
When the player finds all diamond sack wins.
This game is for everyone but the main target audience is for children over 6 years old.
Apart from the game,embedded there is a music and sound effect Trigger Editor.Sound is played with 
trigger events in the game.These sound conssit of sound when the player touches obstacles,2 different
background music.

**##Appendix**
To open the editor Ui click on the Menu on top on hoover on Game and click on Menu

##Assets folder
The animations folder has all the animations.
The Edtior file has the Ui interfaces of the Editor tool
The Image file has all the images used on the canvas
The obejcts file has in it the different tiles and the sound type attached to them.
in the resources there are all the sound files,and the icons used on the game.
Tiles folder ahs all the differnt tiles created and the prefabs used for the tile.
The sprite folder has the model sheet.
The audio mixer has the 2 different background sounds.

**##The Scripts**

##Behaviours folder

**##Player Behaviour**
Player bahaviour control the player movment,speed,jump and player animation.
The update method change the state to Playing,and control the player movement.
FixedUpdate() : moves the player with time.delta time.
Jump method(): controls the jumpspeed.


**##Player Health**
In this script,checks the health of the player and update the health value.
Take Damage() method checks the current health amount.


**##Sound settings**
This script create an Asset Menu
In it there is the declaration of the Audio Clips as serialzed field
Then in the case switch it check the sounds and plays it.


**##Diamond Collector Script**
This class has 1 method OnTriggerEnter2D(Collider2D other)
{ check if the tag is
a diamond and then increment score and destroy the diamond.
}

**##Diamond Tile**
This creates a custome Tile, Diamond Tile and SoundTile.

**##Event Manager**
In the event manager script,has SerialeField TileMap,
private SoundSetting Setting and 2dSound Collider.
Then create tha gameobject in unity the 2 audio sources musicSource and SFX source.
The awake method,check that the instance is not null else destroy game object.

**##FillBar**
This script has delcared the playerhealth and the slider component
The update check the amount if the value of the slider.
The awkake get the slider component.

**##Game Manager**
The game manager class,handles the score and high score.
Create a new instance from the scores class 
In it there is the decleration as game object of different UI.
The awake method,checks if there is more than 1 game manager then loads the data.
The Start method, changes GameState to Welcome.
The AddScore add the score by 1 and checks that if there is a high score
and updates the text;
Update PlayerPosition saves the current player pos.
Update health bar save the health bar state and if reaches 0 then the screen change to
endGame.
 
Change State of Game method,set active the newState to Game State.
All the other methods change state to a particular state.

**##Game State**
is an enum class,which in it has all the States in the game.

**#Sack**
Has an OnTriggerEnter2D which as the player touch it change the scene to winning scene.

**##SavesData**
Save and load the Data of score in a json file,

**##Score**
delcare the score and high score and health.


**##SoundSpawner**
Is a class which is used for the Sound trigger.
Declare the tilemap and declare the Sound trigger Prefab and SoundSettigs Settings
The Start method checks the tile,instintate prefab position and trigger Sound Clip
as Sound tile.

**##Sound Tile**
declare enum SoundType with different sounds,a tile name SoundTile.

**##SoundTrigger**
This class has Audio Clip declare
and in teh OnTriggerEnter2D methos check the tag of the player and plays the sound.
SetClip,creates a new Audio Clip.

