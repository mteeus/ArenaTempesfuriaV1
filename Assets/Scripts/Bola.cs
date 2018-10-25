using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {

    public float speed;


	// Use this for initialization
	void Start () {
	
		sorteio=Ramdom.Range(0,10); //mínimo e máximo do sorteio
sorteioY=Ramdom.Range(0.02f, -0.02f); //cima ou baixo

if (sorteio <5){ //se o número for menor que 5 a bola irá para a DIREITA
rigidbody2D.AddForce (new Vector2(0.05f, sorteioY));

//0.05f: força ao iniciar a bola no jogo, coordenadas X(horizontal- positivo pra direita, negativo pra esquerda) e Y(vertical).

} else { //se o número for maior que 5 a bola irá para a ESQUERDA
rigidbody2D.AddForce (new Vector2(-0.05f, sorteioY));
	

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
