using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private int speed;
    private float h, v;
    private bool click;
    public GameObject laser; 
    public Transform l1, l2;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        FaceMouse();
    }

    void MoveShip(){
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        click = Input.GetMouseButtonDown(0);

        transform.Translate(h * Time.deltaTime * speed, 0, 0, Space.World);
        transform.Translate(0, v * Time.deltaTime * speed, 0, Space.World);

        if(click){
            Shoot();
        }   
    }

    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(
                mousePos.x - transform.position.x,
                mousePos.y - transform.position.y
        );
        transform.up = direction;
    }

    void Shoot(){
        Instantiate<GameObject>(laser, l1.position, l1.rotation);
        Instantiate<GameObject>(laser, l2.position, l2.rotation);
    }
}
