using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorComponent : MonoBehaviour
{
    protected Actor actor;
    private void Awake()
    {
        this.actor = this.GetComponent<Actor>();
    }
}
