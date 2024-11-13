using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    private void OnValidate()
    {
        this.sr = this.GetComponent<SpriteRenderer>();
    }
    public void SetColor(Color color)
    {
        sr.color = color;
    }
}
