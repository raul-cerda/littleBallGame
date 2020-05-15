using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playCamera : MonoBehaviour {
	
	public GameObject playerObj;
	Rigidbody physicsBody;
	kartInputs kartInfo;
	Text racePosition;
	
	Vector3 displaceVector = new Vector3(0f, 7.5f, -10.5f);
	
	

	// Use this for initialization
	void Start () {
		physicsBody = playerObj.GetComponent<Rigidbody>();
		kartInfo = playerObj.GetComponent<kartInputs>();
		racePosition = GetComponentInChildren<Text>();
		
		transform.position = physicsBody.transform.position + displaceVector;
		transform.LookAt(physicsBody.transform);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = physicsBody.transform.position + displaceVector;
		transform.LookAt(physicsBody.transform);
		
		DisplayPosition();
	}
	
	void DisplayPosition()
	{
		if (kartInfo.currentPos == 1)
			racePosition.text = " " + kartInfo.currentPos + "st";
		if (kartInfo.currentPos == 2)
			racePosition.text = " " + kartInfo.currentPos + "nd";
		if (kartInfo.currentPos == 3)
			racePosition.text = " " + kartInfo.currentPos + "rd";
		if (kartInfo.currentPos == 4)
			racePosition.text = " " + kartInfo.currentPos + "th";
	}
}