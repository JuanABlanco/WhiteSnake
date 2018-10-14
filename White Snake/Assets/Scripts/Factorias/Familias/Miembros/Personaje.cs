using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

    public int maxLife;
    public int currentLife;
    private string pName;
    public List<GameObject> invetario;
    public int baseDamage;
    public int currentDamage;

    public void Move() { }

    public void Spawn() { }

    public void Die() { }

    /* Como prerequisito de DropLoot debera estar en un if que observe si la lista drop no esta vacia
         
         */
    public void DropLoot()
    {
        if(this.invetario.Count != 0) { 
            int dropedIndex = Random.Range(0, this.invetario.Count - 1);
            if (this.invetario[dropedIndex].GetComponent<Objeto>().drop)
            {
                GameObject droped = this.invetario[dropedIndex];
                Instantiate(droped, transform.position, Quaternion.identity);
                this.invetario.RemoveAt(dropedIndex);
            }

        }


    }





}
