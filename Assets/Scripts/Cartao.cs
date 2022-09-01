using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cartao : MonoBehaviour
{
    public int maxCelNumero = 59;

    private List<int> todosNumeros = new List<int>();

    private List<Celula> celula = new List<Celula>();
    private SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Sorteio>().drawn.AddListener(CheckMatch);

        celula = Transform.FindObjectsOfType<Celula>().ToList();
        celula = celula.OrderBy(c => c.transform.GetSiblingIndex()).ToList();

        //gera os numeros
        var numeros = Enumerable.Range(1, maxCelNumero).ToList();
        numeros = numeros.OrderBy(i => Guid.NewGuid()).ToList().GetRange(0, 15);

        //ordena
        todosNumeros = numeros.OrderBy(n => n).ToList();
        //distribui os numeros ordenados
        for (int i = 0; i < celula.Count; i++)
        {
            celula[i].Numero = todosNumeros[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void novoCartao()
    {
        celula = Transform.FindObjectsOfType<Celula>().ToList();
        celula = celula.OrderBy(c => c.transform.GetSiblingIndex()).ToList();

        //gera os numeros
        var numeros = Enumerable.Range(1, maxCelNumero).ToList();
        numeros = numeros.OrderBy(i => Guid.NewGuid()).ToList().GetRange(0, 15);

        //ordena
        todosNumeros = numeros.OrderBy(n => n).ToList();
        //distribui os numeros ordenados
        for (int i = 0; i < celula.Count; i++)
        {
            celula[i].Numero = todosNumeros[i];
        }
    }

    public void CheckMatch(int numero, int drawIndex)
    {
        if(celula.Any(c => c.Numero == numero))
        {
            var celAtual = celula.Find(c => c.Numero == numero);
            celAtual.meuTipo = TipoCel.X;
        }
    }
}
