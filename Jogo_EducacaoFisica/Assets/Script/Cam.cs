using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform Jogador;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Jogador.position.x + offset.x,
            Jogador.position.y + offset.y,
            Jogador.position.z + offset.z);
    }
}
