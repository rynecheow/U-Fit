using UnityEngine;
using System.Collections;

public class LoadScenetest : MonoBehaviour {


	void OnGUI()
	{
		if (HorizontalProgressBar.PROGRESS_BAR_SIZE > 150)
		{
			Application.LoadLevel(1);
		}
	}	
}
