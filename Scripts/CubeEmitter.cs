using UnityEngine;
using System.Globalization;
using TMPro;

public class CubeEmitter : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab;

    [SerializeField]
    private TMP_InputField _timeField;
    [SerializeField]
    private TMP_InputField _speedField;
    [SerializeField]
    private TMP_InputField _distanceField;

    private float _cubeSpeed;
    private float _cubeDistance;
    private float _timeBetweenCubes;

    private float _actualCubeSpeed;
    private float _actualCubeDistance;
    private float _actualTimeBetweenCubes;

    private float _betweenCubesCounter;

    private void Awake()
    {
        _betweenCubesCounter = 0.0f;

        _cubeDistance = 0.0f;
        _cubeSpeed = 0.0f;
        _timeBetweenCubes = Mathf.Infinity;
        UpdateValues();
    }

    private void Update()
    {
        _betweenCubesCounter += Time.deltaTime;

        if (_betweenCubesCounter > _actualTimeBetweenCubes)
        {
            GameObject cube = Instantiate(_cubePrefab, Vector3.zero, Quaternion.identity);
            cube.GetComponent<Cube>().OnSpawn(_actualCubeSpeed, _actualCubeDistance);

            _betweenCubesCounter = 0.0f;
        }
    }

    public void ChangeCubeDistance(string cubeDistance)
    {
        if (!float.TryParse(cubeDistance, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out _cubeDistance) && _distanceField.text.Length > 0)
        {
            _distanceField.text = _distanceField.text.Remove(_distanceField.text.Length - 1);
        }
    }
    
    public void ChangeCubeSpeed(string cubeSpeed)
    {
        if (!float.TryParse(cubeSpeed, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out _cubeSpeed) && _speedField.text.Length > 0)
        {
            _speedField.text = _speedField.text.Remove(_speedField.text.Length - 1);
        }
    }

    public void ChangeTimeBetweenCubes(string timeBetween)
    {
        if (!float.TryParse(timeBetween, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out _timeBetweenCubes) && _timeField.text.Length > 0)
        {
            _timeField.text = _timeField.text.Remove(_timeField.text.Length - 1);
        }
    }

    public void UpdateValues()
    {
        _actualCubeDistance = _cubeDistance;
        _actualCubeSpeed = _cubeSpeed;
        _actualTimeBetweenCubes = _timeBetweenCubes;
    }
}
