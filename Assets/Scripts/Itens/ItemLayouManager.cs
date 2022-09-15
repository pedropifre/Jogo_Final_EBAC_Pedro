using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itens
{

    public class ItemLayouManager : MonoBehaviour
    {

        public ItenLayout prefabLayout;
        public Transform container;

        public List<ItenLayout> itensLayouts;

        private void Start()
        {
            CreateItens();
        }
        private void CreateItens()
        {
            foreach (var setup in ItemManager.Instance.itemSetups)
            {
                var item = Instantiate(prefabLayout, container);
                item.Load(setup);
                itensLayouts.Add(item);
            }
        }
    }

}