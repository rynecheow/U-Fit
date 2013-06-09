using UnityEngine;
using System.Collections;

public class DetectHover : MonoBehaviour {
	public GameObject[] hahas;
	public string hahaName;
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
			if (guiTexture.HitTest(Camera.main.WorldToScreenPoint(hahas[i].transform.position)))
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
