using UnityEngine;
using System.Collections;

public class DetectHover : MonoBehaviour {
	public GameObject[] hahas;
	public string hahaName;
	float x;
	float y;
	// Use this for initialization
	void Start () {
		// First find a center for your bounds.
		hahaName = "NULL";
		
	}
	
	// Update is called once per frame
	
//	void OnTriggerEnter(Collider col)
//	{
//	    if (col.gameObject.name == "CollidorTry")
//	    {
//			
//	    }
// 
//}
    void Update() {
		for (int i = 0 ; i <hahas.Length ; i++)
		{
			 x =Camera.main.WorldToScreenPoint(hahas[i].transform.position).x;
			 y =Camera.main.WorldToScreenPoint(hahas[i].transform.position).y;
			hahas[i].renderer.enabled = false;
			if (guiTexture.HitTest(new Vector3(x,y,3.899715f)))
			{
				hahaName = hahas[i].name;
				break;
			}
			
			hahaName = "NULL";
		}
    
    }
	
	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (Screen.width/2, Screen.height/2, 500, 500));	
		if(!hahaName.Equals("NULL"))
		{
			GUILayout.Box(hahaName + " is Detected");
		}
		GUILayout.EndArea();
	}


}
