namespace ProjectEON.InventorySystem.UI
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using TMPro;

    public class UIInventoryTile : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private ItemBase _item;
        [SerializeField]
        private Image _itemImage;     
        private UIInventoryDescription _uiDescription;

        public bool IsEmpty { get; private set; } = true;
        public ItemBase Item { get { return _item; } }

        public void Init(UIInventoryDescription description)
        {
            _uiDescription = description;
            Debug.Log(description);
        }

        public void Fill(ItemBase item)
        {
            if (!IsEmpty) return;
            IsEmpty = false;
            _item = item;
            _itemImage.sprite = _item.ItemData.ItemSprite;
        }

        public void ResetTile()
        {
            _item = null;
            _itemImage.sprite = null;
            IsEmpty = true;
        }

        public void OnPointerClick(PointerEventData pointerData)
        {
            if (IsEmpty) return;

            if (pointerData.button == PointerEventData.InputButton.Right)
            {
                _item.Use();
                ResetTile();
                _uiDescription.ResetDescription();
            }
            else
            {
                _uiDescription.SetDescription(_item.ItemData.ItemSprite, _item.ItemData.ItemName, _item.ItemData.Type.ToString(), _item.ItemData.Description);
            }
        }
    }
}
