using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float vel;

    [SerializeField]private GameObject enemyBullet;

    private float timerBullet = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Alterando a velocidade 
        rb.velocity = new Vector2 (0f, vel);
        //instanciando tiros com delay
        timerBullet -= Time.deltaTime;
        if (timerBullet < 0f){
            Instantiate(enemyBullet, transform.position, transform.rotation);

            timerBullet = 1f;
        }
    }
}
