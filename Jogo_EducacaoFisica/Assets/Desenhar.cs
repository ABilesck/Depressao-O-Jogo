using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desenhar : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector2.down, new Vector2(0, -3));
    }
}
