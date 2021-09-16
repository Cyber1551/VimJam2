using System;
using UnityEngine;
using System.Collections;
using Player.Control;

public class hitDummy : MonoBehaviour {

	private Animator DummyAnimator;

	public GameObject hit;
	public GameObject hay;

	void Start () {
		DummyAnimator = GetComponent<Animator>();
	}



	void OnCollisionEnter(Collision collision) 
	{
		ContactPoint contact = collision.contacts[0];

		var dir = transform.position - PlayerController.Instance.transform.position;
		Debug.Log(dir);
		dir.y = 0;
		dir.Normalize();
		var rotDir = transform.InverseTransformDirection(dir);
		
		GetComponent<Rigidbody>().AddForce(rotDir * 120, ForceMode.Impulse);
		
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.point);
		//GetComponent<Rigidbody>().AddForce((transform.position - contact.normal) * 10, ForceMode.Impulse);
		//var test = collision.gameObject.transform.position - PlayerController.Instance.transform.position;
		//Debug.Log(test);

		var force = transform.position - contact.normal;
	
		Vector3 pos = contact.point;
		DummyAnimator.SetTrigger("hit");
		var go = Instantiate(hit, transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
		go.transform.position = go.transform.position + go.transform.right;
		Destroy(go, 1f);	
		Instantiate(hay, transform.position + Vector3.up, Quaternion.identity);
	}
	
}
