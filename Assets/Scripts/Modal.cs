using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Modal : MonoBehaviour
{
    [SerializeField] private FloatReactiveProperty _rotate = new FloatReactiveProperty();

    public IReadOnlyReactiveProperty<float> Rotate => _rotate;
}