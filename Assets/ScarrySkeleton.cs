using UnityEngine;
using System.Collections;

public class ScarrySkeleton : MonoBehaviour {

		public GameObject smartphone;
		public GameObject charkeys;
    public GameObject Skeleton;
    public bool active;
    float x;
    float y;
    float z;
    // Use this for initialization
    void Start () {
        active = false;
    }

	// Update is called once per frame
	void Update () {
		if (active) {
			// Debug.Log("salut nounou");
				StartCoroutine(Move());
        Skeleton.GetComponent<Transform>().position = new Vector3(x, y, z);
		}
  }

	IEnumerator Move()
	{
			yield return new WaitForSeconds(0.01f);
			y -= 0.06f;
			z += 0.1f;
	}

		void OnTriggerEnter(Collider other) {

				Debug.Log(other.name);
        if (other.gameObject.name == "Personnage" && !active)
        {
			x = Skeleton.GetComponent<Transform>().position.x;
	        y = Skeleton.GetComponent<Transform>().position.y;
	        z = Skeleton.GetComponent<Transform>().position.z;
					Debug.Log("collision");
            active = true;
						smartphone.SetActive(true);
						charkeys.SetActive(false);
        }
		}
}
