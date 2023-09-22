using Lab3_QueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_QueryBuilder
{
    internal class Pokemon : IClassModel
    {
        public int Id { get; set; }
        public int DexNumber { get; set; }
        public string Name { get; set; }
        public string Form { get; set; } = string.Empty;
        public string Type1 { get; set; }
        public string Type2 { get; set; } = string.Empty;
        public int Total { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }

        public Pokemon()
        {

        }


        public Pokemon(int id, int DexNum, string name, string form, string type1, string type2, int totalStats, int hp, int attack, 
            int defense, int spAttack, int spDefense, int speed, int genNum)
        {
            Id = id;
            DexNumber = DexNum;
            Name = name;
            Form = form;
            Type1 = type1;
            Type2 = type2;
            Total = totalStats;
            Hp = hp;
            Attack = attack;
            Defense = defense;
            SpecialAttack = spAttack;
            SpecialDefense = spDefense;
            Speed = speed;
            Generation = genNum;
        }
        

        public override string ToString()
        {
            if(Type2 == " ")
            {
                return $"{Id}: {Name} the {Type1} type";
            }
            else
            {
                return $"{Id}: {Name} the {Type1} and {Type2} type";
            }
        }



    }
}
