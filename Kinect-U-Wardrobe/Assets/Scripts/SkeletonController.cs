using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using OpenNI;

public class SkeletonController : MonoBehaviour {

   #region Variable declaration
   	public static OpenNISkeleton STATIC_SKELETON;
   	public static int USER_ID;
   	public static float TIME;
	public OpenNIUserTracker UserTracker;
	public OpenNISkeleton[] Skeletons;
	public static  bool  IS_FIRST_RUN   = true;
	private  bool  outOfFrame       ;
	

	public bool IsTracking{
		get {
			return USER_ID!=0;
		}
	}
   #endregion
   // Use this for initialization
   #region MonoBehavior
   void Start(){
      if (!UserTracker) {
         UserTracker = GetComponent<OpenNIUserTracker>();
      }

      if (!UserTracker) {
         UserTracker = GameObject.FindObjectOfType(typeof(OpenNIUserTracker)) as OpenNIUserTracker;
      }

      if (!UserTracker) {
         Debug.LogWarning("Missing a User Tracker. Adding...");
         UserTracker = gameObject.AddComponent<OpenNIUserTracker>();
      }
		
      if (UserTracker.MaxCalibratedUsers < 1) {
         UserTracker.MaxCalibratedUsers = 1;
      }
		
		STATIC_SKELETON = null;
		
   }
	
   // Update is called once per frame
   void Update (){
      // do we have a valid calibrated user?
      if (IsTracking){
         // is the user still valid?
         if (!UserTracker.CalibratedUsers.Contains(USER_ID)){
            USER_ID = 0;
            foreach (OpenNISkeleton skel in Skeletons){
               skel.RotateToCalibrationPose();
            }
         }
      }
		
      // look for a new userId if we dont have one
      if (!IsTracking){
         // just take the first calibrated user
         if (UserTracker.CalibratedUsers.Count > 0){
            USER_ID = UserTracker.CalibratedUsers[0];
            outOfFrame = false;
         }
      }
		
      // we have a valid userId, lets use it for something!
      if (IsTracking){
         // see if user is out o'frame
         Vector3 com = UserTracker.GetUserCenterOfMass(USER_ID);
         if (outOfFrame != (com == Vector3.zero)){
            outOfFrame = (com == Vector3.zero);
            SendMessage("UserOutOfFrame", outOfFrame, SendMessageOptions.DontRequireReceiver);
         }
			
         // update our skeleton based on active user id	
         foreach (OpenNISkeleton skel in Skeletons){
            UserTracker.UpdateSkeleton(USER_ID, skel);
         }	

         // Always update skeleton points
         STATIC_SKELETON = Skeletons[0];
			
         if(IS_FIRST_RUN){        // Only calibrate once
            TIME = Time.time;
            IS_FIRST_RUN = false;
         }
      }
   }
	
   void OnGUI(){
      if (IsTracking){        // Calibrated
         GUILayout.BeginVertical("box");
         GUILayout.Label(string.Format("Calibrated: {0}", USER_ID));
         GUILayout.Label(string.Format("Out of frame: {0}", (outOfFrame) ? "TRUE" : "FALSE"));
         GUILayout.EndVertical();
      }
   }
	#endregion
}
