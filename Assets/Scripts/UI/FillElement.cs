using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Maze.UI
{
    [Serializable]
    public class FillEvent : UnityEvent<float> {}

    public class FillElement : MonoBehaviour, IPointerEnterHandler
    {
        [Header("Basic Config")]
        public Image image;
        
        public int minAmount = 0;
        public int maxAmount = 100;
        
        public bool CanRestore { get; set; }
        [field: SerializeField] public bool AutoRestore { get; set; }
        [field: SerializeField] public bool AutoReduce { get; set; }
        
        [Header("Auto Restore")]
        [SerializeField] private float timeToIncrease;
        [SerializeField] private float recoveryAmount;
        [SerializeField] private float timeToStartRecover;
        
        [Space(15)]
        public FillEvent onValueChanged = new FillEvent();
        
        private float _currentAmount;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetFilled();
            SetMaxAmount(maxAmount);
        }

        private void Update()
        {
            if(AutoReduce)
                DecreaseAmount();
        }

        public void UseFillAmount(float amount)
        {
            float trueValue = _currentAmount - Mathf.Abs(amount);

            if (trueValue >= 0)
            {
                _currentAmount = Mathf.Clamp(_currentAmount, minAmount, maxAmount);
            
                if(AutoRestore)
                    RestoreAmount();
            
                onValueChanged?.Invoke(_currentAmount);
            }
        }
        public void RestoreAmount()
        {
            if(CanRestore)
                StartCoroutine(ERestore());
        }
        public void DecreaseAmount()
        {
            UseFillAmount(recoveryAmount);
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
            return _currentAmount;
        }

        #endregion

        #region Intefaces

        public void OnPointerEnter(PointerEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);

        }

        #endregion

        #region Coroutines

        private IEnumerator ERestore()
        {

            while (_currentAmount < maxAmount)
            {
                
            }
            
            
            onValueChanged?.Invoke(_currentAmount);

            yield return null;
        }

        #endregion
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if(image)
                SetFilled();
        }
#endif

        
    }

   
}
