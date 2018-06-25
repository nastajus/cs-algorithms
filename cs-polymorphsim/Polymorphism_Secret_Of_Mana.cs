using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_polymorphsim
{
    class Polymorphism_Secret_Of_Mana
    {
    }

    /**
     * Randi, Purim, and Popoi : IPlayable, IFightable, IMerchant
     *
     * IPlayable
     *      Move(Direction)
     *      Press(Button) ~~ umm
     *
     * IFightable
     *      Attack( ~~ whom ? ~~ Collision ??? umm )
     *      Defend Chance ( ~~ property ~~ )
     *
     *
     *
     * Purim, Popoi : IMagical
     *      Cast(TSpell)
     *      int MP;
     *
     * Fire Gigas, Spikey Tiger, Wall Face : IBoss 
     *      Reward(TRewardable~~ == e.g. Orb, ManaSeed)
     *      StoryAdvancement ~~
     *
     * Green Slime, Goblin    : IUnderling
     * Nitro Pumpkin, Spectre
     * Chest
     *      Drops(
     *      GivesExperience(int, ? whom ? )
     *      GivesMoney
     *
     * Jema : INPC
     *     Talk();
     *
     * Neko, Shopkeeper : INPC, IMerchant
     *      Talk(TWords)
     *      Buy(TTradable)
     *      Sell(TTradable)
     *
     * Neko : IOverpriced
     *      { something that doubles all TTradable costs }
     *
     * Watts : IForge
     *      Upgrade(TWeapon)
     *
     * Sword, Spear, Boomerang, Javalin, Whip, Axe, Knuckles, Bow & Arrow : IWeapons
     *      Attack(IFightable)
     *
     *
     */
}
