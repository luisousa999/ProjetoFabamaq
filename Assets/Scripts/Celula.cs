using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoCel
{
    Verm,Ama,X,Vazio
}

public class Celula : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private List<Sprite> allCelSprites = new List<Sprite>();
    private int _numero;
    private TipoCel _meuTipo;
    public TipoCel meuTipo
    {
        get 
        {
            return _meuTipo;
        }
        set 
        {
            _meuTipo = value;
            GetComponent<SpriteRenderer>().sprite = allCelSprites[(int)_meuTipo];
        }
    }

    // Vai colocar o numero dentro de cada celula
    public int Numero 
    {
        get => _numero;
        set
        {
            _numero = value;
            //_numero = value;
            GetComponentInChildren<TextMesh>().text = (_numero+1).ToString();
        }
    }


    // No start, loada todas as imagens ds cells; Do enum ele
    void Start()
    {
        Sprite[] celImag = Resources.LoadAll<Sprite>("Cartao/cell");
        allCelSprites.AddRange(celImag); //adiciona uma colec,cellImg, ao allCel
        meuTipo = TipoCel.Vazio;
    }

  

}
