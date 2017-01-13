using UnityEngine;
using System.Collections;

public class KeepSync : MonoBehaviour {
    public float distance = 0.1f;
    public GameObject m_camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void LateUpdate()
    {
        //rotation
        Vector3 forward = m_camera.transform.forward;
        Debug.DrawRay(transform.position, forward, Color.red);
        //Debug.Log(forward);
        forward.y = 0;
        Debug.DrawRay(transform.position, forward, Color.blue);
        transform.forward = forward;

        ////position
        //Vector3 eyePos = Camera.main.transform.localPosition - forward*distance;
        //transform.localPosition = eyePos - new Vector3(0.0f, 3.2f, 0.0f);
    }
}
