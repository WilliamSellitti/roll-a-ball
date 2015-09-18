using UnityEngine;
using System.Collections;

public class ScoreObject : MonoBehaviour {
	
	void Update () {
	
		transform.Rotate (new Vector3 (45, 45, 45) * Time.deltaTime);

	}
}
