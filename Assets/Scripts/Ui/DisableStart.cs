using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableStart : MonoBehaviour
{
    [SerializeField]GameObject m_thisGameObject;

    private void Awake()
    {
        m_thisGameObject.SetActive(false);
    }
}
