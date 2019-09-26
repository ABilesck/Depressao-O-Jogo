using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Rigidbody2D rb;
    public float VelocidadeDash;
    private float IntervaloDash;
    public float TempoDeDash;
    private int dir;

    // Start is called before the first frame update
    void Start()
    {
        IntervaloDash = TempoDeDash;
    }

    // Update is called once per frame
    void Update()
    {
        if(dir == 0)
        {
            dir = Convert.ToInt32(Input.GetAxisRaw("Horizontal"));
        }
        else if(IntervaloDash <= 0)
        {
            dir = 0;
        }
        else
        {
            IntervaloDash -= Time.deltaTime;

            if(dir > 0)
            {
                 
            }
        }
    }
}
