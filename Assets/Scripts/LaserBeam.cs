using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
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

    IEnumerator Dissappear(){
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
