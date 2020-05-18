using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace spirit.Chan
{

    public class PlayerCamera : MonoBehaviour
    {
        private Transform ts = null;

        [SerializeField] private Transform firstView = null;
        [SerializeField] private Transform thirdView = null;

        private void Awake()
        {
            ts = transform;
            SetCameraView(Manager.Data.gameData.isFirstView);
        }

        public void SetCameraView(bool isFirstView)
        {
            Manager.Data.gameData.isFirstView = isFirstView;
            ts.position = isFirstView ? firstView.position : thirdView.position;
            ts.rotation = isFirstView ? firstView.rotation : thirdView.rotation;
            ts.localScale = isFirstView ? firstView.localScale : thirdView.localScale;
        }
    }

}