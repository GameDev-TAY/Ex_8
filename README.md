
![image](https://user-images.githubusercontent.com/57855070/102347040-826a6b00-3fa8-11eb-86b4-4cd80509b9e9.png)

This project was done as part of the "Computer Game Development" course at Ariel University.

You can see the assignment at the [following link](https://github.com/gamedev-at-ariel/gamedev-5781/blob/master/08-unity-tilemap-algorithms/homework.pdf) .

You will see the basic code we started working on at the [following link](https://github.com/gamedev-at-ariel/05-tilemap-pathfinding) .

## We made 4 changes:
***

#### **1.Changed the game so that the player's walking speed depends on the tiles he is walking on -** <br />
In order for this change to happen we added the modified files:
[AllowedTiles](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/1-tiles/AllowedTiles.cs) ,
[TargetMover](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/2-player/TargetMover.cs)

In [AllowedTiles](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/1-tiles/AllowedTiles.cs) we have added a new class called: TileBaseSpeed which has two attributes one of the TileBase type and the other is the speed, The nodes in the list of allowed tiles will be of the new class type TileBaseSpeed.
Since we changed the type of nodes of the list, we changed the transition over the list in the existing functions on the list, and added the GetSpeed function.
In the class [TargetMover](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/2-player/TargetMover.cs) we changed the update function so that the display of the player character's movement would be affected by any tile speed by the UpdateTimeBetweenSteps function.

We have 16 tiles allowed: <br />

<img align="left" width="200px" height="50px" src="https://user-images.githubusercontent.com/57855070/102368961-1c8bdc80-3fc4-11eb-84a6-147fe3f1df01.png" />  
<img align="left" width="200px" height="50px" src="https://user-images.githubusercontent.com/57855070/102368630-bd2dcc80-3fc3-11eb-95b4-c46c5d525812.png" />  
<img align="left" width="150px" height="50px" src="https://user-images.githubusercontent.com/57855070/102369223-6248a500-3fc4-11eb-81f2-2031c054fadb.png" />
<img align="left" width="200px" height="50px" src="https://user-images.githubusercontent.com/57855070/102370494-c9b32480-3fc5-11eb-9326-38df7454edca.png" />  
<img align="left" width="50px" height="50px" src="https://user-images.githubusercontent.com/57855070/102369618-d2efc180-3fc4-11eb-86f2-e97b99e32e7a.png" />

<br /> <br />

* Here you can see that the player walks much more slowly on brown than on the green:

  <img align="left" width="300px" height="200px" src="https://user-images.githubusercontent.com/57855070/102371628-11867b80-3fc7-11eb-94ee-a11c7fe4829b.gif"/>

<br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />
#### **2.We added that the player will have the option to carve on a mountain -** <br />
By pressing X and the button of the direction he wants to carve. Quarrying will be slower than normal walking.
Currently the movement buttons are around the "G" button on the keyboard so:
"T" to the left <br />
"Y" up right <br />
"H" to the right <br />
"B" bottom right <br />
"V" bottom left <br />
"F" left <br />

In order for this change to happen we added the modified file: [KeyboardMoverByTile](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/2-player/KeyboardMoverByTile.cs) . <br /> 
We added three fields to the class, a tile that marks a mountain, a tile that marks a hill and the button that marks the quarry.They are all SerializeField.
In the update function we checked whether the quarrying key was pressed and if there is a place to quarry in the direction the player is requesting and if enough time has passed since the last quarrying, then we update the quarrying causes delay and update a new location.

* Here you can see that the player carved in the rock:
 <img align="left" width="300px" height="200px" src="https://user-images.githubusercontent.com/57855070/102372516-ef412d80-3fc7-11eb-86b0-b85791b9423b.gif"/>


<br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />

#### **3.We changed the rectangular grid to hexagon grid -** <br />
By simply setting up a new grid and adding new sprites from the [asset store](https://assetstore.unity.com/packages/2d/environments/2d-hex-sprites-hexagonal-tile-setup-135185)
and create new [Palette](https://github.com/GameDev-TAY/Ex_8/tree/master/Assets/HexSpriteTiles_Setup/Palettes).

#### **4.Paint with Unity tiles-** <br />
We found on this [site](https://www.myabandonware.com/) A game that has a two-dimensional world at a glance, and we drew one level of it in the Unity tile map.
It's in the scene [BUMFIGHT](https://github.com/GameDev-TAY/Ex_8/tree/master/Assets/Scenes/5-bumfight)

<img align="left" width="400px" src="https://user-images.githubusercontent.com/57855070/102362951-9cfb0f00-3fbd-11eb-9160-9ca94d312d9c.png" />  




