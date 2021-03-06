﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPower : MonoBehaviour {

    public static PushPower sharedInstance;
    public float sensitivity = 1000000;
    public float loudness = 0;
    AudioSource _audio;
    EnemyController[] enemigos;

    void Awake()
    {
        PushPower.sharedInstance = this;
    }
	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
        _audio.loop = true;
        _audio.mute = true;
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        while (!(Microphone.GetPosition(null) > 0)) { }
    }

    // Update is called once per frame
    void Update () {
        
        enemigos = GameObject.FindObjectsOfType<EnemyController>();
        loudness = GetAveragedVolume() * sensitivity;
        //Pushing();
    }

    float GetAveragedVolume()
    {
        
        
        _audio.Play();

        float[] data = new float[256];
        float a = 0;
        //_audio.GetOutputData(data, 0);
        _audio.GetSpectrumData(data, 0, FFTWindow.Triangle);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
            //Debug.Log(a);
        }
        return a/256;
    }

    private void Pushing()
    {
        
        
        foreach (EnemyController enemy in enemigos)
        {
            enemy.GetComponent<Rigidbody2D>().AddForce(((enemy.transform.position-transform.position)+new Vector3(0,5,0)) * (loudness / (enemy.transform.position - transform.position).sqrMagnitude) * 1000000, ForceMode2D.Impulse);
        }
    }
}
