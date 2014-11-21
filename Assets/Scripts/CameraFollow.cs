using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	private Vector3 cameraTarget;
	public float speed = .5f;

	Bat player;

	// Use this for initialization
	void Start () {
		cameraTarget = target.position + Vector3.up * 3 - Vector3.forward * 15;
		transform.position = cameraTarget;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Bat>();
			
			}
			
			// Update is called once per frame
			void Update () {
				cameraTarget = target.position + Vector3.up * 3 - Vector3.forward * 15;
				transform.position = (Vector3.Lerp(transform.position, cameraTarget, speed));
			}
		}