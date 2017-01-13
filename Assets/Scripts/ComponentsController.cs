using UnityEngine;
using System.Collections;

public class ComponentsController : Photon.PunBehaviour {
	// Use this for initialization
	void Start () {
        if (!photonView.isMine)
        {
            foreach (Transform child in transform)
            {
                if(child.name.Equals("sport"))
                {
                    child.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                    child.GetComponent<KeepSync>().enabled = false;
                }
                else if(child.name.Equals("MainCamera"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
