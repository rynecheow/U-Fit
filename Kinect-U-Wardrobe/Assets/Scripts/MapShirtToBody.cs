using UnityEngine;
using System.Collections;

public class MapShirtToBody : MonoBehaviour {
	public GameObject shirt;
	public Vector3 shirtPosition;
	public SkeletonPointClass skeletonPontClass;
	
	// Use this for initialization
	void Start () {
		shirtPosition = shirt.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(skeletonPontClass.Neck/1000);
		shirt.transform.position = new Vector3(shirtPosition.x, skeletonPontClass.Neck/1000, 2.3f);
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (Screen.width/2 - 150, Screen.height/2 - 150, 500, 500));
		GUILayout.Box("Test Neck " + (skeletonPontClass.Neck/100));
		GUILayout.EndArea();
	}
}