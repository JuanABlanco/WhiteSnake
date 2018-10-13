using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

    public int maxLife;
    public int currentLife;
    public float maxSpeed;
    public float currentSpeed;
    private string pName;
    public List<Objeto> invetario;
    public int baseDamage;
    public int currentDamage;

    public void Move() { }

    public void Spawn() { }

    public void Die() { }

    /* Como prerequisito de DropLoot debera estar en un if que observe si la lista drop no esta vacia
         
         */
    public Objeto DropLoot()
    {
        int dropedIndex = Random.Range(0, this.invetario.Count - 1);
        Objeto droped = new Objeto(this.invetario[dropedIndex]);
        
        return droped;
    }





    
}
