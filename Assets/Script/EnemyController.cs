using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Alterando a velocidade 
        rb.velocity = new Vector2 (0f, vel);
    }
}
