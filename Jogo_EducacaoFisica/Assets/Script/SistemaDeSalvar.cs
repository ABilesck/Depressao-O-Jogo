using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SistemaDeSalvar
{
    public static void SalvarJogador(JogadorStatus jogador)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string Path = Application.persistentDataPath + "/Player.fun";
        FileStream stream = new FileStream(Path, FileMode.Create);

        DadosJogador dados = new DadosJogador(jogador);

        formatter.Serialize(stream, dados);
        stream.Close();
    }

    public static DadosJogador CarregarDados()
    {
        string Path = Application.persistentDataPath + "/Player.fun";
        if (File.Exists(Path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Path, FileMode.Open);

            DadosJogador dados = formatter.Deserialize(stream) as DadosJogador;
            stream.Close();

            return dados;
        }
        else
        {
            Debug.LogError("Arquivo nao encontrado em: " + Path);
            return null;
        }
    }
}
