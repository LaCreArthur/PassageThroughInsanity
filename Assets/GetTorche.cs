using UnityEngine;
using System.Collections;

public class GetTorche : MonoBehaviour {

    public GameObject smartphone;
    public GameObject torche;
    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
			if (other.gameObject.name ==  "Personnage"){
            smartphone.SetActive(false);
            torche.SetActive(true);
            this.gameObject.SetActive(false);
        }
	}
}
