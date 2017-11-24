using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public GameObject RoomDoor;
    void OnTriggerEnter(Collider other) {
			if (other.gameObject.name ==  "Charkeys"){
            Debug.Log("key");
            RoomDoor.GetComponent<Rigidbody>().isKinematic = false;
        }
	}
}
