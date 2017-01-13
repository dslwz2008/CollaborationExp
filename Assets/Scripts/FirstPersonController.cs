using UnityEngine;
using System.Collections;

public class FirstPersonController : Photon.PunBehaviour {
    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine)
        {
            CharacterController controller = GetComponent<CharacterController>();
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.position += transform.forward * h * Time.deltaTime;
            transform.position -= transform.right * v * Time.deltaTime;
        }
    }
    
}
