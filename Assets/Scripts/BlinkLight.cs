using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour
{
    private int Number = 1;
    private float intensity1;
    private float intensity2;
    private bool trigger;
    private int i;

    void Start()
    {
        i = 0;
        trigger = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (trigger && i < 10) StartCoroutine(wait());
        else if (trigger && i == 10)
        {
            this.GetComponent<Light>().intensity = 0;
            trigger = false;
        }
    }


    IEnumerator wait()
    {
        trigger = false;
        yield return new WaitForSeconds(0.05f);
        this.GetComponent<Light>().intensity = Random.Range(0.5f, 5.5f);
        i++;
        trigger = true;
        // Debug.Log("hey");
    }
}
