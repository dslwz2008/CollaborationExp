using UnityEngine;
using System.Collections;
using System;

public class ColorSync : Photon.PunBehaviour
{
    private MeshRenderer render;
    private Vector3 tempColor;
    // Use this for initialization
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Color不能作为参数传递，因为Color类型不能序列化
    [PunRPC]
    void ColorRed()
    {
        Debug.Log("red");
        render.material.SetColor("_Color", Color.red);
    }
    [PunRPC]
    void ColorYellow()
    {
        Debug.Log("yellow");
        render.material.SetColor("_Color", Color.yellow);
    }
    [PunRPC]
    void ColorGreen()
    {
        Debug.Log("green");
        render.material.SetColor("_Color", Color.green);
    }

    public void ChangeColor(Color color)
    {
        PhotonView photonView = PhotonView.Get(this);
        if (color == Color.red)
        {
            photonView.RPC("ColorRed", PhotonTargets.AllBuffered);
        }else if(color == Color.yellow)
        {
            photonView.RPC("ColorYellow", PhotonTargets.AllBuffered);
        }else if(color == Color.green)
        {
            photonView.RPC("ColorGreen", PhotonTargets.AllBuffered);
        }
    }

    //void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    Debug.Log("-----------------------------");
    //    if (stream.isWriting)
    //    {
    //        //send color
    //        tempColor = new Vector3(render.material.color.r,
    //            render.material.color.g,
    //            render.material.color.b);
    //        stream.Serialize(ref tempColor);
    //    }
    //    else
    //    {
    //        //get color
    //        stream.Serialize(ref tempColor);
    //        render.material.color = new Color(tempColor.x, tempColor.y, tempColor.z, 1.0f);
    //    }
    //}
}