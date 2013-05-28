using UnityEngine;
using System.Collections;

public class LoadScenetest : MonoBehaviour {


	void OnGUI()
	{
		if (HorizontalProgressBar.progressBarSize > 150)
		{
			Application.LoadLevel(1);
		}
	}	
}
