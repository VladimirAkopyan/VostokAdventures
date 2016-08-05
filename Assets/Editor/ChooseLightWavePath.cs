// Copyright 2011 - NewTek, Inc. All rights reserved
// This file contains confidential and proprietary information of Newtek, Inc.
// and is subject to the terms of the LightWave EULA.

using UnityEngine;
using UnityEditor;
using System.Collections;

public class ChooseLightWavePath : MonoBehaviour {
	
	[MenuItem("LightWave/Choose LightWave Install Path")]
	static void DoSomething ()
	{
		LWSPostProcessor.query_and_write_lwsn_path ();
	}
}
