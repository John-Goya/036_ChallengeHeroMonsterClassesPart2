using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart2
{
    public partial class Default_HeroMonsterClass2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            hero.Name = "Jedi";
            hero.Health = 40;
            hero.DamageMaximum = 10;
            hero.AttackBonus = true;

            Character monster = new Character();
            monster.Name = "Rancor";
            monster.Health = 20;
            monster.DamageMaximum = 20;
            monster.AttackBonus = false;

            Dice die = new Dice();

            if (hero.AttackBonus)
                monster.Defend(hero.Attack(die));
            if (monster.AttackBonus)
                hero.Defend(monster.Attack(die));

            while (hero.Health > 0 && monster.Health > 0)
            {
                monster.Defend(hero.Attack(die));
                hero.Defend(monster.Attack(die));
                statsOut(hero);
                statsOut(monster);
            }

            displayResult(hero, monster);

            //int damage = hero.Attack(dice);
            //monster.Defend(damage);

            //damage = monster.Attack(dice);
            //hero.Defend(damage);
            ///int monsterDamage = monster.Attack();

            //statsLabel.Text = String.Format("{0} - {1} - {2} - {3}", hero.Name, hero.Health, hero.DamageMaximum, hero.AttackBonus);
            //monsterStatsLabel.Text = String.Format("{0} - {1} - {2} - {3}", monster.Name, monster.Health, monster.DamageMaximum, monster.AttackBonus);
            //statsOut(hero);
            //statsOut(monster);
        }
        private void displayResult(Character character1, Character character2)
        {
            if (character1.Health <= 0 && character2.Health <= 0)
                statsLabel.Text += String.Format("<p>Both {0} and {1} have died.</p>", character1.Name, character2.Name);
            else if (character1.Health >= 0)
                statsLabel.Text += String.Format("<p>{0} has defeated the {1}.</p>", character1.Name, character2.Name);
            else
                statsLabel.Text += String.Format("<p>{0} has defeated the {1}.</p>", character2.Name, character1.Name);
        }
        private void statsOut(Character character)
        {
            statsLabel.Text += String.Format("Name: {0} -- Health: {1} -- Damage: {2} -- AttackBonus: {3}</br>",
                character.Name, character.Health,
                character.DamageMaximum, character.AttackBonus);
        }

    }
    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice die) //randomly determine the amount of damage this Character object inflicted.
        {
            //Random random = new Random();
            //int damage = random.Next(DamageMaximum);
            die.Sides = this.DamageMaximum;
            return die.Roll();
        }

        public int Defend(int damage) //deducts the damage from this Character's health
        {

            Health -= damage;
            //damage = DamageMaximum; 
            /*
            monster.Health -= heroDamage;
            hero.Health -= monsterDamage;
            return 0;
            */
            return 0;
        }
    }

    // new class for dice (random roll)
    class Dice
    {
        public int Sides { get; set; }

        Random randomRollDamage = new Random();

        public int Roll()
        {
            return randomRollDamage.Next(Sides);
        }

    }
    /*
    internal class random
    {
        internal static int Next(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
    */
}