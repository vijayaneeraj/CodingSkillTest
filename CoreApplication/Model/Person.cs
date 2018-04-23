
using System.Collections.Generic;

namespace CoreApplication.Entity
{
        //Gender enum
        public enum GenderEnum { Female, Male };
        public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }

        public List<Pet> Pets { get; set; }

    }
}
