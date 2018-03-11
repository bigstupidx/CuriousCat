/*
 * When player hits an obstacle, it 'resets'
 * Goes back to original position
 * Health is decreased by 1
 * 
 * When it's reset 3 times, its game over!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	private Rigidbody2D rb2d;
	private CoinCollector coinCollector;
	private GameObject obstacle;
	private Vector3 initialPosition;
	private int count = 0;

	public GameObject chest;
	public List<GameObject> lives;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		coinCollector = GetComponent<CoinCollector> ();
	}

	void Start () {
		initialPosition = transform.position;
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.gameObject.tag == "Obstacle") 
		{
			chest.SetActive (true);
			coinCollector.chestimage.gameObject.SetActive (false);
			coinCollector.hasTakenChest = false;

			if (CoinCollector.score > 5)
				CoinCollector.score -= 5;

			transform.position = initialPosition;
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce (Vector2.zero);

			Destroy (lives[lives.Count - 1]);
			lives.RemoveAt (lives.Count - 1);

			count++;

			if (count >= 3)		//- score = 0, reset scene
				print ("Game Over!");
		}
	}
}
