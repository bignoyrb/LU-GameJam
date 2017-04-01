using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;    
	private Rigidbody2D rb2d;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Rigidbody2D projectile;
    private float lastShotTime;

    void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastShotTime = Time.time;
	}

    void Update()
    {
        double firingTime = 0.3;        
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
        // direction: 0->idle, 1->down, 2->right, 3->up, 4->left
        int direction;
        int previousDirection = animator.GetInteger("Direction");
        if (moveHorizontal == 0 && moveVertical == 0)
            direction = 0;
        else if (Mathf.Abs(moveHorizontal) > Mathf.Abs(moveVertical))
        {
            if (moveHorizontal > 0)           
                direction = 2;
            
            else
                direction = 4;
        }
        else
        {
            if (moveVertical > 0)
                direction = 3;
            else
                direction = 1;
        }
        if (direction == 2)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
        animator.SetInteger("PreviousDirection", previousDirection);
        animator.SetInteger("Direction",direction);        
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{		
		if (other.gameObject.CompareTag ("Enemy")) 
		{            
			// remove heart & flash player & make invincible for 2 seconds
		}
	}
}
