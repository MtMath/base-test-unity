using System;
using System.Timers;
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
        
        [Space(15)]
        public FillEvent onValueChanged = new FillEvent();
        
        private float _currentAmount;
        private Timer _timer;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetFilled();
            SetMaxAmount(maxAmount);
            RestoreAmount();
            
            if(AutoReduce)
                DecreaseAmount();
        }
        public void UseFillAmount(float amount)
        {
            float trueValue = _currentAmount - amount;
            
            if (trueValue >= 0)
            {
                _currentAmount = GetCurrentFill();
            
                if(AutoRestore)
                    RestoreAmount();

                CanRestore = true;
                onValueChanged?.Invoke(_currentAmount);
            }
        }
        public void RestoreAmount()
        {
            if (_currentAmount >= maxAmount)
            {
                Debug.LogWarning("Fill Amount is Full");
                CanRestore = false;
                return;
            }
            
            CreateTimer(TimerOnElapsedRestore);
        }
        public void DecreaseAmount()
        {
            if (_timer == null)
                CreateTimer(TimerOnElapsedReduce);
            else
                AddTimerEvent(TimerOnElapsedReduce);
        }
        private void CreateTimer(Action timerOnElapsed = null)
        {
            _timer = new Timer(timeToIncrease * 1000);
            _timer.Start();
            
            _timer.Elapsed += (sender, args) => timerOnElapsed?.Invoke();
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
            return _currentAmount = Mathf.Clamp(_currentAmount, minAmount, maxAmount);;
        }

        #endregion

        #region Intefaces

        public void OnPointerEnter(PointerEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        #endregion

        #region Events

        public void AddTimerEvent(Action onTimerElapsed)
        {
            _timer.Elapsed += (sender, args) => onTimerElapsed?.Invoke();
        }
        
        private void TimerOnElapsedRestore()
        {
            if (CanRestore && _currentAmount < maxAmount)
            {
                UseFillAmount(recoveryAmount);
            }
            else
            {
                _timer.Stop();
                _timer.Dispose();
            }
            
        }

        private void TimerOnElapsedReduce()
        {
            UseFillAmount(-recoveryAmount);
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