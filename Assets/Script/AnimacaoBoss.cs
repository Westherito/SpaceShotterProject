using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoBoss : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    private void SpawnBoss()
    {
        Instantiate(Boss, transform.position, transform.rotation);
        var father = transform.parent.gameObject;
        Destroy(father);
    }
}
