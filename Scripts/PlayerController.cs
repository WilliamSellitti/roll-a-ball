using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text win;

	private Rigidbody rb;
	private int count;
	private float timeLastJump;

	void Start () { //run when object is first created

		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		win.text = "";
		timeLastJump = -5;

	} 

	void FixedUpdate () { //called before performing physics calculations

		if (Input.GetButtonDown ("Jump") && Time.time >= timeLastJump + 2) { //this causes player to jump
			
			rb.velocity = rb.velocity + new Vector3 (0, 10, 0);
			timeLastJump = Time.time;
			
		}

		float moveX = Input.GetAxis ("Horizontal");
		float moveZ = Input.GetAxis ("Vertical");

		rb.AddForce (new Vector3 (moveX, 0, moveZ) * speed);

	} 

	void OnTriggerEnter (Collider other) { //checks if player object is touching trigger objects

		if (other.gameObject.CompareTag ("ScoreObject")) { //checks if player object is hitting right piece
		
			other.gameObject.SetActive (!other.gameObject.activeSelf);
			count++;
			SetCountText ();

		}

		if (other.gameObject.CompareTag ("SpeedBooster")) { //checks if player object is hitting right piece
			
			rb.velocity = ( rb.velocity * 3 );
			
		}

		if (other.gameObject.CompareTag ("Bounds")) { //checks if player object is hitting right piece
			
			rb.transform.position = new Vector3 (0, 0, 0);
			rb.velocity = new Vector3 (0, 0, 0);
			
		}
	
	} 

	void SetCountText () { //counts number of scoreObjects hit

		countText.text = "Number of Cubes eaten: " + count.ToString ();
		if (count == 20)
			win.text = "YOU WIN!!!";

	} 

}
