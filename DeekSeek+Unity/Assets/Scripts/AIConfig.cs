using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AIConfig : ScriptableObject
{
    [Password]
    public string apiKey;
    public string modelName;
    public string apiUrl;
}
