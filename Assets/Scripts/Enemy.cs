using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform mainShip;
    
    private Rigidbody2D rigidbody;
    private Vector2 move;
    private float speed = 3f;
    private int health;
    public GameObject laser; 
    public Transform l1;
    
    public GameObject ge;
    private GenerateEnemies script;
    // Start is called before the first frame update
    void Start()
    {
        ge = GameObject.Find("Spawn");
        script = ge.GetComponent<GenerateEnemies>();
        mainShip = GameObject.Find("fighter").transform;
        rigidbody = this.GetComponent<Rigidbody2D>();
        health = 5;
        StartCoroutine(Shoot());
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
    IEnumerator Shoot(){
        while(true){
            yield return new WaitForSeconds(1);
            Instantiate<GameObject>(laser, l1.position, l1.rotation);
        }
    }

    void MoveEnemy(Vector2 direction){
        rigidbody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8)
        {
            if(health<=0){
                script.subCount();
                Destroy(gameObject);
            } else {
                health -= 1;
            }
            
        }
    }
}
