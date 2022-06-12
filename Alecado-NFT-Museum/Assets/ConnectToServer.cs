using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.SceneManagement;

public class ConnectToServer : Photon.PunBehaviour
{

    public string str;
    public string loadScene;
    bool retry = false;

    RoomOptions roomOptions;

    // Start is called before the first frame update
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "SelectScene")
        {
            Debug.Log("in start");
            roomOptions = new RoomOptions() { IsVisible = true, MaxPlayers = 20 };
            PhotonNetwork.ConnectUsingSettings(str);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void EnterMuseum()
    {
        CreateOrJoinRoom("MuseumR1");
        //JoinRoom("MuseumR1");
        StartCoroutine("LoadM");
        //PhotonNetwork.LoadLevel("Scene1");
    }
    public void JoinMuseum()
    {
        JoinRoom("MuseumR1");
        //JoinRoom("MuseumR1");
        StartCoroutine("LoadM");
        //PhotonNetwork.LoadLevel("Scene1");
    }
    public void CreateRoom(string roomname)
    {
        PhotonNetwork.CreateRoom(roomname);
        Debug.Log("Create room called");
    }
    public void JoinRoom(string roomname)
    {
        PhotonNetwork.JoinRoom(roomname );
        Debug.Log("join room called");
    }

    public void ChangeScene(string scenename)
    {
        PhotonNetwork.LoadLevel(scenename);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to Master");
        if (retry)
        {
            retry = false;
            EnterMuseum();
        }
    }
    public void CreateOrJoinRoom(string roomName)
    {
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        Debug.Log("Create Or Join Room");
    }

    public override void OnJoinedLobby()
    {
        //SceneManager.LoadScene(loadScene);
        Debug.Log("Joined Lobby");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created");
    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        Debug.Log("Join room fail" + codeAndMsg);
       
    }

    public override void OnDisconnectedFromPhoton()
    {
        retry = true;
        PhotonNetwork.LoadLevel("SelectScene");

    }

    public override void OnJoinedRoom()
    {
        //SceneManager.LoadScene(loadScene);
        Debug.Log("Connected Room: " );
    }

    IEnumerator LoadM()
    {
        yield return new WaitForSeconds(3f);
        PhotonNetwork.LoadLevel("Scene1");
    }

}
