using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameFlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        int balCreditos = PlayerPrefs.GetInt("Creditos", 0);
        int balJogadas = PlayerPrefs.GetInt("Jogadas", 0);

        if (balCreditos > 0)
        {
            balCreditos -= 1;
            balJogadas += 1;

            PlayerPrefs.SetInt("Creditos", balCreditos);
            PlayerPrefs.SetInt("Jogadas", balJogadas);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
