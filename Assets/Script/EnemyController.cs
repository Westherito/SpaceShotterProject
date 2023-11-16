using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyFatherController
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject enemyBullet;

    private float timerBullet = 1f;
    private float velTiro = -5f;

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
        // Verificando se a sprite est� visivel na tela
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
            var enemyTiro = Instantiate(enemyBullet, posTiro.position, posTiro.rotation);
            enemyTiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velTiro);
            // Intervalos de tiros
            timerBullet = Random.Range(1f, 1.5f);
        }
    }
}
