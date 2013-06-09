using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	void OnGUI(){
		if (HorizontalProgressBar.PROGRESS_BAR_SIZE > 150){
			Application.LoadLevel(1);
		}
	}	
}