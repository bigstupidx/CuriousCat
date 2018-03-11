using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuriousController : MonoBehaviour {

	[HideInInspector] public bool jump = true;
	[HideInInspector] public bool isFacingRight = true;

	private Animator characterAnimController;
	private Rigidbody2D rb2d;
	private bool grounded = false;
	private bool doubleJump = false;


	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	void Awake () {
		characterAnimController = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown("Jump") && (grounded || !doubleJump))
		{
			jump = true;

			if (!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		characterAnimController.SetFloat ("Speed", Mathf.Abs (h));

		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce (Vector2.right * h * moveForce);
		
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);	

		if (h > 0 && !isFacingRight)
			Flip ();
		else if (h < 0 && isFacingRight)
			Flip ();

		if (jump) {
			characterAnimController.SetTrigger ("isJumping");
			rb2d.AddForce (new Vector2(0f, jumpForce));
			jump = false;
		}

		if (grounded)
			doubleJump = false;
	}

	void Flip () 
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
