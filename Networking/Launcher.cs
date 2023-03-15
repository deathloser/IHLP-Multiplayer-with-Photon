using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Photon.Pun.Demo.PunBasics {
public class Launcher : MonoBehaviourPunCallbacks
{

    public Text displayText;

    public InputField joinRoomInputField;
    public InputField createRoomInputField;
    public Button createRoomButton;
    public Button joinRoomButton;
    public Button quitButton;
    public Button leaveRoomButton;

    void Awake() {
        //automatically change scenes when host changes scene on start

        //CRITICAL!!!!! for photonNetwork.LoadLevel() !!!
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        joinRoomInputField.gameObject.SetActive(false);
        createRoomInputField.gameObject.SetActive(false);
        createRoomButton.gameObject.SetActive(false);
        joinRoomButton.gameObject.SetActive(false);
        leaveRoomButton.gameObject.SetActive(false);


        if(PhotonNetwork.IsConnected) {
            displayText.text = "you are connected!";

            //PhotonNetwork.JoinRandomRoom();

        } else {

            displayText.text = "connecting to master ";
            PhotonNetwork.ConnectUsingSettings();

        }
        
        
        
    }

    public override void OnConnectedToMaster() {

        
        displayText.text = "Connected to master";

        PhotonNetwork.JoinLobby();

        

    }

    // public override void OnDisconnected(DisconnectCause cause) {
    //     Debug.Log("Disconnected! Here is the cause: " + cause);
    // }



    public override void OnJoinedLobby() {

        
        displayText.text = "joined lobby!";
        joinRoomInputField.gameObject.SetActive(true);
        createRoomInputField.gameObject.SetActive(true);
        createRoomButton.gameObject.SetActive(true);
        joinRoomButton.gameObject.SetActive(true);



    }

    public void CreateRoom() {

        
        displayText.text = "Creating room '" + createRoomInputField.text + "'";

        if(string.IsNullOrEmpty(createRoomInputField.text)) {
            return;

        }

        PhotonNetwork.CreateRoom(createRoomInputField.text);

        displayText.text = "Room created!";

        leaveRoomButton.gameObject.SetActive(true);

        StartGame();
    }

    public void JoinRoom(){

        
        displayText.text = "Joining room '" + joinRoomInputField.text + "'";
        PhotonNetwork.JoinRoom(joinRoomInputField.text);

        
        //displayText.text = "Joined room '" + PhotonNetwork.CurrentRoom.Name + "'";

        
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom(true);

        displayText.text = "You left the room";
    }

    public override void OnJoinedRoom() {
        //is for if you create OR join a room!

        Debug.Log("JOINED ROOM");

        displayText.text = "Current room is " + PhotonNetwork.CurrentRoom.Name;

        //here's another fix thanks to reading documentation ****

        if(PhotonNetwork.CurrentRoom.PlayerCount==1) {
            PhotonNetwork.LoadLevel(1);
        }


        //i dont want to display anything; just automatically start the scene
        //StartGame();


    }



    public void OnCreateRoomFailed() {

        displayText.text = "It failed!";

    }

    public void OnPhotonJoinRoomFailed(object[] codeAndMsg) {
        Debug.Log(codeAndMsg);
        
    }

    public void StartGame() {

        //PhotonNetwork.LoadLevel(1);

        //Im calling this in GAME MANAGER!!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}