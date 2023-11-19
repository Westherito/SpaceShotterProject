using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFatherController : MonoBehaviour
{

    [SerializeField] protected GameObject Morte;
    [SerializeField] protected float vel;
    [SerializeField] protected int lifeEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyLife(int dano)
    {
        lifeEnemy -= dano;
        if (lifeEnemy <= 0)
        {
            Destroy(gameObject);
            Instantiate(Morte, transform.position, transform.rotation);
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
            Instantiate(Morte, transform.position, transform.rotation);
        }
        // Destruindo com a parede 
        if (collision.CompareTag("Destruidor")) 
        {
            Destroy(gameObject);
            Instantiate(Morte, transform.position, transform.rotation);
        }
    }
}
