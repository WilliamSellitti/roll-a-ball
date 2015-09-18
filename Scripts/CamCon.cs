using UnityEngine;
using System.Collections;

public class CamCon : MonoBehaviour { //controls the camera

	public GameObject player;
	private float offset; //attempting to get camera to always follow ball from behind (based on its velocity)
	private Vector3 cameraPosition;
	private Vector2 mousePositionLastFrame;

	
	void Start () { // Use this for initialization
	
		cameraPosition = transform.position - player.transform.position; //where the camera is relative to the ball
		offset =  cameraPosition.magnitude;
		mousePositionLastFrame = Input.mousePosition;

	} 

	void LateUpdate () { // called after the other updates (i.e. update and fixed update)

		transform.position = player.transform.position + cameraPosition;

	}
}
