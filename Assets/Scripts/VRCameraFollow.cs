using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;

public class VRCameraFollow : MonoBehaviour {
    GameObject person = null;
    bool initialized = false;
    public float cameraOffsetX = 0.0f;
    public float cameraOffsetY = 1.2f;
    public float cameraOffsetZ = 0.0f;
    public GameObject cameraRig;

	// Use this for initialization
	void Start () {
	}

    void InitialFinished(int peopleCount)
    {
        int personId = 1;
        string instanceName = "people" + personId.ToString();
        person = GameObject.Find("/Instances/" + instanceName);
        initialized = true;
    }

    void LateUpdate()
    {
        if (!initialized)
        { return; }
        cameraRig.transform.position = person.transform.position +
            new Vector3(cameraOffsetX, cameraOffsetY, cameraOffsetZ);
    }

}
