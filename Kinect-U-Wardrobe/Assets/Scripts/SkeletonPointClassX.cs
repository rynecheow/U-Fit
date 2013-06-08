using UnityEngine;
using System.Collections;
using OpenNI;

public class SkeletonPointClassX: MonoBehaviour 
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
			
			Head = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Head).X;
			
			Neck = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Neck).X;
			Torso = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Torso).X;
			Waist = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Waist).X; 
		
			LeftShoulder = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftShoulder).X;
			LeftElbow = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftElbow).X;
			LeftWrist = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftWrist).X;
			LeftHand = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftHand).X;
				
			RightShoulder = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightShoulder).X;
			RightElbow = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightElbow).X;
			RightWrist = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightWrist).X;
			RightHand = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightHand).X;
			
			LeftHip = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftHip).X;
			LeftKnee = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftKnee).X;
			LeftAnkle = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftAnkle).X;
		
			RightHip = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightHip).X;
			RightKnee = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightKnee).X;
			RightAnkle = tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightAnkle).X;
			
			//isCalibrated = true;
		}	
	}
	
	public float scaledNewX(float kinectX)
	{
		return (float)(kinectX * Screen.width) / 640;
	}
	
}
