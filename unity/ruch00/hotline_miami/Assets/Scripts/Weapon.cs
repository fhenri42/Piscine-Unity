using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Vector2	velocity;
	public ammo		am;
	public int		bullet;
	public float	range = 10;

	public AudioClip	fireSound;
	public AudioClip	unload;

	private AudioSource	audio;
	private bool		justSend = false;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f && !justSend)
			GetComponent<Collider2D>().isTrigger = true;
		justSend = false;
	}

	public void Send() {
		GetComponent<Collider2D>().isTrigger = false;
		GetComponent<Rigidbody2D>().AddForce(velocity * 5.0f);
		justSend = true;
	}

	public void Fire(Vector2 dir) {
		if (bullet != 0)
		{
			if (bullet > 0)
				bullet--;
			Debug.Log("shoot");
	    	audio.clip = fireSound;
	    	audio.Play();
			GameObject newShell = GameObject.Instantiate(am.gameObject, gameObject.transform.position, gameObject.transform.rotation);
			newShell.GetComponent<ammo>().getTarget(dir,range);
		}
		else
		{
	    	audio.clip = unload;
	    	audio.Play();
		}
	}
}
