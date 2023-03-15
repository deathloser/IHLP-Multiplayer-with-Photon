using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter(Collider other) {
        door.SetActive(false);
        Debug.Log("We touched !");
        Destroy(this.gameObject);



    }

}
