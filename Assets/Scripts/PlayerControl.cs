using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    public Rigidbody theRB;
    public float speed = 300f;
    private float side = 0;
    Vector3 pos;
    Touch touch;
    private void FixedUpdate()
    {


        pos = transform.localPosition;
        pos.x = Mathf.Clamp(transform.localPosition.x, -2f, 2f);
        transform.localPosition = pos;



       
         Move(side);


    }
    private void Update()
    {
        touch = Input.GetTouch(0);
        if (Input.touchCount > 0)
        {



            if (pos.x !=-2f && touch.position.x < Screen.width / 2 && touch.phase != TouchPhase.Ended )
            {
                side = -1f;
            }
            else if (pos.x !=2f && touch.position.x > Screen.width / 2 && touch.phase != TouchPhase.Ended)
            {
                side = 1f;
            }
            else
                side = 0f;


        }
        if (touch.phase == TouchPhase.Ended)
        {

            theRB.velocity = Vector3.zero;
            side = 0f;
        }


    }
    public void Move(float sidee)
    {
        
        float horiz = sidee;

        Vector3 direction = new Vector3(horiz, 0f, 0f).normalized;

        if (direction.magnitude >= 0.1f)
        {
            theRB.velocity = direction * speed * Time.deltaTime;
        }
        else
            theRB.velocity = Vector3.zero;




    }

}
