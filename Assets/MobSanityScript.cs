using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MobSanityScript : MonoBehaviour
{
    private float _sanity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _sanity = PlayerPrefs.GetFloat("Sanity");

        if (PlayerPrefs.GetInt("ContactMob") == 1)
            LooseSanity();

        if (_sanity <= 0)
            SceneManager.LoadScene("LosingScene");
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.GetComponent<Rigidbody>() != null)
        {
            PlayerPrefs.SetInt("ContactMob", 1);
            PlayerPrefs.Save();
        }
    }

    void OnTriggerExit()
    {
        PlayerPrefs.SetInt("ContactMob", 0);
        PlayerPrefs.Save();
    }

    void LooseSanity()
    {
        _sanity -= 0.005f;
        PlayerPrefs.SetFloat("Sanity", _sanity);
        PlayerPrefs.Save();
    }
}