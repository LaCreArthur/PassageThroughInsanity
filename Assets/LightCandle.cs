using UnityEngine;
using System.Collections;

public class LightCandle : MonoBehaviour {

    public GameObject LightCandle1;
    public GameObject LightCandle2;
    public GameObject LightCandle3;
    public GameObject LightCandle4;
    public GameObject LightCandle5;

		public GameObject smartphone;
    public GameObject torche;
    public GameObject GrillePiece;
    public GameObject GrilleZombie;

    private float GrillePieceX;
		private float GrillePieceY;
		private float GrillePieceZ;
    private float GrilleZombieX;
		private float GrilleZombieY;
		private float GrilleZombieZ;

    // Use this for initialization
    void Start () {
        GrillePieceX = GrillePiece.GetComponent<Transform>().position.x;
        GrillePieceY = GrillePiece.GetComponent<Transform>().position.y;
        GrillePieceZ = GrillePiece.GetComponent<Transform>().position.z;
        GrilleZombieX = GrilleZombie.GetComponent<Transform>().position.x;
        GrilleZombieY = GrilleZombie.GetComponent<Transform>().position.y;
        GrilleZombieZ = GrilleZombie.GetComponent<Transform>().position.z;
    }

	// Update is called once per frame
	void Update () {

    }

		void OnTriggerEnter(Collider other) {
				if (other.gameObject.name ==  "Personnage" && torche.activeInHierarchy ){
	            smartphone.SetActive(true);
	            torche.SetActive(false);
	            LightCandle1.SetActive(true);
	            LightCandle2.SetActive(true);
	            LightCandle3.SetActive(true);
	            LightCandle4.SetActive(true);
            LightCandle5.SetActive(true);
            GrillePiece.GetComponent<UpGrille>().up = true;
            GrilleZombie.GetComponent<UpGrille>().up = true;
        }
    }
}
