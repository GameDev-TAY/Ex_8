using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * A graph that represents a tilemap, using only the allowed tiles.
 */
public class TilemapGraph : IWeightedGraph<Vector3Int>
{
    private Tilemap tilemap;
    private AllowedTiles allowedTiles;

    public TilemapGraph(Tilemap tilemap, AllowedTiles allowedTiles)
    {
        this.tilemap = tilemap;
        this.allowedTiles = allowedTiles;
    }

    static Vector3Int
        LEFT = new Vector3Int(-1, 0, 0),
        RIGHT = new Vector3Int(1, 0, 0),
        DOWN = new Vector3Int(0, -1, 0),
        DOWNLEFT = new Vector3Int(-1, -1, 0),
        DOWNRIGHT = new Vector3Int(1, -1, 0),
        UP = new Vector3Int(0, 1, 0),
        UPLEFT = new Vector3Int(-1, 1, 0),
        UPRIGHT = new Vector3Int(1, 1, 0);

    static Vector3Int[] directions_when_y_is_even = { LEFT, RIGHT, DOWN, DOWNLEFT, UP, UPLEFT };
    static Vector3Int[] directions_when_y_is_odd = { LEFT, RIGHT, DOWN, DOWNRIGHT, UP, UPRIGHT };

    public IEnumerable<Vector3Int> Neighbors(Vector3Int node)
    {
        var directions = (node.y % 2 == 0 ? directions_when_y_is_even : directions_when_y_is_odd);
        foreach (var direction in directions)
        {
            Vector3Int neighborPos = node + direction;
            TileBase neighborTile = tilemap.GetTile(neighborPos);
            Debug.Log(node + " --> " + neighborPos);
            if (allowedTiles.Contains(neighborTile))
            {
                yield return neighborPos;
            }
        }
    }

    public float Distance(Vector3Int node, Vector3Int neighbor)
    {
        return 5/(allowedTiles.GetSpeed(tilemap.GetTile(neighbor)));
    }

    public float AirDistance(Vector3Int node, Vector3Int otherNode)
    {
        return (Mathf.Abs(node.x - otherNode.x) + Mathf.Abs(node.y - otherNode.y));
    }
}