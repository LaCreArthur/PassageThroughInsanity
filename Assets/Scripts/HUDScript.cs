using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour
{
    public GameObject[] m_spookScreens;
    public AudioClip[] m_spookSounds;
    public Text sanityTxt;

    private AudioSource m_audioSource;
    private float _sanity;
    private float nextActionTime;
    private float period = 10f;
    private int m_quadIndex;
    private bool m_playerSpooked = false;
    private int m_numberOfBlinks = 0;
    private Texture2D progressBarEmpty;
    private Texture2D progressBarFull;
    private Vector2 pos = new Vector2(20, 40);
    private Vector2 size = new Vector2(300, 20);


    void OnGUI()
    {
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

        GUI.BeginGroup(new Rect(0, 0, size.x * _sanity, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.EndGroup();
        GUI.EndGroup();
    }


    void Start()
    {
        _sanity = PlayerPrefs.GetFloat("Sanity");
        m_audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        _sanity -= Time.deltaTime / 600f;
        PlayerPrefs.SetFloat("Sanity", _sanity);
        PlayerPrefs.Save();

        if (m_numberOfBlinks > 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1) ToggleRandomQuad();
        }

        if (Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += period;
            ManageSanity();
        }

        if (_sanity <= 0)
            SceneManager.LoadScene("LosingScene");
    }


    void ManageSanity()
    {
        int jumpScareProbability = (int)((1 - _sanity) * 100);
        int nombreRandom = Random.Range(0, 100);

        if (nombreRandom <= jumpScareProbability)
        {
            m_numberOfBlinks = Random.Range(1, 6);
            m_quadIndex = Random.Range(0, m_spookScreens.Length);
            int soundIndex = Random.Range(0, m_spookSounds.Length);
            m_audioSource.clip = m_spookSounds[soundIndex];
            m_audioSource.Play();
            if (SceneManager.GetActiveScene().buildIndex == 1) ToggleRandomQuad();
            //sanityTxt.text = "Sanity : " + _sanity;
        }
    }

    void ToggleRandomQuad()
    {
        if (m_playerSpooked)
        {
            m_spookScreens[m_quadIndex].GetComponent<TeleportQuadTo>().Reset();
            m_playerSpooked = false;
            --m_numberOfBlinks;
        }
        else
        {
            m_spookScreens[m_quadIndex].GetComponent<TeleportQuadTo>().Call();
            m_playerSpooked = true;
        }
    }
}