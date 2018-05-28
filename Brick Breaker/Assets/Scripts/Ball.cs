using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	private Paddle paddle;

	private bool hasStarted = false;

	private Vector3 paddleToBallVector;
	private AudioSource myAudio;

	void Awake()
	{
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		myAudio = GetComponent<AudioSource> ();
	}

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hasStarted == false) 
		{
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) 
			{
				hasStarted = true;
				print ("Mouse Clicked");

				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		
		if (hasStarted) 
		{
			myAudio.Play ();
			GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
