using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutelScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        bool knifeVisible = PlayerPrefs.GetInt("KnifeVisible") == 0;
        bool scrollVisible = PlayerPrefs.GetInt("ScrollVisible") == 0;

        Debug.Log(knifeVisible + " / " + scrollVisible);

        if (knifeVisible && scrollVisible && col.name == "Personnage")
            SceneManager.LoadScene("WinningScene");
    }
}