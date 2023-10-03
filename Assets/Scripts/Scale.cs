using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Scale : MonoBehaviour
{
    [SerializeField] float _sizeScale;
    Transform _playerTransform;

    Vector3 _scale;

    Vector3 scaleAmount = new Vector3(0.55f, 0.55f, 0.55f);

    public bool _downScale = true;

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
        transform.localScale = scaleAmount;

        _scale = _playerTransform.localScale;
    }

    public void scale(float sizeFactor)
     {
        // Obtenez la valeur actuelle de localScale
        Vector3 currentScale = transform.localScale;

        // Ajoutez le facteur à chaque composant de localScale
        currentScale.x += sizeFactor;
        currentScale.y += sizeFactor;
        currentScale.z += sizeFactor;

        // Réassignez la nouvelle valeur de localScale
        transform.localScale = currentScale;
        _scale = currentScale;

        if(!_downScale)
        {
            _downScale = true;
        }
    }

    public void downScale(float sizeFactor)
    {

        if (_scale.x >= 0.29f)
        {
            Vector3 currentScalDown = transform.localScale;

            currentScalDown.x -= sizeFactor;
            currentScalDown.y -= sizeFactor;
            currentScalDown.z -= sizeFactor;

            transform.localScale = currentScalDown;
            _scale = currentScalDown;
        }
        else
        {
            _downScale = false;
            Debug.Log("Impossible valeur trop basse");
        }
    }

    public void bigScale(float sizeFactor)
    {
        Vector3 currentScale = transform.localScale;

        currentScale.x += sizeFactor;
        currentScale.y += sizeFactor;
        currentScale.z += sizeFactor;

        transform.localScale = currentScale;
    }

    [Button] void ScaleUp() => scale(_sizeScale);
    [Button] void ResetScale() => Start();
}
