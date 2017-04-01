using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;    
	private Rigidbody2D rb2d;
    public Rigidbody2D projectile;
    private float lastShotTime;

    void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
        lastShotTime = Time.time;
	}

    void Update()
    {
        double firingTime = 1.0;        
        float shootHorizontal = Input.GetAxis("Fire1");
        float shootVertical = Input.GetAxis("Fire2");

        if (Mathf.Abs(shootHorizontal)>0.1 || Mathf.Abs(shootVertical)>0.1)
        {
            if (Time.time > (firingTime + lastShotTime))
            {
                // get normalized shooting direction
                Vector2 shootingDirection = new Vector2(shootHorizontal, shootVertical);
                shootingDirection.Normalize();
                Fire(shootingDirection);
                lastShotTime = Time.time;
            }
        }
    }
    void Fire(Vector2 shootingDirection)
    {
        float bulletSpeed = 10;
        Rigidbody2D instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
        instantiatedProjectile.velocity = shootingDirection * bulletSpeed;
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
		//if (other.gameObject.CompareTag ("PickUp")) 
		//{
		//	other.gameObject.SetActive (false);
		//}
	}
}
