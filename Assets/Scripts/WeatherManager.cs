using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    private float _colorTime, _intensityMoon, _intensitySun;
    public Gradient gradient;


    [SerializeField]
    private Light _mainLight;
   
    // Start is called before the first frame update
    void Start()
    {
        _intensityMoon = 0.1f;
        _intensitySun = 1.2f;
        RenderSettings.skybox.SetFloat("_SkyIntensity", 0);
        //float test = RenderSettings.skybox.GetFloat("_SkyIntensity");

    }

    // Update is called once per frame
    void Update()
    {
        _colorTime += Time.deltaTime * 0.01f;
        Camera.main.backgroundColor = RenderSettings.ambientLight = gradient.Evaluate(_colorTime);

        _mainLight.intensity = Mathf.Lerp(_intensityMoon, _intensitySun, _colorTime);
    }
}
