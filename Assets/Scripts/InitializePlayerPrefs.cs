using UnityEngine;
using System.Collections;

public class InitializePlayerPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetFloat("Sanity", 1f);
    }
}