using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleMessageTrigger : MonoBehaviour
{
    [SerializeField] [TextArea] string _text;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(_text);
    }
}
