/*
 * When player reaches half of the screen, 
 * the script moves the camera by half.
 * Only the camera's x position will be moved.
 * 
 * This means that the player will always be 
 * at the edge of the camera (After the beginning 
 * of the level).
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public Transform end;
	public Transform start;

	private float offset;
	private float min_x, max_x;

	private Vector3 initialPos;

	void Start () {
		initialPos = new Vector3 (start.position.x + 8, transform.position.y, transform.position.z);
		transform.position = initialPos;

		offset = transform.position.x - player.position.x;

		min_x = start.position.x + 8;
		max_x = end.position.x - 8;
	}
	
	void LateUpdate () {
		transform.position = new Vector3 (Mathf.Clamp (offset + player.position.x, min_x, max_x), transform.position.y, transform.position.z);
	}
}
