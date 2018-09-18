using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoints : MonoBehaviour {
    public BoxCollider siguiente;
    public bool ultimo;
    public Text texto;
    public Text texto2;
    private BoxCollider caja;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Tiempo",0);
        caja = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        siguiente.enabled=true;
        if (ultimo)
        {
            if(other.name=="Jugador 1")
            {
                texto.text = "Primero";
                texto2.text = "Segundo";
                
            }
            else
            {
                texto2.text = "Primero";
                texto.text = "Segundo";
            }
            PlayerPrefs.SetInt("Tiempo",1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position,caja.bounds.size);

    }
}
