using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRockStart : MonoBehaviour
{
    public List<Texture2D> RockTextures;

    private SpriteRenderer spriteRenderer;
    PolygonCollider2D polygonCollider;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        int randomIndex = UnityEngine.Random.Range(0, RockTextures.Count);
        spriteRenderer.sprite = Sprite.Create(RockTextures[randomIndex], new Rect(0, 0, RockTextures[randomIndex].width, RockTextures[randomIndex].height), new Vector2(0.5f, 0.5f));
        polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
        polygonCollider.isTrigger = true;
    }

}
