using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Core
{
    public class CardInstance
    {
        private CardAsset _cardAsset;

        public int LayoutId { get; set; } = 0;
        
        public int CardPosition { get; set; } = 0;

        public CardInstance(CardAsset cardAsset)
        {
            _cardAsset = cardAsset;
        }

        public CardAsset GetCardAsset()
        {
            return _cardAsset;
        }

        public void MoveToLayout(int layoutId)
        {
            LayoutId = layoutId;
        }
    }
}
