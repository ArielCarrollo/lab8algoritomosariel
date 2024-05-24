using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partMapControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
