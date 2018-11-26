using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Creditos : MonoBehaviour {
    public float scrollSpeed = 20;

    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);

        pos += localVectorUp * scrollSpeed * Time.deltaTime;

        transform.position = pos;
    }

    public void Reinicio()
    {
        SceneManager.LoadScene(0);
    }

}
