using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbObj;
    [SerializeField] private float vel;
    [SerializeField] private GameObject explosao;
    private float timer = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        //Movimento do tiro para cima
        rbObj.velocity = Vector2.up * vel;
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Colisão com a parede invisível
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Colisão se algum objeto tiver o script descrito e utilizando as tags

        // Dano no inimigo
        if (collider.CompareTag("Inimigo01"))
        {
            collider.GetComponent<EnemyController>().EnemyLife(1);
        }
        // Dano no player
        if (collider.CompareTag("Jogador"))
        {
            collider.GetComponent<PlayerController>().PlayerLife(1);
        }
        // Destruindo os tiros
        Destroy(gameObject);
        Instantiate(explosao, transform.position, transform.rotation);
    }
}
