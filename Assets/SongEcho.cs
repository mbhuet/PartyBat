using UnityEngine;
using System.Collections;

public class SongEcho : MonoBehaviour {

	public AudioClip song;
	public GameObject soundWave;
	public GameObject light;
	// Use this for initialization
	void Start () {
		StartCoroutine ("SongPulse");
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!audio.isPlaying) 
		{
			StopCoroutine("SongPulse");
			StartCoroutine ("SongPulse");
			Debug.Log("Pulse");
			audio.Play ();
		}
	}




	IEnumerator SongPulse(){
		while (true) {
			StartCoroutine ("Pulse");
			yield return new WaitForSeconds (3.2f);
		}
	}


	IEnumerator Pulse(){
		//shockwave.Emit (1);
		
		Light l = (GameObject.Instantiate (light, this.transform.position, Quaternion.identity) as GameObject).GetComponent<Light>();
		
		float maxSize = 15;
		float waveSpeed = 40;
		GameObject wave = GameObject.Instantiate (soundWave, this.transform.position, Quaternion.identity) as GameObject;
		float t = 0;
		while (t<maxSize) {
			t+= Time.deltaTime * waveSpeed;
			wave.transform.localScale = Vector3.one * t;
			yield return null;
		}
		
		wave.transform.localScale = Vector3.zero;
		GameObject.Destroy (wave);
	}

}
