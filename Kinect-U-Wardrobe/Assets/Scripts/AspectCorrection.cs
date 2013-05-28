using UnityEngine;
using System.Collections;

public class AspectCorrection : MonoBehaviour{
 
   void Start () {
      float currentRatio = (float)Screen.width / Screen.height;

      guiText.fontSize = Screen.width > 1400 ? 90 : 40;
      guiText.pixelOffset = new Vector2(Screen.width/9.0f, 0.0f);

      }
}


