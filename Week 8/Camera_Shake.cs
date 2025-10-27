using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    public static Camera_Shake instance;
    private CinemachineCamera _camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _camera = GetComponent<CinemachineCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CamShake( float _strength, float _time)
    {
        CinemachineBasicMultiChannelPerlin _noise= _camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.AmplitudeGain = _strength;
        yield return new WaitForSeconds( _time );
        _noise.AmplitudeGain = 0;
        // for this to work have your Frequency grain set to 1
    }


}
