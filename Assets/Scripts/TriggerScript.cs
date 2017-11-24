using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public string levelToLoad;
    public string assetNameToDestroy;
    public GameObject assetToDestroy;


    public void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Rigidbody>() != null)
        {
            Debug.Log(assetNameToDestroy + " :  " + PlayerPrefs.GetInt(assetNameToDestroy));

            SceneManager.LoadScene(levelToLoad);
            Destroy(assetToDestroy);
            PlayerPrefs.SetInt(assetNameToDestroy, 0);
            PlayerPrefs.Save();

            Debug.Log(assetNameToDestroy + " :  " + PlayerPrefs.GetInt(assetNameToDestroy));
        }
    }
}