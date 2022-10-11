using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cloth
{

    public class ClothItemStrong : ClothItemBase
    {
        public float changeDamageMultiply = .5f;
        public override void Collect()
        {
            base.Collect();
            Player.Instance.healthBase.ChangeDamageMultiply(changeDamageMultiply, duration);

        }
    }

}
