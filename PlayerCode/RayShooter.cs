using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Photon.Pun.Demo.Basics {
public class RayShooter : MonoBehaviour, IPunObservable
{
    private Camera camera;

    bool IsFiring;

    PhotonView photonView;

    

    void Start() {

        camera = GetComponent<Camera>();
        

        photonView = this.gameObject.GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    void OnGUI() {
        int size = 12;
        float posX = camera.pixelWidth/2 - size/4;
        float posY = camera.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX,posY,size,size), "*");

    }

    void Update() {

        if (photonView.IsMine) {
            ProcessShooting();


        }

    
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo message) {

        //i dont undersstand this part
        

        if(stream.IsWriting) {
            //we're expected to send to the stream

            
            stream.SendNext(IsFiring);

        } else {
            //we're expected to listen to the stream
            this.IsFiring = (bool)stream.ReceiveNext();


        }
        


    }

    void ProcessShooting() {

        if (Input.GetMouseButtonDown(0)) {
            IsFiring = true;
            Vector3 point = new Vector3(camera.pixelWidth/2, camera.pixelHeight/2,0);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                WanderingAI target = hitObject.GetComponent<WanderingAI>(); 

                if (target != null) {
                    target.ReactToHit();
                    Debug.Log("target hit!");
                } else {
                    StartCoroutine(SphereIndicator(hit.point));
                }

            }


        }

        if(Input.GetMouseButtonUp(0)) {
            IsFiring = false;

            
        }


    }

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }


}
}
