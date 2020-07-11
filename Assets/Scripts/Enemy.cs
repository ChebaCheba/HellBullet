using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform mainShip;
    private Rigidbody2D rigidbody;
    private Vector2 move;
    private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        mainShip = GameObject.Find("fighter").transform;
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = mainShip.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
        direction.Normalize();
        move = direction;   
    }

    void FixedUpdate(){
        MoveEnemy(move);
    }

    void MoveEnemy(Vector2 direction){
        rigidbody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
