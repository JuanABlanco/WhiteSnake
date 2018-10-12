using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

    public int maxLife;
    public int currentLife;
    public float maxSpeed;
    public float currentSpeed;
    private string pName;
    public List<GameObject> invetario;
    public int baseDamage;
    public int currentDamage;


    public void Move() { }

    public void Spawn() { }

    public void Die() { }


    public GameObject DropLoot()
    {
        GameObject droped = null;
        if (this.invetario[0] != null) { 
            int dropedIndex = Random.Range(0, this.invetario.Count - 1);
            droped = Instantiate(this.invetario[dropedIndex], transform.position, Quaternion.identity) as GameObject;
            this.invetario.RemoveAt(dropedIndex);
        }
        return droped;
    }




    
}
