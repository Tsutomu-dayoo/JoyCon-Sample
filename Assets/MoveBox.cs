using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour {

    private List<Joycon> joycons;
    private Joycon joyconL;
    private Joycon joyconR;

    public GameObject redcube;
    public GameObject bluecube;

    public Vector3 gyro;
    public Vector3 accel;
    public Quaternion orientation_L;
    public Quaternion orientation_R;

	// Use this for initialization
	void Start () {
        redcube = GameObject.Find("RedCube");
        bluecube = GameObject.Find("BlueCube");
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);

        joycons = JoyconManager.Instance.j;

        if (joycons == null || joycons.Count <= 0) return;

        joyconL = joycons.Find(c => c.isLeft);
        joyconR = joycons.Find(c => !c.isLeft);
		
	}
	
	// Update is called once per frame
	void Update () {

        bluecube.transform.rotation = new Quaternion(joyconL.GetVector().x,joyconL.GetVector().z,joyconL.GetVector().y,-joyconL.GetVector().w);
        redcube.transform.rotation = new Quaternion(joyconR.GetVector().x,joyconR.GetVector().z,joyconR.GetVector().y,-joyconR.GetVector().w);;

		
	}
}
