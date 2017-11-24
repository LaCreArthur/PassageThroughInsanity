using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour
{

    public string assetNameToDestroy;
    public GameObject assetToDestroy;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt(assetNameToDestroy) == 0)
        {
            Destroy(assetToDestroy);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}