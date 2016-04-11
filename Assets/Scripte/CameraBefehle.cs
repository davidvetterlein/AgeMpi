using UnityEngine;
using System.Collections;

public class CameraBefehle : MonoBehaviour {
    GameObject player;
    public float speed;
    public float speed2;

	// Use this for initialization
	void Start () {
        player = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (Input.GetKey("d"))
        {
            player.transform.position += new Vector3(speed, speed, player.transform.position.z) * speed2;
        }
        if (Input.GetKey("a"))
        {
            player.transform.position -= new Vector3(speed, speed, player.transform.position.z) * speed2;
        }

        if (Input.GetKey("s"))
        {
            player.transform.position += new Vector3(player.transform.position.x, speed, speed) * speed2;
        }
        if (Input.GetKey("w"))
        {
            player.transform.position -= new Vector3(player.transform.position.x, speed, speed) * speed2;
        }
        if(Input.GetKey("space"))
        {
            player.transform.position += new Vector3(speed, player.transform.position.y, speed) * speed2;
        }
        if (Input.GetKey("left shift"))
        {
            player.transform.position -= new Vector3(speed, player.transform.position.y, speed) * speed2;
        }


    }
}
