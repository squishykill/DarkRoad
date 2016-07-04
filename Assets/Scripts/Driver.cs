using UnityEngine;
using System.Collections;


public class Driver : MonoBehaviour {
	

	private int playerMove;
	private int lastMove;

	private int color;
	public float speed;
 	
 	public AnimationClip sway; 	

	private float oneThird;

	// Use this for initialization
	void Start () {
		oneThird = Screen.width / 3;
		lastMove = 0;
		color = 0;
		playerMove = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0) {
			Touch Touch = Input.GetTouch(0);
			if(Touch.position.x < (Screen.width - oneThird * 2)) {
				playerMove = -1; //player goes to left
			} else if(Touch.position.x > (Screen.width - oneThird)) {
				playerMove = 1; //player goes to right
			} else {
				playerMove = 0; //player goes to center
			}
			Debug.Log ("LAST:" + lastMove + " | Current:" + playerMove);
				
			lastMove = playerMove;

		}
			
		if (Input.GetKeyDown ("q")) {
			playerMove = -1;
		} else if (Input.GetKeyDown("w")) {
			playerMove = 0;
		} else if (Input.GetKeyDown("e")) {
			playerMove = 1;
		}

		Debug.Log ("LAST:" + lastMove + " | Current:" + playerMove);

		float step = speed * Time.deltaTime;
		if(playerMove < 0) {
			Vector2 newPos = new Vector2 (-4, transform.position.y);
			transform.position = Vector2.MoveTowards (transform.position, newPos, step);
   //GetComponent<Animator> ().Play ("car_sway");
		} else if(playerMove > 0) {
			Vector2 newPos = new Vector2 (4, transform.position.y);
			transform.position = Vector2.MoveTowards (transform.position, newPos, step);
		} else {
			Vector2 newPos = new Vector2 (0, transform.position.y);	
			transform.position = Vector2.MoveTowards (transform.position, newPos, step);
		}
  		
	}

	public void colorSwap() {
		if (playerMove == lastMove) {
			//swap colors
			SpriteRenderer player = GetComponent<SpriteRenderer>();
			if (color == 0) {
				player.color = Color.black;
				color = 1;
			} else {
				player.color = Color.white;
				color = 0;
			}
		}

	}
}
