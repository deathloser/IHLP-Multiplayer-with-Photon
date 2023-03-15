using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;


namespace Photon.Pun.Demo.Basics {
public class GameManager : MonoBehaviourPunCallbacks
{
    public Text display;

    public GameObject playerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        if(playerPrefab==null) {
            Debug.Log("null reference for player prefab");
        }
        else {
            //instantiate player prefab

            if(PhotonNetwork.IsMasterClient) {
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(-5f,1f,1f),Quaternion.identity,0);

            } else {
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,1f,1f),Quaternion.identity,0);


            }

            
        }
        
    }

    void LoadArena() {

        if(!PhotonNetwork.IsMasterClient) {
            Debug.LogError("You are NOT the master client");
            

        } else {

            Debug.Log("You are the master client");
        }

        PhotonNetwork.LoadLevel(1);
        display.text = "Connected!";
        
    }

    public override void OnPlayerEnteredRoom(Player other) {
        //remote player joined
        Debug.LogFormat("Remote player joined!");

        if(PhotonNetwork.IsMasterClient) {
            Debug.Log("and you are the master client");

            //NOW we load the level
            LoadArena();

            display.text = "Connected!";

            
        }




    }

    public override void OnPlayerLeftRoom(Player other) {
        Debug.Log("A player left the room!");

        //i dont understand this!
        LoadArena();


    }


    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() {

        //go back to lobby
        SceneManager.LoadScene(0);

    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.IsConnected) {
            display.text = PhotonNetwork.CurrentRoom.Name;


        }
        
        
    }
}
}