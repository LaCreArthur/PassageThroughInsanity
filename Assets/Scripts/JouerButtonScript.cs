using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public void DemarrerPartie()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }
}