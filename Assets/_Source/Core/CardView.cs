using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Core
{
    public class CardView : MonoBehaviour
    {
        private CardInstance _cardInstance;
        
        public void Init(CardInstance cardInstance)
        {
            _cardInstance = cardInstance;
        }
        
        public CardInstance GetCardInstance()
        {
            return _cardInstance;
        }
    }
}
