using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancoJog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int balJogadas = PlayerPrefs.GetInt("Jogadas", 0);
        GetComponent<TextMesh>().text = balJogadas.ToString();
    }

    void Update()
    {
        int balJogadas = PlayerPrefs.GetInt("Jogadas", 0);
        GetComponent<TextMesh>().text = balJogadas.ToString();
    }

    //public void AnotarSorteio()
    //{}
}
