using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandoimBg : MonoBehaviour
{
    public Image bg;
    public Color[] backgroundColor;
    // Start is called before the first frame update
    void Start()
    {
        bg.color = backgroundColor[Random.Range(0, backgroundColor.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
