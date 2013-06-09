using UnityEngine;
using System.Collections;
using OpenNI;

public class SkeletonPointCursorXY: MonoBehaviour 
{
	
	public Vector2 Head;
	public Vector2 Neck;
	public Vector2 Torso;
	public Vector2 Waist;

	public Vector2 LeftShoulder;
	public Vector2 LeftElbow;
	public Vector2 LeftWrist;

	public Vector2 RightShoulder;
	public Vector2 RightElbow;
	public Vector2 RightWrist;

	public Vector2 LeftHip;
	public Vector2 LeftKnee;
	public Vector2 LeftAnkle;
	public Vector2 LeftHand;

	public Vector2 RightHip;
	public Vector2 RightKnee;
	public Vector2 RightAnkle;
	public Vector2 RightHand;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if(SkeletonController.staticSkeleton!=null)
		{
			OpenNISkeleton tempSkeleton = SkeletonController.staticSkeleton;
			
			Head = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Head));
			
			Neck = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Neck));
			Torso = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Torso));
			Waist = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.Waist)); 
		
			LeftShoulder = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftShoulder));
			LeftElbow = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftElbow));
			LeftWrist = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftWrist));
			LeftHand = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftHand));
				
			RightShoulder = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightShoulder));
			RightElbow = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightElbow));
			RightWrist = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightWrist));
			RightHand = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightHand));
			
			LeftHip = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftHip));
			LeftKnee = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftKnee));
			LeftAnkle = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.LeftAnkle));
		
			RightHip = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightHip));
			RightKnee = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightKnee));
			RightAnkle = getXYPosition(tempSkeleton.GetJointRealWorldPosition(SkeletonJoint.RightAnkle));
					
		}
	}
	
	public float scaledNewX(float kinectX)
	{
		return (float)(kinectX * Screen.width) / 640;
	}
	
	public float scaledNewY(float kinectY)
	{
		return (float)(kinectY * Screen.width) / 640;
	}
	
	private Vector2 getXYPosition(Point3D point3D)
	{
		return new Vector2(point3D.X,point3D.Y);
	}
	
}
