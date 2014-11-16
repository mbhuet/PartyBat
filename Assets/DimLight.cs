using UnityEngine;
using System.Collections;

public class DimLight : MonoBehaviour {
	public float speed;
	Light light;
	// Use this for initialization
	void Start () {
		light = this.GetComponent<Light> ();
		StartCoroutine ("Dim");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Dim(){
		float t = light.intensity;
		while (t>0) {
			t-= Time.deltaTime* speed;
			light.intensity = t;
			yield return null;
		}

		GameObject.Destroy (this.gameObject);
			
	}
}
