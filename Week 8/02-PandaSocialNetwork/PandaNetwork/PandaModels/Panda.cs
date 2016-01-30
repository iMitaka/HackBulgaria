using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaNetwork
{
    [Serializable]
    public class Panda
    {
        private string name;
        private string email;
        private GenderType gender;

        public Panda(string name, string email, GenderType gender)
        {
            this.name = name;
            SetEmail(email);
            this.gender = gender;
        }

        public int Id { get; set; }

        private void SetEmail(string email)
        {
            if (email.Contains('@') && email.Contains('.'))
            {
                this.email = email;
                return;
            }

            throw new FormatException("Email is not valid!");
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
        }

        public bool IsMale
        {
            get
            {
                if (this.gender == GenderType.Male)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsFemale
        {
            get
            {
                if (this.gender == GenderType.Female)
                {
                    return true;
                }

                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("Panda name:{0}, Email:{1}, Gender:{2}", this.name, this.email, this.gender.ToString());
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 3 + this.name.GetHashCode();
                hash = hash * 3 + this.email.GetHashCode();
                hash = hash * 3 + this.gender.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Panda)
            {
                var otherPanda = obj as Panda;

                if (this.name == otherPanda.name && this.email == otherPanda.email && this.gender == otherPanda.gender)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
