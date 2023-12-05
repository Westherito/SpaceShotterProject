using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private string estado = "estado1";
    [SerializeField] private float vel = 2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    private float limiteX, limiteY;
    private bool dir = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado) 
        {
            case "estado1" :
                Estado1();
                break;
            case "estado2":
                Estado2();
                break;
            case "estado3":
                Estado3();
                break;
        }
    }

    private void Estado1()
    {
        
        // mudando a direção do boss direita e esquerda
        limiteX = 7.342f;
        if (dir == true)
        {
            rb.velocity = new Vector2(vel, 0f);

        }
        else
        {
            rb.velocity = new Vector2(-vel, 0f);

        }
        // var de controle para o boss
        if (transform.position.x >= limiteX)
        {
            dir = false;
        }
        if (transform.position.x <= -limiteX)
        {
            dir = true;
        }

    }
    private void Estado2()
    {

    }
    private void Estado3()
    {

    }
}
