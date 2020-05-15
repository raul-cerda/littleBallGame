using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kartInputs : MonoBehaviour {

	Rigidbody physicsBody;
	Collider collideBody;
	public Camera cam;
	public GameObject finish;
	
	public int playerNum;
	public float speed;
	public float jumpForce = 8.5f;
	Vector3 movement;
	public Vector3 currentUpVector;
	public float distFromFinish;
	public int currentPos = 0;
	public bool finished = false;
	
	// Use this for initialization
	void Start () {
		physicsBody = GetComponent<Rigidbody>();
		collideBody = GetComponent<Collider>();
		physicsBody.maxAngularVelocity = 1000;
		currentUpVector = Vector3.up;
		distFromFinish = finish.transform.position.z - transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(playerNum == 1)
		{
			movement = Vector3.zero;
			if(Input.GetKey("w"))
				movement = new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z);
			if(Input.GetKey("s"))
				movement = new Vector3(-cam.transform.forward.x, 0f, -cam.transform.forward.z);
			if(Input.GetKey("a"))
				movement = -cam.transform.right;
			if(Input.GetKey("d"))
				movement = cam.transform.right;
			if(Input.GetKey("space") && Grounded())
				movement += currentUpVector * jumpForce;
		}
		if(playerNum == 2)
		{
			movement = Vector3.zero;
			if(Input.GetKey("up"))
				movement = new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z);
			if(Input.GetKey("down"))
				movement = new Vector3(-cam.transform.forward.x, 0f, -cam.transform.forward.z);
			if(Input.GetKey("left"))
				movement = -cam.transform.right;
			if(Input.GetKey("right"))
				movement = cam.transform.right;
			if(Input.GetKey("[0]") && Grounded())
				movement += currentUpVector * jumpForce;
		}
		if(playerNum == 3)
		{
			movement = Vector3.zero;
			if(Input.GetKey("p"))
				movement = new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z);
			if(Input.GetKey(";"))
				movement = new Vector3(-cam.transform.forward.x, 0f, -cam.transform.forward.z);
			if(Input.GetKey("l"))
				movement = -cam.transform.right;
			if(Input.GetKey("'"))
				movement = cam.transform.right;
			if(Input.GetKey("right shift") && Grounded())
				movement += currentUpVector * jumpForce;
		}
		if(playerNum == 4)
		{
			movement = Vector3.zero;
			if(Input.GetKey("[8]"))
				movement = new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z);
			if(Input.GetKey("[5]"))
				movement = new Vector3(-cam.transform.forward.x, 0f, -cam.transform.forward.z);
			if(Input.GetKey("[4]"))
				movement = -cam.transform.right;
			if(Input.GetKey("[6]"))
				movement = cam.transform.right;
			if(Input.GetKey("enter") && Grounded())
				movement += currentUpVector * jumpForce;
		}
		
		if(Grounded())
			physicsBody.AddForce(movement * speed);
		else
			physicsBody.AddForce(movement * speed * 0.3f);
		
		distFromFinish = finish.transform.position.z - transform.position.z;
	}
	
	bool Grounded()
	{
		RaycastHit hit;
		return Physics.Raycast(transform.position, Vector3.up, out hit, collideBody.bounds.extents.y + 0.1f) || Physics.Raycast(transform.position, -Vector3.up, out hit, collideBody.bounds.extents.y + 0.1f)
		|| Physics.Raycast(transform.position, Vector3.left, out hit, collideBody.bounds.extents.y + 0.1f) || Physics.Raycast(transform.position, -Vector3.left, out hit, collideBody.bounds.extents.y + 0.1f)
		|| Physics.Raycast(transform.position, -Vector3.forward, out hit, collideBody.bounds.extents.y + 0.1f) || Physics.Raycast(transform.position, -Vector3.forward, out hit, collideBody.bounds.extents.y + 0.1f);
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Finish")
			finished = true;
	}
	
	void OnCollisionStay(Collision other)
	{
		currentUpVector = other.contacts[0].normal;
	}
}
