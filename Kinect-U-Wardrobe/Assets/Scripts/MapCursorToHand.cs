using UnityEngine;
using System.Collections;

public class MapCursorToHand : MonoBehaviour {
	public GameObject handCursor;
	public SkeletonPointCursorXY skeletonPointCursorXY;
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
			newX = skeletonPointCursorXY.scaledNewX(-skeletonPointCursorXY.LeftHand.x/1000);
			newY = skeletonPointCursorXY.scaledNewY(skeletonPointCursorXY.LeftHand.y/1000);
			handCursor.transform.position= new Vector3(newX, newY, handZPosition);
		}
	}

}