using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NorskaLib.UI
{
    public abstract class Bar : MonoBehaviour
    {
        public abstract void FillImmediate(float fill);

        public abstract void FillAnimated(float fill, float duration = 0.3f, float delay = 0.0f);
    }
}
