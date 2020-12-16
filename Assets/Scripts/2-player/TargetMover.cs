using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component moves its object towards a given target position.
 */
public class TargetMover: MonoBehaviour {
    [SerializeField] protected Tilemap tilemap = null;
    [SerializeField] protected AllowedTiles allowedTiles = null;

    float speed = 2f;

    [Tooltip("Maximum number of iterations before BFS algorithm gives up on finding a path")]
    [SerializeField] int maxIterations = 1000;

    [Tooltip("The target position in world coordinates")]
    [SerializeField] Vector3 targetInWorld;

    [Tooltip("The target position in grid coordinates")]
    [SerializeField] Vector3Int targetInGrid;

    protected bool atTarget;  // This property is set to "true" whenever the object has already found the target.

    public void SetTarget(Vector3 newTarget) {
        if (targetInWorld != newTarget) {
            targetInWorld = newTarget;
            targetInGrid = tilemap.WorldToCell(targetInWorld);
            Debug.Log("Click :" + targetInGrid);
            atTarget = false;
        }
    }

    public Vector3 GetTarget() {
        return targetInWorld;
    }

    private TilemapGraph tilemapGraph = null;
    private float timeBetweenSteps;

    protected void UpdateTimeBetweenSteps (TileBase tileBase) {
        speed = allowedTiles.GetSpeed(tileBase);
        timeBetweenSteps = 5 / speed;
    }

    protected virtual void Start() {
        tilemapGraph = new TilemapGraph(tilemap, allowedTiles.Get());
        timeBetweenSteps = 1 / speed;
        StartCoroutine(MoveTowardsTheTarget());
    }

    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    IEnumerator MoveTowardsTheTarget() {
        for(;;) {
            UpdateTimeBetweenSteps(TileOnPosition(transform.position));
            yield return new WaitForSeconds(timeBetweenSteps);
            if (enabled && !atTarget)
                MakeOneStepTowardsTheTarget();
        }
    }

    private void MakeOneStepTowardsTheTarget() {
        Vector3Int startNode = tilemap.WorldToCell(transform.position);
        Vector3Int endNode = targetInGrid;
        List<Vector3Int> shortestPath = BFS.GetPath(tilemapGraph, startNode, endNode, maxIterations);
        //Debug.Log("shortestPath = " + string.Join(" , ",shortestPath));
        if (shortestPath.Count >= 2) {
            Vector3Int nextNode = shortestPath[1];
            transform.position = tilemap.GetCellCenterWorld(nextNode);
        } else {
            atTarget = true;
        }
    }
}
