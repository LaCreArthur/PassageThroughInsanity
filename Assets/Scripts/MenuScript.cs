using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetInt("KnifeVisible", 1);
        PlayerPrefs.SetInt("ScrollVisible", 1);
        PlayerPrefs.SetFloat("Sanity", 1f);
        PlayerPrefs.Save();
    }


    public void DemarrerPartie()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }
}
