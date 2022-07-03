using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector= new Vector3(10f,10f,10f);
    [SerializeField] float period = 2f;
    [Range(0, 1)] [SerializeField] float movementFactor;
    public bool isMove=false;
    public bool leftToRight = false;
    Vector3 startpos;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        pos = transform.localPosition;
        if (leftToRight)
        {
            movementVector.x = -movementVector.x;
            startpos = new Vector3(transform.position.x - transform.localPosition.x*2, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        
        Vector3 offset = movementFactor * movementVector;

        if (isMove)
        {
            transform.position = startpos + offset;
        }
        else
        {
            transform.position = startpos;
        }


    }
}
