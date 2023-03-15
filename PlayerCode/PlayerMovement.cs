using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;


public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public int speed = 6;
    public float gravity = -9.8f;
    public CharacterController controller;
    public float MoveSpeed;
    public float RotateSpeed;

    PhotonView photonView;
    Camera cam;

    Vector3 playerTransform;
    Vector3 cameraTransform;
    Vector3 offset;


    private void Start() {
        //get this photon view
    photonView = gameObject.GetComponent<PhotonView>(); 
    cam = GameObject.Find("Main Camera").GetComponent<Camera>();

    playerTransform = this.gameObject.transform.position;
    cameraTransform = cam.transform.position;

    offset = playerTransform - cameraTransform;


    }

    void Awake() {
    controller = GetComponent<CharacterController>();   

    
    }

    void Update() {

        //if photon

        if(photonView.IsMine==false && PhotonNetwork.IsConnected==true) {
            return;
            

        }
        
        MoveThePlayer();

        if(photonView.IsMine==true) {

            CameraFollow();
        }
        
        
        
    }
    void MoveThePlayer() {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;
        moveDirection.y = gravity;

        controller.Move(moveDirection);


    }

    void CameraFollow() {
        cameraTransform = playerTransform + offset;
    }
}


