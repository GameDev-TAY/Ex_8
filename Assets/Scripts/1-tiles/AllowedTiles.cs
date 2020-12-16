using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;


[System.Serializable]
public class TileBaseSpeed
{
    public TileBase tileBase;
    public float speed;
}
/**
 * This component just keeps a list of allowed tiles.
 * Such a list is used both for pathfinding and for movement.
 */
public class AllowedTiles : MonoBehaviour  {
    [SerializeField] TileBaseSpeed[] allowedTiles = null;

    public float GetSpeed(TileBase tile)
    {
        for (int i = 0; i < allowedTiles.Length; i++)
        {
            if (allowedTiles[i].tileBase.Equals(tile))
            {
                return allowedTiles[i].speed;
            }
        }
        return 0;
    }

    public bool Contains(TileBase tile) {
        for(int i = 0; i < allowedTiles.Length; i++)
        {
            if (allowedTiles[i].tileBase.Equals(tile))
            { 
                return true;
            }
        }
        return false;
    }

   
    public TileBase[] Get() {
        TileBase[] toReturn = new TileBase[allowedTiles.Length];

        for (int i =0; i<allowedTiles.Length; i++)
        {
            toReturn[i] = allowedTiles[i].tileBase;
        }
        return toReturn; 
    }
 
}
