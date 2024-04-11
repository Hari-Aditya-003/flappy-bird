using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnr : MonoBehaviour
{
   public GameObject prefab;

    public float Minheight = -1f;
    public float Maxheight = 1f;
    public float spawnrate = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnrate, spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(Minheight, Maxheight);
    }
}
