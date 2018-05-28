using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour 
{
	public static MusicPlayer instance;

	void Awake()
	{
		MakeSingleton ();
	}

	void MakeSingleton()
	{
		if (instance != null) 
		{
			Destroy (gameObject);
		} 

		else 
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
}
