using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itens
{

    public class ItemCollactableBase : MonoBehaviour
    {

        public SFXType sFXType;
        public ItemType itemType;

        [Header("Sounds")]
        public AudioSource audioSource;

        public string compareTag = "Player";
        public float timeToHide=3;
        public GameObject graphicItem;

        public Collider ColliderItem;

        private void Awake()
        {
            //if (particleSystem != null) particleSystem.transform.SetParent(null);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        private void PlaySFX()
        {
            SFXPool.Instance.Play(sFXType);
        }

        protected virtual void Collect() 
        {
            PlaySFX();
            if (ColliderItem != null) ColliderItem.enabled = false;
            OnCollect();
            if (graphicItem != null) graphicItem.SetActive(false);
            Invoke(nameof(HideObject), timeToHide);
        }
        private void HideObject()
        {
            gameObject.SetActive(false);
        }
        protected virtual void OnCollect() 
        {
        
            //VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.COIN, transform.position);
            if (audioSource != null) audioSource.Play();
            ItemManager.Instance.AddByType(itemType);
        }
    
        
    }

}