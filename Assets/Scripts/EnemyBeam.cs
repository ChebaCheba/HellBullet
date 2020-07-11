using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeam : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    private Vector2 move;
    void Start()
    {
        speed = 15.0f;
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * speed, ForceMode2D.Impulse);
        StartCoroutine(Dissappear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Dissappear(){
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
