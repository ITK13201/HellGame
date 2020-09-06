using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] Sound=new AudioClip[6];
    private AudioSource audioSource;
    public bool stream = false;

    public int num2=0;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(Sound[0]);
        audioSource.Stop();

    }

    // Update is called once per frame

    public void BGM(int num)
    {
        num2 = num; ;
        audioSource.Stop();
        audioSource.PlayOneShot(Sound[num]);
    }
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
