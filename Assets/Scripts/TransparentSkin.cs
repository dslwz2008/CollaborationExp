using UnityEngine;
using System.Collections;

public class TransparentSkin : MonoBehaviour {
    public MeshRenderer mesh;
    public float alpha = 0.5f;

    // Use this for initialization
    void Start () {
        if (mesh != null)
        {
            Material[] mats = mesh.sharedMaterials;
            foreach (Material m in mats)
            {
                if (m.shader.name == "Transparent/CustomTransparent")
                {
                    m.SetFloat("_Cutoff", alpha);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
