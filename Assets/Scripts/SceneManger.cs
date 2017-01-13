using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class SceneManger : Photon.PunBehaviour {
    public GameObject playerPrefab;
    private string m_gameVersion = "1";
    public ShowMenu[] showMenus;
    public PlayMovie[] playMovies;

    void Awake()
    {
        PhotonNetwork.logLevel = PhotonLogLevel.Informational;
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;
    }

	// Use this for initialization
	void Start () {
        Connect();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Connect()
    {
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.JoinRandomRoom();
        }else
        {
            PhotonNetwork.ConnectUsingSettings(m_gameVersion);
        }
    }

    public override void OnConnectedToPhoton()
    {
        Debug.Log("Connect to Photon!");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master ! ");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnectedFromPhoton()
    {
        Debug.Log("Disconnect from Photon!");
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = 4 }, null);
        Debug.Log("Create a room!");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() called by PUN: " + PhotonNetwork.room.name + 
            " Current Player Count: " + PhotonNetwork.room.playerCount);
        Vector3 spawnPos = new Vector3(0.0f, 0.0f, 20.11f);
        if(PhotonNetwork.room.playerCount == 1)
        {
            spawnPos += new Vector3(2f, 0.0f, 1.0f);
        }else if (PhotonNetwork.room.playerCount == 2)
        {
            spawnPos += new Vector3(3f, 0.0f, 2.0f);
        }
        GameObject goPalyer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPos,
            Quaternion.Euler(0, 0, 0), 0);
        SelectionRadial radial = Camera.main.gameObject.GetComponent<SelectionRadial>();

        //处理引用关系
        foreach (var menu in showMenus)
        {
            menu.selectionRadial = radial;
            radial.OnSelectionComplete += menu.SelectionComplete;
        }
        
        foreach (var playMovie in playMovies)
        {
            playMovie.selectionRadial = radial;
            radial.OnSelectionComplete += playMovie.SelectionComplete;
        }
    }
}
