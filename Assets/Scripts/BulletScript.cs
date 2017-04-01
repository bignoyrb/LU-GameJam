using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // lifetime of bullet in seconds
        int lifeTime = 1;
        Destroy(this.gameObject,(float)1.0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
