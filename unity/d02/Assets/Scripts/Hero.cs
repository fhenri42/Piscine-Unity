using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	private float lerpMoving = 1;
	private float speed = 0.08f;
	private bool asStart = false;
	private Vector2 togo;
	Animator anim;
	public AudioClip myclip;


	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}


	void choseDirection(Vector2 togo) {

		float pos = Mathf.Atan( (togo.y - transform.position.y) / (togo.x - transform.position.x));
		if (pos <= 2 && pos >=0.7) {
			if(togo.y > transform.position.y) {
				this.GetComponent<Animator>().SetTrigger("moveN");
			} else {
				this.GetComponent<Animator>().SetTrigger("MoveS");
			}

		} else if (pos <= 0.7 && pos >= 0.4 ) {

			if(togo.x < transform.position.x) {
				this.GetComponent<SpriteRenderer>().flipX = true;
				this.GetComponent<Animator>().SetTrigger("MoveSE");
			} else {
				this.GetComponent<Animator>().SetTrigger("moveNE");

			}
		} else if(pos <= 0.4 &&  pos >= -0.5) {
			if(togo.x < transform.position.x) { this.GetComponent<SpriteRenderer>().flipX = true; }
			this.GetComponent<Animator>().SetTrigger("moveE");



		} else if(pos <= -0.5 &&  pos >= -2) {

			if(togo.x < transform.position.x) {
				this.GetComponent<SpriteRenderer>().flipX = true;

				this.GetComponent<Animator>().SetTrigger("moveNE");
			} else {

				this.GetComponent<Animator>().SetTrigger("MoveSE");

			}

		}  else {
			print("can find Dir");
		}

	}

	public void movePlayer(Vector2 togoTmp) {
		asStart = true;
		togo = togoTmp;
		lerpMoving = 1;

		this.GetComponent<Animator>().ResetTrigger("StopAll");
		this.GetComponent<Animator>().enabled = true;
		this.GetComponent<SpriteRenderer>().flipX = false;

		this.GetComponent<AudioSource>().clip = myclip;
		this.GetComponent<AudioSource>().Play();
		choseDirection(togo);

	}
	void Update () {

		if(asStart == true) {
			if (transform.position.x == togo.x && transform.position.y == togo.y) {
				this.GetComponent<Animator>().ResetTrigger("moveN");
				this.GetComponent<Animator>().ResetTrigger("MoveS");
				this.GetComponent<Animator>().ResetTrigger("moveNE");
				this.GetComponent<Animator>().ResetTrigger("moveE");
				this.GetComponent<Animator>().ResetTrigger("MoveSE");
				this.GetComponent<Animator>().SetTrigger("StopAll");
				this.GetComponent<Animator>().enabled = false;

				asStart = false; }
				else {
					lerpMoving += Time.deltaTime;
					transform.position = Vector3.MoveTowards(transform.position, togo, speed * lerpMoving);
				}
			}
		}
	}
