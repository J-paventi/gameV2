using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class PlayerDetails
    {
        private string name;
        private int level;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    name = "Player";
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Level { get => level; set => level = value; }

        public PlayerDetails()
        {
            name = "Player";
            level = 1;
        }
    }
}
