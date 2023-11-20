using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    [Range(-1.0f, 1.0f)]
    private float background_movespeed = 0.1f;
    private Material background_imageMaterial;

    private void Awake()
    {
        background_imageMaterial = GetComponent<Renderer>().material;
    }
    void Update()
    {
        background_imageMaterial.SetTextureOffset("_MainTex", Vector2.right * background_movespeed * Time.time);
    }
}
