using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Player	target;
	public float speedReload = 0.1f;
	public GameObject ammo;
	private bool reload = true;
	public Vector3 StartPoint;
	public Vector3 EndPoint;
	private bool direction = false;
	public bool runing;
	private bool isSee = false;

	public	List<Vector3>	pathToPlayer;

	private AudioSource	audio;
	public AudioClip	deadSound;

	public float speed = 0.02f;

	public	Room		room;

	public	float		maxFolowPlayerTime = 3.0F;
	public	float		followPlayerTimer;

	public 	string		state;

	private bool		isDead = false;
	private bool		lol = false;

	// public void setRound(Vector2 s, Vector2 e) {
	// 	StartPoint = s;
	// 	EndPoint = e;
	// }

	void	OnTriggerStay2D(Collider2D other){
		// Debug.Log("Trigger : " + other.gameObject.tag);
		if (other.gameObject.GetComponent<Room>()){
			 room = other.gameObject.GetComponent<Room>();
		}
	}

	void makeRound() {
			float step = speed * Time.deltaTime;

			if (transform.position.x == StartPoint.x && transform.position.y == StartPoint.y) { direction = false; }
			if (transform.position.x == EndPoint.x && transform.position.y == EndPoint.y) { direction = true; }

			if (direction) {
				float angleZ = Vector3.SignedAngle(Vector3.down, StartPoint - transform.position, Vector3.forward);
				transform.eulerAngles = new Vector3(0.0f, 0.0f, angleZ);
				transform.position = Vector3.MoveTowards (transform.position, StartPoint, step);
			}
			else {
				float angleZ = Vector3.SignedAngle(Vector3.down, EndPoint - transform.position, Vector3.forward);
				transform.eulerAngles = new Vector3(0.0f, 0.0f, angleZ);
				transform.position = Vector3.MoveTowards (transform.position, EndPoint, step);
			}
	}

	void reloadFunc() {
		reload = true;
	}
	
	void Start () {
		InvokeRepeating("reloadFunc", speedReload,speedReload);
		audio = GetComponent<AudioSource>();
	}

	bool findplayer() {

		int obstacle = 0;
		Regex regexWall = new Regex("wall");
		Regex regexDor = new Regex("door");

		if (target) {
			RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position,  target.GetComponent<Transform>().transform.position);

			foreach (RaycastHit2D hit in hits)
			{
				if(hit) {
					Match matchWall = regexWall.Match(hit.collider.name);
					Match matchDor = regexDor.Match(hit.collider.name);
					if (matchWall.Success || matchDor.Success) { obstacle ++; }
				}
			}
//			float angleZ = Vector3.SignedAngle(StartPoint - transform.position, target.transform.position - transform.position, Vector3.forward);
//			if (direction == false)
//				angleZ = Vector3.SignedAngle(EndPoint - transform.position, target.transform.position - transform.position, Vector3.forward);
			float angleZ = Vector3.SignedAngle(Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * Vector3.down, target.transform.position - transform.position, Vector3.forward);
			if(!isSee) {
				if (obstacle == 0 && (Mathf.Abs(angleZ) < 90  || Vector3.Distance(target.transform.position, transform.position) < 2.0f)) {
					isSee = true;
					transform.eulerAngles = new Vector3(0.0f, 0.0f, Vector3.SignedAngle(Vector3.down, target.transform.position - transform.position, Vector3.forward));
					runing = true;
					return true;
				} else {
					return false;
				}
			} else {
				if (obstacle == 0) {
					transform.eulerAngles = new Vector3(0.0f, 0.0f, Vector3.SignedAngle(Vector3.down, target.transform.position - transform.position, Vector3.forward));
					runing = true;
					return true;
				} else {
					isSee = false;
					return false;
				}
			}
		}
		return false;
	}

	void	followPlayer(){
		lol = true;
		followPlayerTimer += Time.deltaTime;
		if (followPlayerTimer >= maxFolowPlayerTime){
			runing = true;
			StartPoint = transform.position;
			EndPoint = transform.position;
		}
		else {
			if (pathToPlayer.Count == 0){
				pathToPlayer = room.getPathToRoom(target);
				pathToPlayer.Remove(pathToPlayer[pathToPlayer.Count - 1]);
			}
			if (pathToPlayer.Count > 0){

				Vector3	obj = pathToPlayer[pathToPlayer.Count - 1];


				float angleZ = Vector3.SignedAngle(Vector3.down, obj - transform.position, Vector3.forward);
				transform.eulerAngles = new Vector3(0.0f, 0.0f, angleZ);
				if (transform.position == Vector3.MoveTowards (transform.position, obj, 4 * Time.deltaTime)){
					pathToPlayer.Remove(pathToPlayer[pathToPlayer.Count - 1]);
				}else {
			runing = true;

					transform.position = Vector3.MoveTowards (transform.position, obj, 4 * Time.deltaTime);
				}
			}
		}

	}

	void fireAtPlayer() {
		if (ammo) {
		GameObject newShell = GameObject.Instantiate(ammo, gameObject.transform.position, gameObject.transform.rotation);
		 newShell.GetComponent<ammo>().setPlayerTarget(target.GetComponent<Transform>().position);
	 }

	}

	void Update () {
		if (isDead || !target)
			return ;

		if (findplayer()) {
			state = "Found Player";
			followPlayerTimer = 0.0F;
			if (reload){
				reload = false; fireAtPlayer();
			}
		}
		else if (!runing && !lol) {
			state = "Making Round";
		 	makeRound();
		}
		else {
			state = "followPlayer";
			followPlayer();
		}
	}

	public void dead() {
    	audio.clip = deadSound;
    	audio.Play();
    	Destroy(gameObject, 1);
    	isDead = true;
	}
}
