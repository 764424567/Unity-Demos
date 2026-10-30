using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGetComponent : MonoBehaviour {

	private PhysicCtrl[]  PSCs;

	void Awake(){
		PSCs = new PhysicCtrl[3] ; 	
	}

	void OnEnable() {
		PSCs[0] = gameObject.GetComponentsInParent<PhysicCtrl> ()[0];
		PSCs[1] = gameObject.GetComponentsInChildren<PhysicCtrl> ()[0];
		PSCs[3] = GameObject.Find ("wall").GetComponent<PhysicCtrl> ();
	}

	// Use this for initialization
	void Start () {
		foreach (PhysicCtrl psc in PSCs) {
			psc.addImpulse ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
