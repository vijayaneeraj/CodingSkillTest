using System;
using System.Collections.Generic;

namespace CoreApplication.Entity
{
    public enum PetTypeEnum { Dog, Cat, Fish };
    public class Pet
    {
        public string Name { get; set; }
        public PetTypeEnum Type { get; set; }

    }
}
