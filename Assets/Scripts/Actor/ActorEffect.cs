using DG.Tweening;
using MidiPlayerTK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorEffect : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    private Color yellow = new Color(255, 255, 0, 0);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Glow();
        MidiController.Instant.PlayNext();
    }

    private void Glow()
    {
        sr.DOKill();
        sr.color = yellow;
        sr.DOFade(1, 0.1f).SetLoops(2, LoopType.Yoyo);
    }
}
