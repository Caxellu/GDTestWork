using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    [SerializeField] private Text waveText;

    private void Awake()
    {
        SceneManager.Instance.EventStartWave += UpdateWaveNumber;
    }
    private void UpdateWaveNumber(int current, int max)
    {
        waveText.text = current + "/" + max;
    }
}
