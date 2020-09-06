using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] Sound=new AudioClip[6];
    private AudioSource audioSource;

    public int num2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    
    public void BGM(int num)
    {
        num2 = num; ;
        audioSource.Stop();
        audioSource.PlayOneShot(Sound[num]);
    }
    public bool stream = false;
    public void st1(){
        num2 = 1; ;
        audioSource.Stop();
        audioSource.PlayOneShot(Sound[1]);
        stream = true;
    }
    public void st2()
    {
        num2 = 2; ;
        audioSource.Stop();
        audioSource.PlayOneShot(Sound[2]);
        stream = false;
    }


}
