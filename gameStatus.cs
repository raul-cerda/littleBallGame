using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class gameStatus : MonoBehaviour {
	
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	
	kartInputs[] karts = new kartInputs[4];

	// Use this for initialization
	void Start () {
		karts[0] = p1.GetComponent<kartInputs>();
		karts[1] = p2.GetComponent<kartInputs>();
		karts[2] = p3.GetComponent<kartInputs>();
		karts[3] = p4.GetComponent<kartInputs>();
	}
	
	// Update is called once per frame
	void Update () {
		sortKarts();
		for(int i = 0; i < 4; i++)
			karts[i].currentPos = i+1;
		
		if(karts[0].finished == true && karts[1].finished == true && karts[2].finished == true && karts[3].finished == true)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	void sortKarts(){
		int minInd = 0;
		kartInputs temp;
		for(int i = 0; i < 4; i++)
		{
			minInd = i;
			for(int j = i+1; j < 4; j++)
			{
				if(karts[j].distFromFinish < karts[minInd].distFromFinish)
					minInd = j;
			}
			temp = karts[i];
			karts[i] = karts[minInd];
			karts[minInd] = temp;
		}
	}
}
