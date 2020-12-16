using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMoverByTile: KeyboardMover {
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;
    [SerializeField] TileBase mountain = null;
    [SerializeField] TileBase hill = null;
    [SerializeField] KeyCode toQuarry = KeyCode.X;

    private TileBase TileOnPosition(Vector3 worldPosition) {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    private bool beingHandled = false;
    private IEnumerator HandleIt()
    {
        beingHandled = true;
        // process pre-yield
        yield return new WaitForSeconds(2.0f);
        // process post-yield
        beingHandled = false;
    }


    void Update()  {
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        if (allowedTiles.Contains(tileOnNewPosition))
        {
            transform.position = newPosition;
        }
        else if (Input.GetKey(toQuarry)&& tileOnNewPosition.Equals(mountain) && !beingHandled)
        {
            tilemap.SetTile(tilemap.WorldToCell(newPosition), hill);
            StartCoroutine(HandleIt());
            transform.position = newPosition;
        }
        
        else
        {
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
        }
    }
}
