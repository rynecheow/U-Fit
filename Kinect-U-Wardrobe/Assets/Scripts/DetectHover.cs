using UnityEngine;
using System.Collections;

public class DetectHover : MonoBehaviour {
   public GameObject[] cube;
	public GameObject[] shirt;
	public string cubeName;
	public GameObject shirtChosen;
	float x;
	float y;
	public static readonly float Z_CONSTANT = 3.899715f; 

	// Use this for initialization
	void Start () {
		// First find a center for your bounds.
		cubeName = "NULL";
		shirtChosen = null;
	}
	
	// Update is called once per frame
   void Update() {
      for (int i = 0 ; i < cube.Length ; i++){
         x = Camera.main.WorldToScreenPoint(cube[i].transform.position).x;
         y = Camera.main.WorldToScreenPoint(cube[i].transform.position).y;
         cube[i].renderer.enabled = false;
         if (guiTexture.HitTest(new Vector3(x,y,Z_CONSTANT))){
            cubeName = cube[i].name;
            shirtChosen = shirt[i];
            break;
         }
            cubeName = "NULL";
      }
   }
	
   void OnGUI(){
      GUILayout.BeginArea (new Rect (Screen.width/2, Screen.height/2, 500, 500));	
      if(!cubeName.Equals("NULL")){
         GUILayout.Box(cubeName + " is Detected");
      }
      GUILayout.EndArea();
   }
}
