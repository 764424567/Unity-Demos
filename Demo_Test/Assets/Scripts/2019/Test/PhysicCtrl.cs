using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]		//声明要使用一个Rigibody
public class PhysicCtrl : MonoBehaviour {

	public Rigidbody rb;

	void Awake()
	{
		rb = gameObject.GetComponent <Rigidbody > ();
	}

	public void addImpulse() {


		rb.AddForce (0, 0, -10, ForceMode.Impulse);
	}

	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
