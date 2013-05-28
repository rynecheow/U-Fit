using UnityEngine;
using System.Collections;

public class AspectCorrection : MonoBehaviour
{
 
    void Start ()
    {
        float currentRatio = (float)Screen.width / (float)Screen.height;
		
		if(Screen.width > 1400)
			guiText.fontSize = 90;
		else
			guiText.fontSize = 40;
		
		guiText.pixelOffset = new Vector2(Screen.width/9,0f);
    }
 
}


