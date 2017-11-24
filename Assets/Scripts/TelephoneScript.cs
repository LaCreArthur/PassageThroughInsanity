using UnityEngine;
using System.Collections;

public class TelephoneScript : MonoBehaviour
{
    public GameObject character;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().rotation = character.GetComponent<Transform>().rotation;
    }
}