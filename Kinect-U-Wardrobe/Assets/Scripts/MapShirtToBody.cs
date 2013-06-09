using UnityEngine;
using System.Collections;

public class MapShirtToBody : MonoBehaviour {
	public GameObject shirt;
	public DetectHover detectHover;
	public Vector3 shirtPosition;
	public SkeletonPointCursorXY skeletonPointCursorXY;
	public SkeletonController skeltonController;
	public GameObject[] availableShirt;
	public static readonly float shirtZPosition = 2.3f;
	public static readonly Vector3 originalPosition = new Vector3(0,0,-5);
	float newY = 0;
	
	// Use this for initialization
	void Start () {
		shirtPosition = shirt.transform.position;
		shirt = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		shirt = detectHover.choosedShirt;
		newY = skeletonPointCursorXY.scaledNewY(skeletonPointCursorXY.LeftShoulder.y/1000);
		
		if(skeltonController.IsTracking && detectHover.choosedShirt!=null)
		{
			for(int i =0; i<2; i++)
			{
				if(!shirt.name.Equals(availableShirt[i].name))
				{
					availableShirt[i].transform.position = originalPosition;
				}
				else
				{
					availableShirt[i].transform.position= new Vector3(shirtPosition.x, -1f + newY, shirtZPosition);
				}
			}

		}
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (Screen.width/3 + 200, Screen.height/2 - 400, 500, 500));
		GUILayout.Box("System Date : " + System.DateTime.Now);
		GUILayout.EndArea();

	}
	

}