using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberA : MonoBehaviour
{
    private coder co;
    public int columna=0;
    
    public int number=0;
    // Start is called before the first frame update
    private void Start() {
        co = GetComponentInParent<coder>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "dedo"){
            Debug.Log("entro");
            switch(co.tipoPuzzle){
                case coder.Puzzle.A:
                    co.addNumber(number,co.tipoPuzzle);
                    break;
                case coder.Puzzle.B:
                    
                    co.addNumber(number,co.tipoPuzzle, columna);
                    break;
            }
            
        }
    }
}
