using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float TempoDeEspera = 0.3f;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            TempoDeEspera = 0.3f;
            effector.rotationalOffset = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(TempoDeEspera <= 0)
            {
                effector.rotationalOffset = 180;
                TempoDeEspera = 0.3f;
            }
            else
            {
                TempoDeEspera -= Time.deltaTime;
            }
        }
    }
}
