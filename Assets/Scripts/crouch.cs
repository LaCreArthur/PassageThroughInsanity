using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class crouch : MonoBehaviour
 {
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsc;

    private CharacterController chController;
    private Transform tr;
    float height;
    float radius;
    float speed;
    public GameObject character;

    // Use this for initialization
    void Start ()
     {
        fpsc = GetComponent<FirstPersonController>();
        chController = GetComponent<CharacterController>();
        height = chController.height;
        radius = chController.radius;
        speed = fpsc.m_WalkSpeed;
    }

     // Update is called once per frame
     void Update ()
    {
        float x = character.GetComponent<Transform>().position.x;
        float y = character.GetComponent<Transform>().position.y;
        float z = character.GetComponent<Transform>().position.z;
        if (Input.GetKey("c"))
         { // press C to crouch
            chController.height = height / 2;
						// chController.radius = radius / 2;
            fpsc.m_WalkSpeed = speed * 0.7f; // slow down when crouching
            // character.GetComponent<Transform>().position = new Vector3(x, y / 2f, z);
						transform.localScale = new Vector3 (1,0.2f,1);
        }
        else {
            chController.height = height;
            fpsc.m_WalkSpeed = speed;
            transform.localScale = new Vector3(1,1,1);
						// character.GetComponent<Transform>().position = new Vector3(x,y,z);
        }
    }
 }
