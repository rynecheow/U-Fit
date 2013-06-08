using UnityEngine;
using System.Collections;
using OpenNI;

public class SkeletonPointClassY : MonoBehaviour 
{
	
	public float Head;
	public float Neck;
	public float Torso;
	public float Waist;

	public float LeftShoulder;
	public float LeftElbow;
	public float LeftWrist;

	public float RightShoulder;
	public float RightElbow;
	public float RightWrist;

	public float LeftHip;
	public float LeftKnee;
	public float LeftAnkle;
	public float LeftHand;

	public float RightHip;
	public float RightKnee;
	public float RightAnkle;
	public float RightHand;
	
	private OpenNISkeleton tempSkeleton;
	//private bool isCalibrated;
	// Use this for initialization
	void Start () {
		//  	isCalibrated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(SkeletonController.staticSkeleton!=null)
		{
			tempSkeleton = SkeletonController.staticSkeleton[0];
			
			Head = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Head).Y;
			
			Neck = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Neck).Y;
			Torso = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Torso).Y;
			Waist = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Waist).Y; 
		
			LeftShoulder = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftShoulder).Y;
			LeftElbow = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftElbow).Y;
			LeftWrist = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftWrist).Y;
			LeftHand = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftHand).Y;
			
			RightShoulder = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightShoulder).Y;
			RightElbow = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightElbow).Y;
			RightWrist = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightWrist).Y;
			RightHand = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightHand).Y;
			
			LeftHip = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftHip).Y;
			LeftKnee = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftKnee).Y;
			LeftAnkle = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftAnkle).Y;
			
			RightHip = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightHip).Y;
			RightKnee = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightKnee).Y;
			RightAnkle = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightAnkle).Y;
			
			//isCalibrated = true;
		}	
	}
	
	public float scaledNewY(float kinectY)
	{
		return (float)(kinectY * Screen.height) / 480;
	}
	
	
}
