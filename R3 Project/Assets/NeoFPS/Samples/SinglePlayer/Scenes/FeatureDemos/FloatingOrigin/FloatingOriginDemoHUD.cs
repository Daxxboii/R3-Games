using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NeoFPS.Samples
{
    public class FloatingOriginDemoHUD : MonoBehaviour, IFloatingOriginSubscriber
    {
        [SerializeField, Tooltip("")]
        private Text m_OffsetText = null;

        void Start()
        {
            if (FloatingOrigin.system != null)
            {
                FloatingOrigin.system.AddSubscriber(this);
                ApplyOffset(FloatingOrigin.system.currentOffset);
            }
        }

        void OnDestroy()
        {
            if (FloatingOrigin.system != null)
                FloatingOrigin.system.RemoveSubscriber(this);
        }

        public void ApplyOffset(Vector3 offset)
        {
            Vector3 steps = FloatingOrigin.system.currentOffset / FloatingOrigin.system.threshold;
            int x = Mathf.RoundToInt(steps.x);
            int z = Mathf.RoundToInt(steps.z);
            m_OffsetText.text = string.Format("[{0}, {1}]", x, z);
        }
    }
}