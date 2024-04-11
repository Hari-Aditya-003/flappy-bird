using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationspeed = 1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationspeed * Time.deltaTime, 0);
    }
}
