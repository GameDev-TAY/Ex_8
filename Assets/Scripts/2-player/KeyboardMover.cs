﻿using UnityEngine;

/**
 * This component allows the player to move by clicking the arrow keys.
 */
public class KeyboardMover : MonoBehaviour {

    protected Vector3 NewPosition() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            return transform.position + Vector3.left;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            return transform.position + Vector3.right;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            return transform.position + new Vector3(-0.5f, -0.75f);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            return transform.position + new Vector3(0.5f, 0.75f);
        } else {
            return transform.position;
        }
    }


    void Update()  {
        transform.position = NewPosition();
    }
}
