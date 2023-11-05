using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundCollection : MonoBehaviour
{
    public static SoundCollection instance;

    public AudioClip[] Clip;

    public AudioSource SourceSfx;

    public AudioSource SourceBgm;

    public AudioClip[] Bgms;

    public AudioClip[] VoiceOver;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if(scene.name == "MainMenu")
        {
            SoundCollection.instance.ChangeAndPlayBgm(0);
        }
        else if (scene.name == "Game2_0")
        {
            SoundCollection.instance.ChangeAndPlayBgm(1);
        }
        else if(scene.name == "Game3_0")
        {
            SoundCollection.instance.ChangeAndPlayBgm(2);
        }

        CheckStoryScenesAndPlayVoiceOver(scene);
    }

    public void CallSfx(int id)
    {
        SourceSfx.PlayOneShot(Clip[id]);
    }

    public void ChangeAndPlayBgm(int id)
    {
        SourceBgm.clip = Bgms[id];
        SourceBgm.Play();
        SourceBgm.loop = true;
    }

    public void StopBgm()
    {
        SourceBgm.Stop();
    }

    public void PlayVoiceOver(int id)
    {
        SourceBgm.clip = VoiceOver[id];
        SourceBgm.Play();
        SourceBgm.loop = false;
    }

    public void CheckStoryScenesAndPlayVoiceOver(Scene scene)
    {
        if (scene.name == "Game1_0")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(0);
        }

        if (scene.name == "Game1_1")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(1);
        }

        if (scene.name == "Game1_2")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(2);
        }

        if (scene.name == "Game1_3")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(3);
        }

        if (scene.name == "Game1_4")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(4);
        }

        if (scene.name == "Game1_5")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(5);
        }

        if (scene.name == "Game1_6")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(6);
        }

        if (scene.name == "Game1_7")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(7);
        }

        if (scene.name == "Game1_8")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(8);
        }

        if (scene.name == "Game1_9")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(9);
        }

        if (scene.name == "Game1_10")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(10);
        }

        if (scene.name == "Game1_11")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(11);
        }

        if (scene.name == "Game1_12")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(12);
        }

        if (scene.name == "Game1_13")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(13);
        }

        if (scene.name == "Game1_14")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(14);
        }

        if (scene.name == "Game1_15")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(15);
        }

        if (scene.name == "Game1_16")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(16);
        }

        if (scene.name == "Game1_17")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(17);
        }

        if (scene.name == "Game1_18")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(18);
        }

        if (scene.name == "Game1_19")
        {
            SoundCollection.instance.StopBgm();
            SoundCollection.instance.PlayVoiceOver(19);
        }
    }
}
