using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParticleTrigger : MonoBehaviour
{
    private ParticleSystem ps;

    private List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    // Start is called before the first frame update
    void Awake()
    {
        ps = GetComponent<ParticleSystem>(); 
        
    }

    private void Start()
    {
        ps.trigger.SetCollider(0, GameObject.FindGameObjectWithTag("Enemy").GetComponent<CapsuleCollider>());
    }

    private void OnParticleTrigger()
    {
        
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        Debug.Log(numEnter);
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            Debug.Log("YO YO YO");
            enter[i] = p;
        }
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}
