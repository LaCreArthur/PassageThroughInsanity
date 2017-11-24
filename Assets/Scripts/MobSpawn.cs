using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MobSpawn : MonoBehaviour {

    //Can be controlled by sanity
    public bool m_controlledBySanity = true;

    public int m_minFrameDelay = 60;
    public int m_maxFrameDelay = 60;
    public int m_startFrameDelay = 120;

    public Vector2 m_minPosition = new Vector2(-100, -100);
    public Vector2 m_maxPosition = new Vector2(100, 100);

    public float m_minDistance;

    public GameObject m_goOfPlayer;
    public GameObject[] m_gosOfMobs;

    private int m_frameDelay = 0;
    private UnityEvent m_evUpdate;

	// Use this for initialization
	void Start ()
    {
        m_evUpdate = new UnityEvent();
        if (!m_controlledBySanity)
            m_evUpdate.AddListener(() =>
            {
                if (m_startFrameDelay > 0)
                {
                    --m_startFrameDelay;
                }
                else
                {
                    if (m_frameDelay > 0)
                    {
                        --m_frameDelay;
                    }
                    else
                    {
                        m_frameDelay = Random.Range(m_minFrameDelay, m_maxFrameDelay);
                        Spawn();
                    }
                }
            });
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_evUpdate.Invoke();
    }

    void Spawn()
    {
        Vector2 player2DPosition = new Vector2(
                    m_goOfPlayer.transform.position.x,
                    m_goOfPlayer.transform.position.z
                    );
        Vector2 mob2DPosition = new Vector2(
            Random.Range(m_minPosition.x + player2DPosition.x, m_maxPosition.x + player2DPosition.x),
            Random.Range(m_minPosition.y + player2DPosition.y, m_maxPosition.y + player2DPosition.y)
        );
        if (Vector2.Distance(mob2DPosition, player2DPosition) >= m_minDistance)
        {
            int indice = Random.Range(0, m_gosOfMobs.Length);
            //TODO: how to know which y?
            Instantiate(m_gosOfMobs[indice], new Vector3(mob2DPosition.x, 20, mob2DPosition.y), m_goOfPlayer.transform.rotation);
        }
    }
}
