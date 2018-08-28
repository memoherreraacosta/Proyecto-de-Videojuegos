using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public Rigidbody RB;
	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(new Vector3(0,0,Input.GetAxis("Vertical")), Space.Self);
        //transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal"),0));
        RB.AddForce(Vector3.forward * Input.GetAxis("Vertical") * 70000);
        RB.AddForce(Vector3.left * -Input.GetAxis("Horizontal") * 35000);
    }
}
