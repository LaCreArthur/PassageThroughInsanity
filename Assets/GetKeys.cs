using UnityEngine;
using System.Collections;

public class GetKeys : MonoBehaviour {

	public GameObject smartphone;
	public GameObject charkeys;
	public GameObject mapkeys;
	// Use this for initialization
	void Start () {

}

// Update is called once per frame
void OnTriggerEnter(Collider other)
    {
	Debug.Log(other.name);
		if (other.gameObject.name ==  "Personnage"){
					smartphone.SetActive(false);
					charkeys.SetActive(true);
					mapkeys.SetActive(false);
			}
}
}
