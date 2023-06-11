using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private float amplitude = 20f;
    [SerializeField] private float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ringing()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(Swinging());
    }

    public void StopRinging(float speed)
    {
        StartCoroutine(RingFade(speed));
    }

    IEnumerator Swinging()
    {
        float startTime = Time.time;
        while (true)
        {
            float xAngle = Mathf.Sin((Time.time - startTime) * speed) * amplitude;
            transform.rotation = Quaternion.Euler(xAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            yield return null;
        }
    }

    IEnumerator RingFade(float speed)
    {
        GetComponent<AudioSource>().volume = 1f;
        while (GetComponent<AudioSource>().volume > 0.01)
        {
           GetComponent<AudioSource>().volume -= Time.deltaTime * speed;
            yield return null;
        }
        GetComponent<AudioSource>().volume = 0f;

    }
}
