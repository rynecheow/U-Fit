/*****************************************************************************
*                                                                            *
*  Unity Wrapper                                                             *
*  Copyright (C) 2010 PrimeSense Ltd.                                        *
*                                                                            *
*  This file is part of OpenNI.                                              *
*                                                                            *
*  OpenNI is free software: you can redistribute it and/or modify            *
*  it under the terms of the GNU Lesser General Public License as published  *
*  by the Free Software Foundation, either version 3 of the License, or      *
*  (at your option) any later version.                                       *
*                                                                            *
*  OpenNI is distributed in the hope that it will be useful,                 *
*  but WITHOUT ANY WARRANTY; without even the implied warranty of            *
*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the              *
*  GNU Lesser General Public License for more details.                       *
*                                                                            *
*  You should have received a copy of the GNU Lesser General Public License  *
*  along with OpenNI. If not, see <http://www.gnu.org/licenses/>.            *
*                                                                            *
*****************************************************************************/
//Author: Shlomo Zippel

using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Threading;

public class NiteManager
{
	public enum SkeletonJoint
	{ 
		NONE = 0,
		HEAD = 1,
        NECK = 2,
        TORSO_CENTER = 3,
		WAIST = 4,

		LEFT_COLLAR = 5,
		LEFT_SHOULDER = 6,
        LEFT_ELBOW = 7,
        LEFT_WRIST = 8,
        LEFT_HAND = 9,
        LEFT_FINGERTIP = 10,

        RIGHT_COLLAR = 11,
		RIGHT_SHOULDER = 12,
		RIGHT_ELBOW = 13,
		RIGHT_WRIST = 14,
		RIGHT_HAND = 15,
        RIGHT_FINGERTIP = 16,

        LEFT_HIP = 17,
        LEFT_KNEE = 18,
        LEFT_ANKLE = 19,
        LEFT_FOOT = 20,

        RIGHT_HIP = 21,
		RIGHT_KNEE = 22,
        RIGHT_ANKLE = 23,
		RIGHT_FOOT = 24,

		END 
	};
	
	public enum BodySlice
	{
		LEFT_ARM_UPPER_1 = 0,
		LEFT_ARM_UPPER_2 = 1,
		LEFT_ARM_UPPER_3 = 2,
		
		LEFT_ARM_LOWER_1 = 3,
		LEFT_ARM_LOWER_2 = 4,
		LEFT_ARM_LOWER_3 = 5,
		
		RIGHT_ARM_UPPER_1 = 6,
		RIGHT_ARM_UPPER_2 = 7,
		RIGHT_ARM_UPPER_3 = 8,
		
		RIGHT_ARM_LOWER_1 = 9,
		RIGHT_ARM_LOWER_2 = 10,
		RIGHT_ARM_LOWER_3 = 11,
		
		TORSO_1 = 12,
		TORSO_2 = 13,
		TORSO_3 = 14,
		TORSO_4 = 15,
		
		END
	}

