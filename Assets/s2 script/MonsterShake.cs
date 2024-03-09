using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening; //version 2
//using System; //version 2

public class MonsterShake : MonoBehaviour
{

    
       //version 1
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
    

    /*
    //version 2
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;

    private static event Action shake;

    public static void Invoke()
    {
        shake?.Invoke();
    }

    private void OnEnable() => shake += Shaker;
    private void OnDisable() => shake -= Shaker;

    private void Shaker()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(0.3f, position);
        _camera.DOShakeRotation(0.3f, rotation);

        //_camera.SetAutoKill(false);
        //_camera.DORestart();
    }
    */

}
