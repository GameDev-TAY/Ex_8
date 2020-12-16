
![image](https://user-images.githubusercontent.com/57855070/102347040-826a6b00-3fa8-11eb-86b4-4cd80509b9e9.png)

This project was done as part of the "Computer Game Development" course at Ariel University.

You can see the assignment at the [following link](https://github.com/gamedev-at-ariel/gamedev-5781/blob/master/08-unity-tilemap-algorithms/homework.pdf) .

You will see the basic code we started working on at the [following link](https://github.com/gamedev-at-ariel/05-tilemap-pathfinding) .

## We made 4 changes:
***

**1.Changed the game so that the player's walking speed depends on the tiles he is walking on -** 
In order for this change to happen we added the modified files:
[AllowedTiles](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/1-tiles/AllowedTiles.cs) ,
[TargetMover](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/2-player/TargetMover.cs)

In [AllowedTiles](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/1-tiles/AllowedTiles.cs) we have added a new class called: TileBaseSpeed which has two attributes one of the TileBase type and the other is the speed, The nodes in the list of allowed tiles will be of the new class type TileBaseSpeed.
Since we changed the type of nodes of the list, we changed the transition over the list in the existing functions on the list, and added the GetSpeed function.

* Here you can see that the player walks much more slowly on hills than on the grass:

  <img align="left" width="400px" src="https://user-images.githubusercontent.com/57855070/102354140-d37f5c80-3fb2-11eb-9f02-2f8b0f9573f8.gif"/>  
  
<br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> 

**2.We added that the player will have the option to carve on a mountain -** 
By pressing X and the button of the direction he wants to carve. Quarrying will be slower than normal walking.
Currently the movement buttons are around the "G" button on the keyboard so:
"T" to the left
"Y" up right
"H" to the right
"B" bottom right
"V" bottom left
"F" left

In order for this change to happen we added the modified file: [KeyboardMoverByTile](https://github.com/GameDev-TAY/Ex_8/blob/master/Assets/Scripts/2-player/KeyboardMoverByTile.cs) . <br /> 
We added three fields to the class, a tile that marks a mountain, a tile that marks a hill and the button that marks the quarry.They are all SerializeField.

<img align="left" width="400px" src="https://user-images.githubusercontent.com/57855070/102353238-759e4500-3fb1-11eb-9aa8-56cfeeff3d9f.gif" /> 
