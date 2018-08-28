using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    public Rigidbody RB;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,0,Input.GetAxis("Vertical")), Space.Self);
        transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal"),0));
    }
}
