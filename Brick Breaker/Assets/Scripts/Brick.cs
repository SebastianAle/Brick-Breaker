using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{
	public static int breakableCount = 0;

	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject smoke;

	private int timesHits;
	private LevelManager levelManager;
	private bool isBreakable;


	void Start () 
	{
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) 
		{
			breakableCount++;
		}

		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHits = 0;
	}

	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) 
		{
			HandleHits ();
		}
	}

	void HandleHits()
	{
		timesHits++;
		int maxHits = hitSprites.Length + 1;
		if (timesHits >= maxHits) 
		{
			breakableCount--;
			levelManager.BrickDestroyed ();
			GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem> ().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
			Destroy (gameObject);
		} 
		else 
		{
			LoadSprites ();
		}
	}

	void LoadSprites()
	{
		int spriteIndex = timesHits - 1;
		if (hitSprites [spriteIndex] != null) 
		{
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} 
		else 
		{
			Debug.LogError ("Brick sprite is missing");
		}

	}
}
