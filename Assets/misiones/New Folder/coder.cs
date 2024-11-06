using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coder : MonoBehaviour
{
    public enum Puzzle
    {
        A,
        B,
        C,
        D,
    }
    public Puzzle tipoPuzzle;
    private Renderer render;
    private Color color;
    private float time = 0f;
    private int coll = 0;
    private int coll1 = 0;
    private int coll2 = 0;

    public string numberCode = "";
    public string codigo = "1234";
    // Update is called once per frame

    private void Start()
    {
        Transform t = transform.Find("Capsule");
        if (t != null) render = t.GetComponent<Renderer>();
        color = render.material.color;
    }
    void Update()
    {
        if (render != null)
        {
            if (render.material.color != color && render.material.color != Color.green)
                if (tipoPuzzle == Puzzle.A) tiempo();
            if (numberCode == codigo) render.material.color = Color.green;
            if (numberCode != codigo && numberCode.Length >= codigo.Length) render.material.color = Color.red;
        }

    }
    private void tiempo()
    {
        time += Time.deltaTime;
        if (time >= 1.5f)
        {

            time = 0f;
            render.material.color = color;
            numberCode = "";
        }
    }
    public void addNumber(float number, Puzzle tipoPuzzle, int col = -1)
    {
        switch (tipoPuzzle)
        {
            case Puzzle.A:
                numberCode += number.ToString();
                break;
            case Puzzle.B:
                if (col == 0)
                {
                    coll += (int)number;
                    if (coll <0) coll = 9;
                }
                if (col == 1)
                {
                    coll1 += (int)number;
                    if (coll1 < 0) coll1 = 9;
                }
                if (col == 2)
                {
                    coll2 += (int)number;
                    if (coll2 < 0) coll2 = 9;
                }
                numberCode = coll.ToString() + coll1.ToString() + coll2.ToString();
                break;
        }
    }
}
