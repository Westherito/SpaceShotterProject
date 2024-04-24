using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoBoss : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnBoss()
    {
        Instantiate(Boss, transform.position, transform.rotation);
        var father = transform.parent.gameObject;
        Destroy(father);
    }
}
