using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Inimigo", menuName="Novo Inimigo")]
public class AssetInimigo : ScriptableObject
{
    public int ID;
    public int VidaMaxima;
    public float Velocidade;
    public int Poder;

}
