using UnityEngine;
using System.Collections;

public class MapCursorToHand : MonoBehaviour {
	public GameObject handCursor;
	public SkeletonPointClassY skeletonPointClassY;
	public SkeletonPointClassX skeletonPointClassX;
	public SkeletonController skeltonController;
	public static readonly float handZPosition = 3.899715f;
	float newY = 0;
	float newX = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(skeltonController.IsTracking)
		{
			newX = skeletonPointClassX.scaledNewX(-skeletonPointClassX.LeftHand/1000);
			newY = skeletonPointClassY.scaledNewY(skeletonPointClassY.LeftHand/1000);
			handCursor.transform.position= new Vector3(newX*2, newY*2, handZPosition);

			Debug.Log("AAAAAA XXXXXXX" + handCursor.transform.position.x);
			Debug.Log("AAAAAA YYYYYYY" + handCursor.transform.position.y);
		}
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (Screen.width/2, Screen.height/2, 500, 500));
		GUILayout.Box("Right Wrist" + skeletonPointClassX.scaledNewX(skeletonPointClassX.RightWrist/1000));
		GUILayout.Box("Left Wrist" + skeletonPointClassX.scaledNewX(skeletonPointClassX.LeftWrist/1000));
		GUILayout.Box("Right Elbow" + skeletonPointClassX.scaledNewX(skeletonPointClassX.RightElbow/1000));
		GUILayout.Box("Left Elbow" + skeletonPointClassX.scaledNewX(skeletonPointClassX.LeftElbow/1000));
		GUILayout.EndArea();
	}
	

}