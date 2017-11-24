using UnityEngine;
using System.Collections;

public class UpGrille : MonoBehaviour {

    public bool up;

    private float y;
    // Use this for initialization
    void Start () {
        y = this.gameObject.GetComponent<Transform>().position.y;
    }

	// Update is called once per frame
	void Update () {
		if (up) {
			// Debug.Log("salut nounou");
				StartCoroutine(MoveUp());
                this.gameObject.GetComponent<Transform>().position = new Vector3(
								this.gameObject.GetComponent<Transform>().position.x, y, this.gameObject.GetComponent<Transform>().position.z);
		}
  }

	IEnumerator MoveUp()
	{
			yield return new WaitForSeconds(0.05f);
			y += 0.01f;
	}
}
