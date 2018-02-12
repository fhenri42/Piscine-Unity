using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public	bool	has_player;

	public	bool	in_rec = false;

	public Door[]	Doors;
	public Room[]		Rooms;

	public	BoxCollider2D	bc;
	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void	OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
			has_player = true;
	}

	void	OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player")
			has_player = false;
	}


	// Empty list 		-> Nothing found;
	// Else path to room;
	public List<Vector3>	getPathToRoom(Player player){ 

		in_rec = true;
		List<Vector3>	ret = new List<Vector3>();
		if (player.room != this){
			int		minDist = -1;
			int		minIndex = -1;
			List<Vector3>	tmp_list;
			for (int i = 0; i < Rooms.Length; i++){
				if (!Rooms[i].in_rec){
					tmp_list = Rooms[i].getPathToRoom(player);
					if ((minDist == -1 || tmp_list.Count < minDist) && tmp_list.Count != 0){
						ret = tmp_list;
						minDist = tmp_list.Count;
						minIndex = i;
					}
				}
			}
			if (minDist != -1){
				ret.Add(Doors[minIndex].initPos);
				ret.Add(bc.bounds.center);		// Maybe not ??
			}
		}
		else{
			ret.Add(bc.bounds.center);
		}
		in_rec = false;
		return ret;
	}
}


//	Bruit -> circle Box attachee au player qui met les enemis en mode poursuite

// quand un enemi se met en mode poursuite il appelle une fonction qui lui renvoie une liste de position par lesquelles il vas essayer de passer