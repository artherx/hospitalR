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
    public GameObject[] Luz;
    private Color color;
    private float time = 0f;
    private int coll = 0;
    private int coll1 = 0;
    private int coll2 = 0;
    public bool isCode = false;

    public string numberCode = "";
    public string codigo = "1234";
    // Update is called once per frame
    private void Start()
    {
        foreach (GameObject g in Luz) g.SetActive(false);
    }

    void Update()
    {
        if (Luz != null)
        {
            if (Luz[1])
                if (tipoPuzzle == Puzzle.A) tiempo();
            if (numberCode == codigo) { Luz[0].SetActive(true); isCode = true; }
            if (numberCode != codigo && numberCode.Length >= codigo.Length) Luz[1].SetActive(true);
        }

    }
    private void tiempo()
    {
        time += Time.deltaTime;
        if (time >= 1.5f)
        {

            time = 0f;
            Luz[0].SetActive(false);
            Luz[1].SetActive(false);
            numberCode = "";
        }
    }
    public void addNumber(float number, Puzzle tipoPuzzle, int col = -1)
    {
        switch (tipoPuzzle)
        {
            case Puzzle.A:
                if (numberCode != codigo) numberCode += number.ToString();
                break;
            case Puzzle.B:
                if (numberCode != codigo)
                {

                    if (col == 0)
                    {
                        coll += (int)number;
                        if (coll < 0) coll = 9;
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
                }
                break;
        }
    }
}
