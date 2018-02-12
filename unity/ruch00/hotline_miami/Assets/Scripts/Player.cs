using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float	speed;
	public Weapon	weapon;
	private float	MoveX = 0.0f;
	private float	MoveY = 0.0f;

	public GameObject	looseCanvas;

	[HideInInspector]public Animator animator;

	public AudioClip	loadWeapon;
	public AudioClip	sendWeapon;

	public Room			room;

	private AudioSource	audio;

	public	List<Enemy>	enemyList = new List<Enemy>();

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
	}

	void	OnTriggerStay2D(Collider2D other){
		// Debug.Log("Trigger : " + other.gameObject.tag);
//		if (other.gameObject.GetComponent<Room>()){
//			 room = other.gameObject.GetComponent<Room>();
//		}
	}


	void	OnTriggerEnter2D(Collider2D other){
		// Debug.Log("Trigger : " + other.gameObject.tag);
		if (other.gameObject.tag == "Enemy"){
			Enemy to_add = other.gameObject.GetComponent<Enemy>();
			Debug.Log("got an enemy");
			if (to_add && !enemyList.Contains(to_add)){
				Debug.Log("add to list");
				enemyList.Add(to_add);
			}
		}
	}

	void	OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Enemy"){
			Enemy to_remove = other.gameObject.GetComponent<Enemy>();
			if (to_remove && enemyList.Contains(to_remove)){
				enemyList.Remove(to_remove);
			}
		}
	}



	
	// Update is called once per frame
	void Update () {
    	RaycastHit2D[] hitsRoom = Physics2D.RaycastAll(transform.position, Vector2.zero);
    	foreach (RaycastHit2D hit in hitsRoom)
    	{
			if (hit.collider.gameObject.GetComponent<Room>()){
				 room = hit.collider.gameObject.GetComponent<Room>();
			}
		}

		MoveX = 0.0f;
		MoveY = 0.0f;
		if (Input.GetKey("w"))
			MoveY += speed;
		if (Input.GetKey("s"))
			MoveY -= speed;
		if (Input.GetKey("d"))
			MoveX += speed;
		if (Input.GetKey("a"))
			MoveX -= speed;
		if (MoveX != 0.0f && MoveY != 0.0f)
		{
			MoveX /= 1.4f;
			MoveY /= 1.4f;
		}

		if (MoveY != 0.0f || MoveX != 0.0f)
        	animator.SetBool("walk", true);
        else
        	animator.SetBool("walk", false);


		if (Input.GetKeyDown("e"))
		{
	    	RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.zero);
	    	foreach (RaycastHit2D hit in hits)
	    	{
				if (weapon)
					sendGun();
				if (hit.collider.gameObject.GetComponent<Room>()){
					 room = hit.collider.gameObject.GetComponent<Room>();
				}
	    		if (hit.collider.gameObject.tag == "weapon")
	    		{
			    	audio.clip = loadWeapon;
			    	audio.Play();
					Debug.Log("grab gun");
					weapon = hit.collider.gameObject.transform.parent.GetComponent<Weapon>();
					weapon.transform.parent = gameObject.transform;
					weapon.transform.GetChild(0).gameObject.SetActiveRecursively(false);
					weapon.transform.GetChild(1).gameObject.SetActiveRecursively(true);
					weapon.transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z);
					weapon.transform.Translate(transform.position.x - weapon.transform.position.x, transform.position.y - weapon.transform.position.y, 0.0f, Space.World);
					break;
	    		}
	    	}
		}

		if (Input.GetMouseButtonDown(1) && weapon)
		{
			sendGun();
		}

		if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > 130)
		{
			if (weapon)
			{
				Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				cam.z = 0.0f;
				float angleZ = Vector3.SignedAngle(Vector3.down, cam - transform.position, Vector3.forward) - 90.0f;
				Vector2 velocity = new Vector2(Mathf.Cos(angleZ * Mathf.Deg2Rad), Mathf.Sin(angleZ * Mathf.Deg2Rad)) *0.4f;
				weapon.Fire(velocity);
				foreach (Enemy e in enemyList){
					e.runing = true;
				}
			}
		}
	}

	void sendGun() {
    	audio.clip = sendWeapon;
    	audio.Play();
		Debug.Log("send gun");
		weapon.transform.parent = null;
		weapon.transform.GetChild(0).gameObject.SetActiveRecursively(true);
		weapon.transform.GetChild(1).gameObject.SetActiveRecursively(false);
		Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		cam.z = 0.0f;
		float angleZ = Vector3.SignedAngle(Vector3.down, cam - transform.position, Vector3.forward) - 90.0f;
		weapon.velocity = new Vector2(Mathf.Cos(angleZ * Mathf.Deg2Rad), Mathf.Sin(angleZ * Mathf.Deg2Rad)) *0.4f;
		weapon = null;
	}

	void FixedUpdate () {
		transform.Translate(MoveX, MoveY, 0.0f, Space.World);
		if (weapon)
		{
			weapon.transform.position = transform.position;
			weapon.transform.rotation = new Quaternion(0,0,0,0);
		}

		Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		cam.z = 0.0f;
		float angleZ = Vector3.SignedAngle(Vector3.down, cam - transform.position, Vector3.forward);
		transform.eulerAngles = new Vector3(0.0f, 0.0f, angleZ);
	}

	public void looseGame() {
    	looseCanvas.SetActive(true);
    	looseCanvas.transform.GetChild(0).gameObject.SetActive(true);
    	looseCanvas.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
    	Destroy(gameObject);
	}
}
