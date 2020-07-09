using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class WeatherManager : MonoBehaviour
{
    private float _colorTime, _intensityMoon, _intensitySun;
    public Gradient gradientSky;
    public Gradient gradientSun;

    public ParticleSystem _rain, _snow, cloud1, cloud2;

    [SerializeField]
    private Clock _clock;

    [SerializeField]
    public Planet _sun, _moon;

    [SerializeField]
    private Light _mainLight;

    [SerializeField]
    private AnimationCurve _lightCurve;
    
    // Start is called before the first frame update
    void Start()
    {
        _intensityMoon = 0.1f;
        _intensitySun = 1.2f;

        _rain.Stop();
        _snow.Stop();

        //float test = RenderSettings.skybox.GetFloat("_SkyIntensity");

        InvokeRepeating("RandomEvent", 0, 1f);
    }

    void RandomEvent()
    {                    

        if(Random.Range(0,100) < 5)
        {
            if (_rain.IsAlive() || _snow.IsAlive())
            {
                Burst burst = cloud1.emission.GetBurst(0);
                burst.maxCount = 10;
                cloud1.emission.SetBurst(0, burst);
                cloud2.emission.SetBurst(0, burst);
                _snow.Stop();
                _rain.Stop();
                Debug.Log("rain stop");
            }
            else
            {
                Burst burst = cloud1.emission.GetBurst(0);
                burst.maxCount = 30;
                cloud1.emission.SetBurst(0, burst);
                cloud2.emission.SetBurst(0, burst);

                if (Random.Range(0, 100) < 90)
                {
                    _rain.Play();
                    Debug.Log("rain");
                }
                else
                {
                    Debug.Log("snow");
                    _snow.Play();
                }
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_clock.realMinutes == 0)
        {
            _sun.Up = true;
        }
        _colorTime = _clock.realMinutes / 1440f;

       
        //Debug.Log(_clock.realMinutes / 1440f);
        Camera.main.backgroundColor = RenderSettings.ambientLight = gradientSky.Evaluate(_sun.Value);

        _mainLight.intensity = _lightCurve.Evaluate(_sun.Value);
        RenderSettings.skybox.SetFloat("_SkyIntensity", _mainLight.intensity);
        RenderSettings.skybox.SetColor("_SkyColor2", Camera.main.backgroundColor);
        _sun.GetComponent<MeshRenderer>().material.color = gradientSun.Evaluate(_sun.Value);
        _sun.MoveToTarget(_colorTime, true);
        _moon.MoveToTarget(_colorTime, false);

    }
}
