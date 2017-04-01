using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;    
	private Rigidbody2D rb2d;
    public Rigidbody2D projectile;

    void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

    void Update()
    {
        float bulletSpeed = 10;
        float shootHorizontal = Input.GetAxis("Fire1");
        float shootVertical = Input.GetAxis("Fire2");
        if (Mathf.Abs(shootHorizontal)>0.1 || Mathf.Abs(shootVertical)>0.1)
        {            
            Rigidbody2D instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
            // get normalized shooting direction
            Vector2 shootingDirection = new Vector2(shootHorizontal, shootVertical);
            shootingDirection.Normalize();
            instantiatedProjectile.velocity = shootingDirection*bulletSpeed;
        }
    }

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.velocity = movement*speed;
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{		
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
		}
	}
}
