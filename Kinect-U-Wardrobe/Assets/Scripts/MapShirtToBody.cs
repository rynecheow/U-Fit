using UnityEngine;
using System.Collections;

public class MapShirtToBody : MonoBehaviour {
	public GameObject shirt;
	public Vector3 shirtPosition;
	public SkeletonPointClass skeletonPontClass;
	public SkeletonController skeltonController;
	public static readonly float shirtZPosition = 2.3f;
	public GameObject cube;
	private float shirtYPosition;
	float newY = 0;
	
	// Use this for initialization
	void Start () {
		shirtPosition = shirt.transform.position;
		shirtYPosition = shirt.transform.Find("Neck").position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//cube.transform.position = new Vector3(cube.transform.position.x , skeletonPontClass.LeftShoulder/100, cube.transform.position.z);
		
		if(skeltonController.IsTracking)
		{
			Debug.Log("Left Shoulder" +skeletonPontClass.LeftShoulder/1000);
			shirt.transform.position= new Vector3(shirtPosition.x, -0.8f + newY, shirtZPosition);
		}
	}
	
	void OnGUI()
	{
		newY = scaledNewY(skeletonPontClass.LeftShoulder/1000);
//		GUILayout.BeginArea (new Rect (Screen.width/2 - 150, Screen.height/2 - 150, 500, 500));
//		GUILayout.Box("Test Neck " + (skeletonPontClass.Neck/1000));
//		GUILayout.Box("Test left shoudlder " + (skeletonPontClass.LeftShoulder/1000));
//		GUILayout.Box("Test right shoulder " + (skeletonPontClass.RightShoulder/1000));
//		GUILayout.Box("Test torso " + (skeletonPontClass.Torso/1000));
//		GUILayout.Box("Test waist " + (skeletonPontClass.Waist/1000));
//		GUILayout.Box("Test head " + (skeletonPontClass.Head/1000));
//		GUILayout.Box("KinectY " + newY);
		GUILayout.EndArea();
	}
	
	float scaledNewX(float kinectX)
	{
		return (float)(kinectX * 1280) / Screen.width;
	}
	
	float scaledNewY(float kinectY)
	{
		return (float)(kinectY * 960) / Screen.height;
	}
}