using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float vel;

    [SerializeField] private GameObject enemyBullet;

    private float timerBullet = 1f;
    private int lifeEnemy = 3;

    [SerializeField] private Transform posTiro;
    // Start is called before the first frame update
    void Start()
    {
        timerBullet = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyTiros();
    }

    public void EnemyLife(int dano)
    {
        lifeEnemy -= dano;
        if (lifeEnemy <= 0)
        {
            Destroy(gameObject);
        }
        // Testando a colisão
        //Debug.Log(lifeEnemy + " de vida do Inimigo!");
    }

    private void EnemyTiros()
    {
        // Verificando se a sprite está visivel na tela
        bool visible = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visible)
        {
            //Alterando a velocidade 
            rb.velocity = new Vector2(0f, vel);
            //instanciando tiros com delay
            timerBullet -= Time.deltaTime;
            if (timerBullet < 0f)
            {
                Instantiate(enemyBullet, posTiro.position, transform.rotation);

                timerBullet = Random.Range(1.5f, 2f);
            }
        }
    }
}
