using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DrawnEvent : UnityEvent<int, int> // numero da bola e o draw Ind
{

}


public class Sorteio : MonoBehaviour
{
    public DrawnEvent drawn;
    
    
    public float drawSpeed = 0.05f;
    public int nmroMaxBolas = 30;
    
    private int maxBolas = 30;
    private List<int> todosNumeros = new List<int>();
    private int drawIndex = 0;
    private SpriteRenderer myRenderer;
    private List<Sprite> todosSpriteNumeros = new List<Sprite>();

    private bool canDraw = true;
    private float lastDraw;


    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        Sprite[] ballImages = Resources.LoadAll<Sprite>("Bolas/ballsBig");
        todosSpriteNumeros.AddRange(ballImages);

        var numeros = Enumerable.Range(0, nmroMaxBolas).ToList();
        todosNumeros = numeros.OrderBy(i => Guid.NewGuid()).ToList().GetRange(0, maxBolas);
    }

    // Update is called once per frame
    void Update()
    {
        if(canDraw)
        {
            if(Time.time - lastDraw > drawSpeed)
            {
                DrawBola();
                lastDraw = Time.time;
            }
        }
    }

    private void DrawBola()
    {
        if (drawIndex >= maxBolas) return; //cancela ciclo
        myRenderer.color = Color.white;
        myRenderer.sprite = todosSpriteNumeros[todosNumeros[drawIndex]];
        drawn.Invoke(todosNumeros[drawIndex], drawIndex);
        drawIndex++;
    }

    //public void OutroSorteio()
    //{
    //    myRenderer = GetComponent<SpriteRenderer>();
    //    Sprite[] ballImages = Resources.LoadAll<Sprite>("Bolas/ballsBig");
    //    todosSpriteNumeros.AddRange(ballImages);

    //    var numeros = Enumerable.Range(0, nmroMaxBolas).ToList();
    //    todosNumeros = numeros.OrderBy(i => Guid.NewGuid()).ToList().GetRange(0, maxBolas);
    //}
}
