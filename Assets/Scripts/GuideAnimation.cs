using UnityEngine;
using System.Collections;
using System;

public class GuideAnimation : MonoBehaviour {

    // Use this for initialization
    Material tipMaterial;
    float yOffset = 10;
    DateTime lastTime;
    DateTime currentTime;
    void Start()
    {
        MeshRenderer tipRender = GetComponent<MeshRenderer>();
        //Debug.Log(tipRender);
        Material[] ms = tipRender.materials;
        //Debug.Log("ms length is :" + ms.Length);
        tipMaterial = ms[0];
        //Debug.Log("ms h is :" + tipMaterial.name);
        yOffset = 1;
        currentTime = DateTime.Now;
        lastTime = currentTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        if (currentTime.Subtract(lastTime).TotalMilliseconds >= 1000)
        {
            yOffset -= 0.1f;
            if (yOffset <= 0) yOffset = 10;
            tipMaterial.SetTextureOffset("_MainTex", new Vector2(0.0f, yOffset));
            lastTime = currentTime;
        }
    }
}
