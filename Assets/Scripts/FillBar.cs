using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    [SerializeField] private  PlayerHealth playerHealth;

    private Image fillImage;

    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        float fillValue = playerHealth.NormalizedHeath;
        slider.value = fillValue;
        
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        
        if (slider.value >= slider.minValue && !fillImage.enabled)
            
        {
            fillImage.enabled =true;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
