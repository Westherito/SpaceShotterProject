using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyFatherController
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject enemyBullet;

    private float timerBullet = 1f;

    [SerializeField] private Transform posTiro;
    // Start is called before the first frame update
    void Start()
    {
        timerBullet = Random.Range(0.5f, 2f);
    }
    // Update is called once per frame
    void Update()
    {
        EnemyMov();
    }
    private void EnemyMov()
    {
        // Verificando se a sprite está visivel na tela
        bool visible = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visible)
        {
            // lterando a velocidade 
            rb.velocity = new Vector2(0f, vel);
            // Metodo de tiros
            EnemyTiros();

        }
    }
    private void EnemyTiros() {
        //instanciando tiros com delay
        timerBullet -= Time.deltaTime;
        if (timerBullet < 0f)
        {
            Instantiate(enemyBullet, posTiro.position, posTiro.rotation);

            timerBullet = Random.Range(1.5f, 2f);
        }
    }
}
