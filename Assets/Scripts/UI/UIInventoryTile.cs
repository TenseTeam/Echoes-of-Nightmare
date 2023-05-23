namespace ProjectEON.UI.Inventory
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using TMPro;

    public class UIInventoryTile : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private BaseItemData data;
        [SerializeField]
        private Image itemImage;
        [SerializeField]
        private TMP_Text quantityText;
        public bool IsEmpty { get; private set; } = true;

        public void Fill(BaseItemData itemData)
        {
            if (!IsEmpty) return;
            IsEmpty = false;
            //data = itemData;
            //itemSprite.sprite = data.ItemSprite;
        }

        public void OnPointerClick(PointerEventData pointerData)
        {
            //if (pointerData.button == PointerEventData.InputButton.Right)
            //{
            //    OnRightMouseBtnClick?.Invoke(this);
            //    //Use()
            //}
            //else
            //{
            //    OnItemClicked?.Invoke(this);
            //    //Select();
            //    //
            //}
        }
    }
}
