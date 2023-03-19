using System;
using UnityEngine;
public class UIInventory : MonoBehaviour
{ 
        [SerializeField] private InventoryItemInfo _appleInfo;
        [SerializeField] private InventoryItemInfo _pepperInfo;

        [Header("Visibility")]
        [SerializeField] private bool _isVisible;
        public InventoryWithSlots inventory => tester.inventory;

        private UIInventoryTester tester;
        private void Awake()
        {
                var uiSlots = GetComponentsInChildren<UIInventorySlot>();
                tester = new UIInventoryTester(_appleInfo, _pepperInfo, uiSlots);
                tester.FillSlots();

                _isVisible = true;
                gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
                if (Input.GetKey(KeyCode.F))
                {
                        SwitchVisible();
                }   
        }
        void SwitchVisible()
        {
                //_isVisible = !_isVisible;
                gameObject.SetActive(_isVisible);
        }
}
