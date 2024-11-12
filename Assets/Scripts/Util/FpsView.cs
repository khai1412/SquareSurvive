using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FpsView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private void OnValidate()
    {
        text=GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(Time.frameCount%60==0)
        {
            text.SetText(((int)(1.0f / Time.deltaTime)).ToString());
        }

    }
}
