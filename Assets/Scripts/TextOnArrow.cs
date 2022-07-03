using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnArrow : MonoBehaviour
{
    public Text text;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.WorldToScreenPoint(transform.position);
        text.transform.position = pos;
    }
}
