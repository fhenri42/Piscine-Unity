using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UiGame : MonoBehaviour {

	public Player player;
	public Camera cam;

	public AudioClip musicAlert;
	public AudioClip musicCalme;
	public GameObject AlarmObject;
	public Slider slide;
	private bool alertIsOn = false;
	private bool notStart = true;
	private float curentValue = 0;

	void Start () {

	}

	public void addNotice(float addY) {
		curentValue +=addY;
	slide.value = curentValue;
	}
	public float getCurent() {
		return curentValue;
	}
	// Update is called once per frame
	void Update () {
		if (curentValue > 112 && musicAlert && !alertIsOn) {
			alertIsOn = true;
			notStart = false;
			cam.GetComponent<AudioSource>().clip = musicAlert;
			cam.GetComponent<AudioSource>().Play();
			AlarmObject.GetComponent<AudioSource>().Play();
		}
		if (curentValue < 112 && !notStart) {
			cam.GetComponent<AudioSource>().clip = musicCalme;
			cam.GetComponent<AudioSource>().Play();
			AlarmObject.GetComponent<AudioSource>().Pause();
			alertIsOn = false;
			notStart = true;
		 }
		 if(curentValue > 153) {
			 	SceneManager.LoadScene("ex00");
		 }
	}
}
