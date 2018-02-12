using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGameManager : MonoBehaviour {

	// Use this for initialization
	public Text currentHp;
	public Text currentWeapon;
	public Text currentAmmo;
	public Text currentScore;
	public Button playBtn;
	public GameObject ammo;
	public Player player;
	private bool inverse = true;
	private bool current = true;
	public List<AudioClip> musics = new List<AudioClip>();
	public GameObject titileLvl;

	public Color color1;
	public Color color2;


	public float duration = 3.0F;


	void titilesAnimation ()  {
		if (current) {
			if (titileLvl.transform.rotation.z >= 0.04f) { current = false; }
				Quaternion tmp = Quaternion.Euler(0,0, titileLvl.transform.rotation.z + 5);
				titileLvl.transform.rotation = Quaternion.Slerp(titileLvl.transform.rotation, tmp, Time.deltaTime * 2.0f);
		} else {
			if (titileLvl.transform.rotation.z <= -0.04f) { current = true; }
			Quaternion tmp = Quaternion.Euler(0,0, titileLvl.transform.rotation.z -  5);
			titileLvl.transform.rotation = Quaternion.Slerp(titileLvl.transform.rotation, tmp, Time.deltaTime * 2.0f);
		}

	}


	void TaskOnClickPlay () {
		int fav = Random.Range(0, musics.Count);
		this.GetComponent<AudioSource>().clip = musics[fav];
		this.GetComponent<AudioSource>().Play();
		PlayerPrefs.SetInt("music",fav);
	}

	void Start () {
		playBtn.GetComponent<Button>().onClick.AddListener(TaskOnClickPlay);
		InvokeRepeating("titilesAnimation", 0.01f,  0.05f);

			this.GetComponent<AudioSource>().clip = musics[PlayerPrefs.GetInt("music")];
			this.GetComponent<AudioSource>().Play();
	}

	//TODO add the good scipt Name
	void Update () {
		if (currentHp) { currentHp.text = string.Concat("Hp: ", /*.GetComponent<playerScript>().hp  ?? */ 1); }
		if (currentWeapon && player && player.GetComponent<Player>().weapon) { currentWeapon.text =  player.GetComponent<Player>().weapon.name; }
		if (currentAmmo && player && player.GetComponent<Player>().weapon) { currentAmmo.text = string.Concat("Ammo: ", player.GetComponent<Player>().weapon.GetComponent<Weapon>().bullet); }
		if (currentScore) { currentScore.text = string.Concat("Scoce: ", /*.GetComponent<playerScript>().hp ?? */ 0); }
		float t = Mathf.PingPong(Time.time, duration) / duration;
		GetComponent<Image>().color = Color.Lerp(color1, color2, t);
		currentHp.color = Color.Lerp(Color.red, Color.blue, t);
		currentWeapon.color = Color.Lerp(Color.red, Color.green, t);
		currentAmmo.color = Color.Lerp(Color.red, Color.blue, t);
		currentScore.color = Color.Lerp(Color.red, Color.green, t);
	}
	public void Save() {
			PlayerPrefs.Save();
	}
}
