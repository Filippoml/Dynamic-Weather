using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    private float _colorTime, _intensityMoon, _intensitySun;
    public Gradient gradient;

    [SerializeField]
    private Clock _clock;

    [SerializeField]
    private Planet _sun, _moon;

    [SerializeField]
    private Light _mainLight;
   
    // Start is called before the first frame update
    void Start()
    {
        _intensityMoon = 0.1f;
        _intensitySun = 1.2f;
        //float test = RenderSettings.skybox.GetFloat("_SkyIntensity");

    }

    // Update is called once per frame
    void Update()
    {

        _colorTime = _clock.realMinutes / 1440f;
        Debug.Log(_colorTime);
        Camera.main.backgroundColor = RenderSettings.ambientLight = gradient.Evaluate(_colorTime);

        _mainLight.intensity = Mathf.Lerp(_intensityMoon, _intensitySun, _colorTime);
        RenderSettings.skybox.SetFloat("_SkyIntensity", _colorTime);
        RenderSettings.skybox.SetColor("_SkyColor2", Camera.main.backgroundColor);
        _sun.GetComponent<MeshRenderer>().material.color = Camera.main.backgroundColor;
        _sun.MoveToTarget(_colorTime);
    }
}
