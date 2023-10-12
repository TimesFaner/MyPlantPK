using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace PlantPK
{
    public class Global : MonoBehaviour
    {
        public static BindableProperty<int> Days = new BindableProperty<int>(1);
    }
}
