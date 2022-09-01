using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancoCred : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            //PlayerPref class que guarda prefs entre sessoes
        //Retorna o val correspondente à key (creditos), se não houver Int com o nome retorna 0
        int balCreditos = PlayerPrefs.GetInt("Creditos", 10);
        GetComponent<TextMesh>().text = balCreditos.ToString();
    }

    public void PagarSorteio()
    {
        int balCreditos = PlayerPrefs.GetInt("Creditos", 0);
        int balJogadas = PlayerPrefs.GetInt("Jogadas", 0);

        if(balCreditos > 0)
        {
            balCreditos -= 1;
            balJogadas += 1;
            //STARTGAME
        }

        // SetInt(NomeDaKey,Valor)
        PlayerPrefs.SetInt("Creditos", balCreditos); 
        PlayerPrefs.SetInt("Jogadas", balJogadas); 

        //GetComponent<TextMesh>().text = balCreditos.ToString();
        //GetComponent<TextMesh>().text = balJogadas.ToString();
    }

    public void CreditsIn()
    {
        int balCreditos = PlayerPrefs.GetInt("Creditos");
        balCreditos += 1;
        PlayerPrefs.SetInt("Creditos", balCreditos); // SetInt(NomeDaKey,Valor)
        GetComponent<TextMesh>().text = balCreditos.ToString();
    }

    public void CreditsOut()
    {
        int balCreditos = PlayerPrefs.GetInt("Creditos");
        balCreditos = 0;
        PlayerPrefs.SetInt("Creditos", balCreditos); // SetInt(NomeDaKey,Valor)
        GetComponent<TextMesh>().text = balCreditos.ToString();
    }
}
