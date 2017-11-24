using UnityEngine;
using System.Collections;

public class activeLight : MonoBehaviour {

    public GameObject Light;
    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name ==  "Personnage"){
				Light.SetActive(true);
			}
    }

}
