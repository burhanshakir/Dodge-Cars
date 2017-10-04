using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

	public float carSpeed;
	Vector3 position;
	public audioManager am;

	bool currentPlatformForAndroid = false;

	public uiManager ui;
	// Use this for initialization

	Rigidbody2D rb;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();

		#if UNITY_ANDROID
		currentPlatformForAndroid = true;
		#endif

	}


	void Start () {

		position = transform.position;
		am.carSound.Play();

		
	}
	
	// Update is called once per frame
	void Update () {

		if (currentPlatformForAndroid) {

			accelarometerMove ();

		} else {

			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;

			}

		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.0f, 2.0f);

		transform.position = position;
		
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Enemy Car") {
			//Destroy (gameObject);
			gameObject.SetActive(false);
			ui.gameOver ();
			am.carSound.Stop ();
		}
	}

	void accelarometerMove(){
		float x = Input.acceleration.x;

		Debug.Log ("X = " + x);


		if (x < -0.15f) {
			MoveLeft ();
		} else if (x > 0.15f) {
			MoveRight ();	
		} 
		else {
			SetVelocityZero();
		}
	
	}

	public void MoveLeft(){
		rb.velocity = new Vector2 (-carSpeed, 0);
	}

	public void MoveRight(){

		rb.velocity = new Vector2 (carSpeed, 0);
	}

	public void SetVelocityZero(){
		rb.velocity = Vector2.zero;
	}
}
