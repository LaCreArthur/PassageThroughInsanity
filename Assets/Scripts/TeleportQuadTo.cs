using UnityEngine;
using System.Collections;

public class TeleportQuadTo : MonoBehaviour
{

    public GameObject m_goPlayer;

    public void Call()
    {
        gameObject.transform.position = m_goPlayer.transform.position + m_goPlayer.transform.forward;
        gameObject.transform.rotation = m_goPlayer.transform.rotation;
        Debug.Log("TeleportQuadTo : Call()");
    }
    
    public void Reset()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
