using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public GameObject	looseCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
    	if (collision.gameObject.tag == "Player")
    	{
    		Destroy(collision.gameObject);
	    	looseCanvas.SetActive(true);
	    	looseCanvas.transform.GetChild(1).gameObject.SetActive(true);
	    	looseCanvas.transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
    	}
    }
}
