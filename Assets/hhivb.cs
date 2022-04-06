using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hhivb : MonoBehaviour
{
    [SerializeField] private CharacterController m_mychara;
    void Start()
    {
        m_mychara = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
