using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFatherController : MonoBehaviour
{
    [SerializeField] protected AudioSource MorteFx;
    [SerializeField] protected GameObject Morte;
    [SerializeField] protected float vel;
    [SerializeField] protected int lifeEnemy;
    protected int ponto;
    [SerializeField] private GameObject powerUp;
    [SerializeField] protected GameObject Boss;
    [SerializeField] protected float dropItem;
    // Vida dos inimigos, checagem de dano e ganhando pontos
    public void EnemyLife(int dano)
    {
        if (transform.position.y < 5f)
        {
            lifeEnemy -= dano;
            if (lifeEnemy <= 0)
            {
                Destroy(gameObject);
                Instantiate(Morte, transform.position, transform.rotation);
                GeraPowerUp();
                var gerador = FindAnyObjectByType<GeradorInimigos>();
                gerador.GanhaPontos(ponto);
            }
        }
    }

    public void BossLife(int dano)
    {
        lifeEnemy -= dano;
        if (lifeEnemy <= 0)
        {
            MorteFx.Play();
            Destroy(Boss);
            Instantiate(Morte, transform.position, transform.rotation);
            var gerador = FindAnyObjectByType<GeradorInimigos>();
            if (gerador)
            {
                gerador.GanhaPontos(ponto);
            }
        }
    }
    // Evento que funciona quando o objeto é destruido
    private void OnDestroy()
    {
        var gerador = FindAnyObjectByType<GeradorInimigos>();
        if (gerador)
        {
            gerador.DiminuiQte();
        }
    }
    // Gerando Power ups para o player
    public void GeraPowerUp()
    {
        // calculando chance de drop
        float chance = Random.Range(0f, 1f);
        if (chance > 0.9f) // 10% de chance de gerar o item
        {
            GameObject criaPowerUp = Instantiate(powerUp, transform.position, transform.rotation);
            var dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            criaPowerUp.GetComponent<Rigidbody2D>().velocity = dir;
            Destroy(criaPowerUp, 3f);
        }
    }
    // Destruindo os Inimigos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destruindo com o player e causando dano
        if (collision.CompareTag("Jogador"))
        {
            if (gameObject == Boss)
            {
                collision.GetComponent<PlayerController>().PlayerLife(1000);
            }
            else
            {
                collision.GetComponent<PlayerController>().PlayerLife(1);
                Destroy(gameObject);
                Instantiate(Morte, transform.position, transform.rotation);
                GeraPowerUp();
            }

        }
        // Destruindo com a parede 
        if (collision.CompareTag("Destruidor"))
        {
            if (!gameObject == Boss)
            {
                Destroy(gameObject);
                Instantiate(Morte, transform.position, transform.rotation);
            }
        }
    }
}
