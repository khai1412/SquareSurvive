using UnityEngine;
[CreateAssetMenu]
public class GameConfigSO : ScriptableObject
{
    public string basePath;
    public float   initialSpeed =1;
    public Color[] colors;
}
