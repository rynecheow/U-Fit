using UnityEngine;
using System.Collections;

public class MapShirtToBody : MonoBehaviour {
	public GameObject shirt;
	public OpenNIUserTracker tracker;
	public Vector3 shirtPosition;
	public Vector3 trackerDepth;
	public float test;
	
	// Use this for initialization
	void Start () {
		shirtPosition = shirt.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		foreach (int userId in tracker.AllUsers)
		{
			trackerDepth = tracker.GetUserCenterOfMass(userId);
			test = ((trackerDepth.z) / 1000) ;
			shirt.transform.position = new Vector3(shirtPosition.x,shirtPosition.y,-test -0.2f);
			
		}
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (Screen.width/2 - 150, Screen.height/2 - 150, 500, 500));
		GUILayout.Box("Depth Shirt X is " + trackerDepth.x+ "Depth Shirt Y is " + trackerDepth.y+"Depth Shirt Z is " + trackerDepth.z);
		GUILayout.EndArea();
	}
}