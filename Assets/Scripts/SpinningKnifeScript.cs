using UnityEngine;
using System.Collections;

public class SpinningKnifeScript : MonoBehaviour
{
    public string KeyName;


    // Use this for initialization
    void Start()
    {
        int visible = PlayerPrefs.GetInt(KeyName);
        if (visible == 0) 
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 3, 0);
    }
}