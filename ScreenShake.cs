using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float StartPosX;
    private float StartPosY;
    public float Duration;
    public float Intensity;

    private float Elapsed;
    private float Min;
    private float Max;
    Vector3 target;
    private GameObject pl;
    void Start()
    {
        Cursor.visible = false;
        StartPosX = this.transform.position.x;
        StartPosY = this.transform.position.y;

        Min = -1.0f;
        Max = 1.0f;

        pl = GameObject.Find("Player");
    }

    public void shakeCamera()
    {
        StartCoroutine(shake(Duration, Intensity));
    }

    private IEnumerator shake(float Duration_,float Intensity_)
    {
        Elapsed = 0.0f;
        while (Elapsed < Duration)
        {
            target = new Vector3(Random.Range(Min, Max) * Intensity, Random.Range(Min, Max) * Intensity, gameObject.transform.position.z);
            gameObject.transform.localPosition = target;
            Elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame(); 
        }

        gameObject.transform.localPosition = new Vector3(StartPosX, StartPosY, gameObject.transform.position.z);
    }

    public void followPlayer()
    {
        float newX = pl.transform.position.x;
         gameObject.transform.localPosition = new Vector3(newX, gameObject.transform.position.y,gameObject.transform.position.z);

    }


    }

