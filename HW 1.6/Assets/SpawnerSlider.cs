using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerSlider : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] TextMeshProUGUI _text;
    private Slider _slider;
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener((a) =>
       {
           _spawner.SetNumberOfSpawns((int)a);
           _text.text = $"Dummies: {(int)a}";
       });
    }
}
