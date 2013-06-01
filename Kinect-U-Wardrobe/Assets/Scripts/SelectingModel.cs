using UnityEngine;
using System.Collections;

public class SelectingModel : MonoBehaviour {
	
	public GameObject model;
	public OpenNISkeleton skeleton;
	public static readonly string NECK = @"Neck";
	public static readonly string TORSO = @"Neck/Bone002/Torso";
	public static readonly string WAIST = @"Neck/Bone002/Torso/Waist";
	public static readonly string RSHOULDER = @"Neck/Bone003/Right Shoulder";
	public static readonly string RELBOW = @"Neck/Bone003/Right Shoulder/Bone005/Right Elbow";
	public static readonly string RWARIST = @"Neck/Bone003/Right Shoulder/Bone005/Right Elbow/Bone007/Right Warist";
	public static readonly string LSHOULDER = @"Neck/Bone008/Left Shoulder";
	public static readonly string LEBLOW = @"Neck/Bone008/Left Shoulder/Bone010/Left Elbow";
	public static readonly string LWARIST =  @"Neck/Bone008/Left Shoulder/Bone010/Left Elbow/Bone012/Left Warist";
	// Use this for initialization
	void Start () {
		model = (GameObject)Resources.Load("haha2");
		//model = GameObject.Find("haha2");
		Debug.Log(model.transform.Find("Neck/Bone002/Torso")+"aaaA");
		//Debug.Log("length is "+SkeletonController.staticSkeleton[0]);
		
//		skeleton = SkeletonController.staticSkeleton[0];
//		
//		skeleton.Torso = model.transform.Find(NECK);
//		skeleton.Waist = model.transform.Find(WAIST);
//		skeleton.RightShoulder = model.transform.Find(RSHOULDER);
//		skeleton.RightElbow = model.transform.Find(RELBOW);
//		skeleton.RightWrist = model.transform.Find(RWARIST);
//		skeleton.LeftShoulder = model.transform.Find(LSHOULDER);
//		skeleton.LeftElbow = model.transform.Find(LEBLOW);
//		skeleton.LeftWrist = model.transform.Find(LWARIST);
//		model.SetActive(true);

		Debug.Log(model.transform.Find("Object #0").renderer);
		Renderer abc = model.transform.Find("Object #0").renderer;
		this.renderer.material.mainTexture = abc.material.mainTexture;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static Renderer ToggleRenderers (GameObject goCleanUp, bool enabled)
	{
		foreach(Renderer rend in goCleanUp.GetComponentsInChildren<Renderer>())
		{
			return rend;
		}
		
		return null;
	}
}
