using UnityEngine;
using System.Collections;

public class PlayOnTrigger : MonoBehaviour {

    public GameObject m_goOfPlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.Equals(m_goOfPlayer.GetComponent<Collider>()))
        {
            Destroy(GetComponent<Collider>());
            GetComponent<AudioSource>().Play();
        }
    }
}