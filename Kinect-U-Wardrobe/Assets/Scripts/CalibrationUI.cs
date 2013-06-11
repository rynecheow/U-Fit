using UnityEngine;
using System.Collections;

public class CalibrationUI : MonoBehaviour {
	public GameObject calibrationImage;
	public GameObject mainTitle;
	public SkeletonController skeletonController;
	public Vector3 mainTitlePosition;
	public Vector3 imagePosition;
	// Use this for initialization
	void Start () {
		mainTitlePosition  = mainTitle.transform.position;
		imagePosition  = calibrationImage.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(skeletonController.IsTracking)
		{
			mainTitle.transform.position = mainTitlePosition;
			calibrationImage.transform.position = imagePosition;
		}
		else
		{
			calibrationImage.transform.position = new Vector3(0.1402053f,2.698014f,4.213649f);
			mainTitle.transform.position = new Vector3(0f,0.7161173f,-7.608501f);
		}
	}
	
}
