using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    public float TempoParaDestruir;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TempoParaDestruir);
    }
}
