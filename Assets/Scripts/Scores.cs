using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Scores : MonoBehaviour
{
    [SerializeField] int _coinCount;
    [SerializeField] int _coinsCountMultipl;
    [SerializeField] TMP_Text _scoreMultipl;
    [SerializeField] TMP_Text _score;

    [SerializeField] float _bigScale;

    private void Update()
    {
        if (_coinsCountMultipl == 4)
        {
            GameObject _player = GameObject.Find("Player");
            Scale scale = _player.GetComponent<Scale>();

            scale.bigScale(_bigScale);

            _coinsCountMultipl = 0;
            _scoreMultipl.text = _coinsCountMultipl.ToString();
        }
    }

    public void ScoreUp(int value)
    {
        _coinCount += value;
        _score.text = _coinCount.ToString();

        _coinsCountMultipl += value;
        _scoreMultipl.text = _coinsCountMultipl.ToString();
    }
}
