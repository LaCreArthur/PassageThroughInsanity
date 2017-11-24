using UnityEngine;
using System.Collections;

public class GlitchSmartphoneScript : MonoBehaviour
{
    public Texture[] textures;
    private float _sanity;
    private Texture _nextGlitch;

    private Texture _currentTexture;

    public Texture _normalTexture;
    public Texture _messageStartTexture;
    public Texture _messageLastTexture;

    public float m_secondsOfMessage;

    private AudioSource m_audioSource;

    public AudioClip m_clipGlitch;
    public AudioClip m_clipMessage;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        _currentTexture=_normalTexture;
        ReceiveMessage(_messageStartTexture);
    }

    // Update is called once per frame
    void Update()
    {
        _sanity = PlayerPrefs.GetFloat("Sanity");
        _nextGlitch = textures[Random.Range(0, textures.Length)];


        if ((int)Time.time % 2 == 0)
        {
            ManageSanity();
        }
        else
        {
            MeshRenderer renderer = this.GetComponent<MeshRenderer>();
            if (renderer.material.GetTexture("_EmissionMap") != _currentTexture)
            {
                renderer.material.SetTexture("_EmissionMap", _currentTexture);
                m_audioSource.Stop();
            }
        }
    }

    IEnumerator letMessageDisplayed()
    {
        yield return new WaitForSeconds(m_secondsOfMessage);
        _currentTexture = _normalTexture;
    }

    void ResetTexture()
    {
        _currentTexture = _normalTexture;
    }

    public void ReceiveMessage(Texture _messageTexture)
    {
        _currentTexture = _messageTexture;
        StartCoroutine(letMessageDisplayed());
        m_audioSource.clip = m_clipMessage;
        m_audioSource.Play();
    }

    void ManageSanity()
    {
        int blinkProbability = (int)((1f - _sanity) * 100);
        int nombreRandom = Random.Range(0, 800);

        //Debug.Log(blinkProbability + " / " + nombreRandom);

        if (nombreRandom <= blinkProbability)
        {
            MeshRenderer renderer = this.GetComponent<MeshRenderer>();
            renderer.material.SetTexture("_EmissionMap", _nextGlitch);
            m_audioSource.clip = m_clipGlitch;
            m_audioSource.Play();
        }
    }
}
