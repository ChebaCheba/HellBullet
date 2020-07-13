using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject Enemy;
    private float xPos, yPos; 
    private int enemyCount;
    private float[,] spawnC;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        spawnC = new float[4,2] {{30f, 26f},{30f,-26f},{-30f, 26f},{-30f,-26f}};
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void subCount(){
        this.enemyCount--;
    }

    IEnumerator Spawn(){
        while(true){
            yield return new WaitForSeconds(5);
            if (enemyCount < 10){
                int temp = Random.Range(0,3);
                xPos = spawnC[temp,0];
                yPos = spawnC[temp,1];
                Instantiate<GameObject>(Enemy, new Vector3(xPos, yPos, 1), Quaternion.identity);
                enemyCount++;
            }
        }
    }
}
