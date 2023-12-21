// ---------------------------------------------
// ---------------------------------------------
// Creation Date: 2023-12-12
// Author: Testes Parada88 
// Project Name: junio 
// Description: 
// 
// ---------------------------------------------
// ---------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDetectClosest : MonoBehaviour
{
    public string tagToDetect = "Enemy";
    public GameObject[] allEnemies;
    public GameObject closestEnemy;

    public 
    // Start is called before the first frame update
    void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag(tagToDetect);
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = ClosestEnemy();
        closestEnemy.transform.position = Vector2.MoveTowards(closestEnemy.transform.position, this.transform.position, 10 * Time.deltaTime );
    }

    GameObject ClosestEnemy()
    {
        GameObject closestHere = gameObject;
        float leastDistance = Mathf.Infinity;

        foreach( var enemy in allEnemies )
        {
            float distanceHere = Vector3.Distance(transform.position, enemy.transform.position);
            if( distanceHere < leastDistance ) {
                leastDistance = distanceHere;
                closestHere = enemy;
            }
        }

        return closestHere;
    }
}