    [StructLayout(LayoutKind.Sequential)]
    public struct SkeletonJointPosition
    {
        public float x, y, z;
        public float confidence;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SkeletonJointOrientation
    {
        public float    m00, m01, m02,
                        m10, m11, m12,
                        m20, m21, m22;
        public float confidence;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SkeletonJointTransformation
    {
        public SkeletonJointPosition pos;
        public SkeletonJointOrientation ori;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XnVector3D
    {
        public float x, y, z;
    }

	[DllImport("UnityInterface.dll")]
	public static extern uint Init(StringBuilder strXmlPath);
	[DllImport("UnityInterface.dll")]
	public static extern void Update(bool async);
	[DllImport("UnityInterface.dll")]
	public static extern void Shutdown();
	
	[DllImport("UnityInterface.dll")]
	public static extern IntPtr GetStatusString(uint rc);
	[DllImport("UnityInterface.dll")]
	public static extern int GetDepthWidth();
	[DllImport("UnityInterface.dll")]
	public static extern int GetDepthHeight();
	[DllImport("UnityInterface.dll")]
	public static extern IntPtr GetUsersLabelMap();
    [DllImport("UnityInterface.dll")]
    public static extern IntPtr GetUsersDepthMap();
	[DllImport("UnityInterface.dll")]
    public static extern IntPtr getRGB();
    [DllImport("UnityInterface.dll")]
    public static extern int getRGBWidth();
    [DllImport("UnityInterface.dll")]
    public static extern int getRGBHeight();
    [DllImport("UnityInterface.dll")]
	public static extern IntPtr getFatness(int player, int type,ref int size, ref int length); //
	
	[DllImport("UnityInterface.dll")]
    public static extern void SetSkeletonSmoothing(double factor);
    [DllImport("UnityInterface.dll")]
    public static extern bool GetJointTransformation(uint userID, SkeletonJoint joint, ref SkeletonJointTransformation pTransformation);

    [DllImport("UnityInterface.dll")]
    public static extern void StartLookingForUsers(IntPtr NewUser, IntPtr CalibrationStarted, IntPtr CalibrationFailed, IntPtr CalibrationSuccess, IntPtr UserLost);
    [DllImport("UnityInterface.dll")]
    public static extern void StopLookingForUsers();
    [DllImport("UnityInterface.dll")]
    public static extern void LoseUsers();
    [DllImport("UnityInterface.dll")]
    public static extern bool GetUserCenterOfMass(uint userID, ref XnVector3D pCenterOfMass);
    [DllImport("UnityInterface.dll")]
    public static extern float GetUserPausePoseProgress(uint userID);

    public delegate void UserDelegate(uint userId);

    public static void StartLookingForUsers(UserDelegate NewUser, UserDelegate CalibrationStarted, UserDelegate CalibrationFailed, UserDelegate CalibrationSuccess, UserDelegate UserLost)
    {
        StartLookingForUsers(
            Marshal.GetFunctionPointerForDelegate(NewUser),
            Marshal.GetFunctionPointerForDelegate(CalibrationStarted),
            Marshal.GetFunctionPointerForDelegate(CalibrationFailed),
            Marshal.GetFunctionPointerForDelegate(CalibrationSuccess),
            Marshal.GetFunctionPointerForDelegate(UserLost));
    }
}

/* NiteGUI
 * Displays the depthmap during callibration and shows the callibration prompts
 */
public class NiteGUI {
	
	private NiteController niteController;
//	public CLNUIDevice kinectDevice;

	Texture2D usersLblTex;
    Color[] usersMapColors;
    Rect usersMapRect;
    int usersMapSize;
    short[] usersLabelMap;
    short[] usersDepthMap;
    float[] usersHistogramMap;
	
	int RGBwidth, RGBheight;
	short [] image;
	Texture2D usersImageTex;
	Color [] usersImageColors;
	Rect usersImageRect;
		
	GUITexture bg;		
	Thread depth_Thread;
	Thread image_Thread;
//	short startAngle;
	
	public NiteGUI(NiteController niteController) {	
		depth_Thread = new Thread(new ThreadStart(this.updateusermap));
		image_Thread = new Thread(new ThreadStart(this.updatergbimage));
		depth_Thread.Start();	
		image_Thread.Start();	
		this.niteController = niteController;
		
//		// Setting the Kinect in certain angle
//		this.startAngle = 2000;
//		this.kinectDevice = new CLNUIDevice(startAngle);
//		
		
		// Init depth & label map related stuff
        usersMapSize = NiteManager.GetDepthWidth() * NiteManager.GetDepthHeight();
        usersLblTex = new Texture2D(NiteManager.GetDepthWidth(), NiteManager.GetDepthHeight());
        usersMapColors = new Color[usersMapSize];
        usersMapRect = new Rect(Screen.width - usersLblTex.width / 2, Screen.height - usersLblTex.height / 2, usersLblTex.width / 2, usersLblTex.height / 2);
        usersLabelMap = new short[usersMapSize];
        usersDepthMap = new short[usersMapSize];
        usersHistogramMap = new float[5000];
		
		// Init camera image stuff
		RGBwidth = NiteManager.getRGBWidth();
		RGBheight = NiteManager.getRGBHeight();
		image = new short[RGBwidth*RGBheight*3];
		usersImageTex = new Texture2D(RGBwidth, RGBheight);
		usersImageColors = new Color[usersMapSize];
		usersImageRect = new Rect(Screen.width - usersImageTex.width / 2, Screen.height - usersImageTex.height / 2, usersImageTex.width / 2, usersImageTex.height / 2);
		
		bg = GameObject.Find("Background Image").GetComponent<GUITexture>();	
	}
	
	private void updateusermap() {	
		while(true) 
		{
			depth_Thread.Suspend();
			if(!niteController.kinectConnect){
				continue;
			}
			
			// copy over the maps
	        Marshal.Copy(NiteManager.GetUsersLabelMap(), usersLabelMap, 0, usersMapSize);
	        Marshal.Copy(NiteManager.GetUsersDepthMap(), usersDepthMap, 0, usersMapSize);
	
	        // we will be flipping the texture as we convert label map to color array
	        int flipIndex, i;
	        int numOfPoints = 0;
			Array.Clear(usersHistogramMap, 0, usersHistogramMap.Length);
	
	        // calculate cumulative histogram for depth
	        for (i = 0; i < usersMapSize; i++)
	        {
	            // only calculate for depth that contains users
	            if (usersLabelMap[i] != 0)
	            {
	                usersHistogramMap[usersDepthMap[i]]++;
	                numOfPoints++;
	            }
	        }
	        if (numOfPoints > 0)
	        {
	            for (i = 1; i < usersHistogramMap.Length; i++)
		        {   
			        usersHistogramMap[i] += usersHistogramMap[i-1];
		        }
	            for (i = 0; i < usersHistogramMap.Length; i++)
		        {
	                usersHistogramMap[i] = 1.0f - (usersHistogramMap[i] / numOfPoints);
		        }
	        }
	
	        // create the actual users texture based on label map and depth histogram
	        for (i = 0; i < usersMapSize; i++)
	        {
	            flipIndex = usersMapSize - i - 1;
	            if (usersLabelMap[i] == 0)
	            {
	                usersMapColors[flipIndex] = Color.clear;
	            }
	            else
	            {
	                // create a blending color based on the depth histogram
	                Color c = new Color(usersHistogramMap[usersDepthMap[i]], usersHistogramMap[usersDepthMap[i]], usersHistogramMap[usersDepthMap[i]], 0.9f);
	                switch (usersLabelMap[i] % 4)
	                {
	                    case 0:
	                        usersMapColors[flipIndex] = Color.red * c;
	                        break;
	                    case 1:
	                        usersMapColors[flipIndex] = Color.green * c;
	                        break;
	                    case 2:
	                        usersMapColors[flipIndex] = Color.blue * c;
	                        break;
	                    case 3:
	                        usersMapColors[flipIndex] = Color.magenta * c;
	                        break;
	                }
	            }
	        }		
		}
	}
	
	public void UpdateUserMap() {	
		depth_Thread.Resume();

        usersLblTex.SetPixels(usersMapColors);
        usersLblTex.Apply();
	}
	
	public void updatergbimage() {
		while(true) 
		{
			image_Thread.Suspend();
			Marshal.Copy(NiteManager.getRGB(), image, 0, RGBwidth*RGBheight*3);
			int p = 0;
			int flipIndex;
			
			int usersMapSize = 640*480;		  
			
			for (int i = 0; i < usersMapSize; i++) {
				flipIndex = usersMapSize - i - 1;
				Color c = new Color((float)image[p++]/255f,(float)image[p++]/255f,(float)image[p++]/255f);
				usersImageColors[flipIndex] = c;
	        }
		}
	}
	
	public void UpdateRgbImage() {
		if (image_Thread.ThreadState == ThreadState.Suspended) {
			image_Thread.Resume();
		}
//		Thread oThread = new Thread(new ThreadStart(this.updatergbimage));
//		oThread.Start();
		
		usersImageTex.SetPixels(usersImageColors);
        usersImageTex.Apply();
		bg.texture = usersImageTex;
	}
	
	public void DrawUserMap() {
		GUI.DrawTexture(usersMapRect, usersLblTex);
	}
	
	public void DrawCameraImage() {
		GUI.DrawTexture(usersImageRect, usersImageTex);
	}
}

/* NiteController
 * A single user controller which takes care of the callbacks and
 * calibration.
 * Adapted from Nite.cs which came with the UnityWrapper example project
 */
public class NiteController {
	
	//Is Kinect initialized and user calibrated?
	public bool kinectConnect = false;
	public bool calibratedUser = false;
	
	//The bodyslice depth maps and realworld diameter (in m)
	public int[][] sizeData = new int[16][];
	public float[] diameter = new float[16];
	
	//Id of calibrated user, nonsense if calibratedUser is false
	private uint calibratedUserId;
	
	//GUI for calibration process
	private NiteGUI gui;
	
	//Confidence threshold for returning joint pos/ori (a.t.m. Nite seems to only use 0 and 1)
	public float confidenceThreshold = 0.5F;
	
	//Nite callback functions
	private NiteManager.UserDelegate NewUser;
    private NiteManager.UserDelegate CalibrationStarted;
    private NiteManager.UserDelegate CalibrationFailed;
    private NiteManager.UserDelegate CalibrationSuccess;
    private NiteManager.UserDelegate UserLost;
	
	Thread scan_Thread;
	
	//Callback for when a new user has been calibrated
	public delegate void NewUserCallback();
	private NewUserCallback onNewUser;

	public NiteController(NewUserCallback onNewUser) {
		// initialize the Kinect	
		uint rc = NiteManager.Init(new StringBuilder(".\\OpenNI.xml"));
        if (rc != 0)
        {
            Debug.Log(String.Format("Error initializing OpenNI: {0}", Marshal.PtrToStringAnsi(NiteManager.GetStatusString(rc))));
			return;
        }
		else kinectConnect = true;
		
		// init user callbacks
        NewUser = new NiteManager.UserDelegate(OnNewUser);
        CalibrationStarted = new NiteManager.UserDelegate(OnCalibrationStarted);
        CalibrationFailed = new NiteManager.UserDelegate(OnCalibrationFailed);
        CalibrationSuccess = new NiteManager.UserDelegate(OnCalibrationSuccess);
        UserLost = new NiteManager.UserDelegate(OnUserLost);

        // Start looking	
		NiteManager.StartLookingForUsers(NewUser, CalibrationStarted, CalibrationFailed, CalibrationSuccess, UserLost);
		Debug.Log("Waiting for users to calibrate");
		
		// set default smoothing
		NiteManager.SetSkeletonSmoothing(0.0);
		
		// set new user callback
		this.onNewUser = onNewUser;
		
		// initialize gui
		gui = new NiteGUI(this);
	}
	
	void OnNewUser(uint UserId)
    {
        Debug.Log(String.Format("[{0}] New user", UserId));
    }   

    void OnCalibrationStarted(uint UserId)
    {
		Debug.Log(String.Format("[{0}] Calibration started", UserId));
    }

    void OnCalibrationFailed(uint UserId)
    {
        Debug.Log(String.Format("[{0}] Calibration failed", UserId));
    }

    void OnCalibrationSuccess(uint UserId)
    {
        Debug.Log(String.Format("[{0}] Calibration success", UserId));
		calibratedUser = true;
		calibratedUserId = UserId;
		
		//Rotate Kinect so center of mass is in the middle		
		//CLNUIDevice device = gui.kinectDevice;
		//device.RotateToCenter(UserId);
		
		Debug.Log("Stopping to look for users");
		NiteManager.StopLookingForUsers();
				
		int size = 0;	
		int length = 0;
		
		for (int i = 0; i < 16; i++) {
			IntPtr raw_data = NiteManager.getFatness((int)UserId,i, ref size, ref length);
			int[] data = new int[size];	
			Marshal.Copy(raw_data, data, 0, size);
			sizeData[i] = data;
			diameter[i] = (float)length/1000.0F; //convert from mm to m
		}
		
		this.onNewUser();
    }

    void OnUserLost(uint UserId)
    {
        Debug.Log(String.Format("[{0}] User lost", UserId));
		calibratedUser = false;
		
		Debug.Log("Starting to look for users");
		NiteManager.StartLookingForUsers(NewUser, CalibrationStarted, CalibrationFailed, CalibrationSuccess, UserLost);
    }
	
	public bool GetJointOrientation(NiteManager.SkeletonJoint joint, out Quaternion rotation) {
		if (kinectConnect && calibratedUser) {
			NiteManager.SkeletonJointTransformation trans = new NiteManager.SkeletonJointTransformation();
        	NiteManager.GetJointTransformation(calibratedUserId, joint, ref trans);
			
			// Z coordinate in OpenNI is opposite from Unity. We will create a quat
            // to rotate from OpenNI to Unity (relative to initial rotation)
            Vector3 worldZVec = new Vector3(trans.ori.m02, -trans.ori.m12, trans.ori.m22);
            Vector3 worldYVec = new Vector3(-trans.ori.m01, trans.ori.m11, -trans.ori.m21);
            rotation = Quaternion.LookRotation(worldZVec, worldYVec);
			return (trans.ori.confidence > confidenceThreshold);
		}
		else {
			rotation = Quaternion.identity;
			return false;
		}
	}
	
	public bool GetJointPosition(NiteManager.SkeletonJoint joint, out Vector3 position) {
		if (kinectConnect && calibratedUser) {
			NiteManager.SkeletonJointTransformation trans = new NiteManager.SkeletonJointTransformation();
        	NiteManager.GetJointTransformation(calibratedUserId, joint, ref trans);
			
			// Nite gives position in mm convert to Unity unit = meters
			// Also x and y world vectors are inverse from Unity
			position = new Vector3(-trans.pos.x/1000.0F, trans.pos.y/1000.0F, -trans.pos.z/1000.0F);
			return (trans.pos.confidence > confidenceThreshold);
		}
		else {
			position = new Vector3(0.0F, 0.0F, 0.0F);
			return false;
		}
	}
	
	public void Update() {
		NiteManager.Update(true);
		if (!calibratedUser) {
			//gui.UpdateUserMap();
		}
		gui.UpdateRgbImage();
	}
	
	public void UpdateGUI () {
		if (!calibratedUser) {
			//gui.DrawUserMap();
		}
		//gui.DrawCameraImage();
	}
}