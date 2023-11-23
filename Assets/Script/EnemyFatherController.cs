using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFatherController : MonoBehaviour
{

    [SerializeField] protected GameObject Morte;
    [SerializeField] protected float vel;
    [SerializeField] protected int lifeEnemy;
    [SerializeField] protected int ponto;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // Vida dos inimigos e checagem de dano
    public void EnemyLife(int dano)
    {
        if (transform.position.y < 5f)
        {
            lifeEnemy -= dano;
            if (lifeEnemy <= 0)
            {
                Destroy(gameObject);
                Instantiate(Morte, transform.position, transform.rotation);

                var gerador = FindAnyObjectByType<GeradorInimigos>();
                gerador.DiminuiQte();
                gerador.GanhaPontos(ponto);
            }
        }
    }
    // Destruindo os Inimigos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destruindo com o player e causando dano
        if (collision.CompareTag("Jogador"))
        {
            collision.GetComponent<PlayerController>().PlayerLife(1);
            Destroy(gameObject);
            var gerador = FindAnyObjectByType<GeradorInimigos>();
            gerador.DiminuiQte();
            Instantiate(Morte, transform.position, transform.rotation);
        }
        // Destruindo com a parede 
        if (collision.CompareTag("Destruidor"))
        {
            Destroy(gameObject);
            var gerador = FindAnyObjectByType<GeradorInimigos>();
            gerador.DiminuiQte();
            Instantiate(Morte, transform.position, transform.rotation);
        }
    }
}
