
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

<img align="left" width="400px" src="https://user-images.githubusercontent.com/57855070/102353238-759e4500-3fb1-11eb-9aa8-56cfeeff3d9f.gif" /> 
