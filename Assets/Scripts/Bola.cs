using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {

    public float speed;


	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
	
    float hitfactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "racket")
        {
            float x = hitfactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }
    }

	// Update is called once per frame
	void Update () {
        

		
	}
}
