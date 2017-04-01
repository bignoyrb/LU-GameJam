using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public Transform player;
    private Rigidbody2D rb2d;
    public float movementSpeed;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Vector3 myPosition = rb2d.transform.position;
        Vector3 playerPosition = player.position;
        Vector2 movement = new Vector2(playerPosition.x - myPosition.x, playerPosition.y - myPosition.y);
        rb2d.velocity = movement * movementSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PlayerBullet")) 
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
