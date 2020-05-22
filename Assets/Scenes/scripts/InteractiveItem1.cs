using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

    public class InteractiveItem1 : MonoBehaviour
    {
        private VRInteractiveItem m_InteractiveItem;
        public int image=0;

        private void Awake()
        {
            m_InteractiveItem = GetComponent<VRInteractiveItem>();
        }
        private void OnEnable()
        {
            m_InteractiveItem.OnOver+=HandleOver;
            m_InteractiveItem.OnOut+=HandleOut;
        }

        private void OnDisable()
        {
            m_InteractiveItem.OnOver-=HandleOver;
            m_InteractiveItem.OnOut+=HandleOut;
        }

        private void HandleOver()
        {
            image = 1;
        }

        private void HandleOut()
        {
            image = 0;
        }

    }
