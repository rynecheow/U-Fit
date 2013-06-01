using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {


	void OnGUI()
	{
		if (HorizontalProgressBar.progressBarSize > 150)
		{
			Application.LoadLevel(1);
		}
	}	
}
