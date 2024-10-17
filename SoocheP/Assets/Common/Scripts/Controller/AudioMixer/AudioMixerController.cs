using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider[] sliders;

    // 슬라이더 값이 변경되면 호출할 함수
    // 파라미터로 슬라이더가 어떤 오디오를 조절하는지 받음
    public void ControllVolume(string audioType)
    {
        switch (audioType)
        {
            case "BGM":
                masterMixer.SetFloat("BGM", sliders[0].value);
                break;
        }
    }
}
