using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Maze.UI
{
    [Serializable]
    public class FillEvent : UnityEvent<float> {}

    public class FillElement : MonoBehaviour
    {
        
        [Header("Basic Config")]
        public Image image;
        
        public int minimun;
        public int maximun;

        [Space(15)]
        public FillEvent OnValueChanged = new FillEvent();
        
        private void Awake()
        {
            SetFilled();
        }

        #region Setters
        
        private void SetFilled()
        {
            image.type = Image.Type.Filled;
            image.fillMethod = Image.FillMethod.Radial360;
        }

        public void SetMaxAmount(float amount)
        {
            image.fillAmount = amount;
        }
        
        #endregion

        #region Getters

        public float GetCurrentFill()
        {
            return 0f;
        }

        #endregion

        public void OnPointerClick(PointerEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if(image)
                SetFilled();
        }
#endif
        
    }

   
}
