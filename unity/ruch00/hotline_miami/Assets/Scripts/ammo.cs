using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour {

	[HideInInspector]public Vector2 targetPosition;
	public float speed;

	private Vector3 lastPos;
	private float	distanceFinal;
	private string	toKill;

	public void getTarget(Vector2 pos, float distance) {
		targetPosition = new Vector2(pos.x * distance + transform.position.x, pos.y * distance + transform.position.y);//bot.transform.position;

		GetComponent<Rigidbody2D>().AddForce(pos * 100 * speed);

		transform.Rotate(0,0,90);

		toKill = "Enemy";

		distanceFinal = Mathf.Abs(targetPosition.x - transform.position.x);
	}
	public void setPlayerTarget(Vector2 pos) {
		targetPosition = pos;
		transform.Rotate(0,0,90);

		toKill = "Player";

		distanceFinal = Mathf.Abs(targetPosition.x - transform.position.x);
	}

	void Update () {
		if (toKill == "Player")
		{
			lookForward();
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards (transform.position, targetPosition, step);
		}

		if (distanceFinal < Mathf.Abs(targetPosition.x - transform.position.x) || (Vector2)transform.position == (Vector2)targetPosition) {
			Destroy (gameObject);
		}
		distanceFinal = Mathf.Abs(targetPosition.x - transform.position.x);
	}

	void lookForward() {
		Vector3 moveDirection = gameObject.transform.position - lastPos;
		if (moveDirection != Vector3.zero)
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		lastPos = gameObject.transform.position;
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
    	print(collision.gameObject.tag);
    	if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "door")
    		Destroy(gameObject);
    	if (collision.gameObject.tag == toKill)
    	{
    		if (toKill == "Player")
    			collision.gameObject.GetComponent<Player>().looseGame();
    		else
    			collision.gameObject.GetComponent<Enemy>().dead();
    		Destroy(gameObject);
    	}
    }
}
