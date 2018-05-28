using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour 
{

	public void LoadLevel(string name)
	{
		Debug.Log ("Load level requested: " + name);
		Brick.breakableCount = 0;
		SceneManager.LoadScene (name);
	}

	public void QuitLevel()
	{
		Debug.Log ("I want to quit!");
	}

	public void LoadNextLevel()
	{
		Brick.breakableCount = 0;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void BrickDestroyed()
	{
		if (Brick.breakableCount <= 0) 
		{
			LoadNextLevel ();
		} 
	}
}
