namespace ProjectEON.InventorySystem.UI
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIInventoryDescription : MonoBehaviour
    {
        [SerializeField] 
        private Image _itemImage;
        [SerializeField] 
        private TMP_Text _title;
        [SerializeField] 
        private TMP_Text _type;
        [SerializeField] 
        private TMP_Text _description;

        private void Awake()
        {
            ResetDescription();
        }

        public void ResetDescription()
        {
            _itemImage.enabled = false;
            _title.text = "";
            _type.text = "";
            _description.text = "";
        }

        public void SetDescription(Sprite sprite, string itemTitle, string itemType, string itemDescription)
        {
            _itemImage.enabled = true;
            _itemImage.sprite = sprite;
            _title.text = itemTitle;
            _type.text = itemType;
            _description.text = itemDescription;
        }
    }
}
