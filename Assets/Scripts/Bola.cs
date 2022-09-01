using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private int myIndex;
    private int myNumber;

    private SpriteRenderer myRenderer;
    private List<Sprite> todosNumeros = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {

        Sprite[] ballImages = Resources.LoadAll<Sprite>("Bolas/ballsSmall");
        todosNumeros.AddRange(ballImages);

        myRenderer = GetComponent<SpriteRenderer>();
        myIndex = transform.GetSiblingIndex();

       FindObjectOfType<Sorteio>().drawn.AddListener(CheckShow);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckShow(int numero, int drawIndex)
    {
        if(drawIndex == myIndex)
        {
            myRenderer.sprite = todosNumeros[numero];
            myRenderer.color = Color.white;
        }
    }
}
