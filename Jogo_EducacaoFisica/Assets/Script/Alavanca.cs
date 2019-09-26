using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{
    public bool Ativado;
    public SpriteRenderer SpriteRenderer;
    public Sprite SpriteAtivado;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Interagir") && !Ativado)
        {
            Ativado = true;
            SpriteRenderer.sprite = SpriteAtivado;
        }
    }
}
