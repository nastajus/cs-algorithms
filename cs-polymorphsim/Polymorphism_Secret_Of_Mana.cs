using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_polymorphsim
{
    class Polymorphism_Secret_Of_Mana
    {
        //mvp implement basic attack dry run, obviously without any visual interface.
        //emulate a sequence of actions

        //battle regular enemy
        //sale
        //
    }

    interface ITradable { }

    /**
     * Randi, Purim, and Popoi : IPlayable, IFightable, IMerchant, IAutomatic
     *
     * IPlayable
     *      Move(Direction)
     *      Press(Button) ~~ umm
     *
     * IFightable
     *      Attack( ~~ whom ? ~~ Collision ??? umm )
     *      Defend Chance ( ~~ property ~~ )
     *
     * IAutomatic
     *      
     *
     *
     * Purim, Popoi : IMagical
     *      Cast(TSpell)
     *      int MP;
     *
     * Undine, Gnome, Salamando, Syphlid, Luna, Lumina, Shade, Dryad : IElemental
     *      ... ? anything ? ...
     *
     * Fire Gigas, Spikey Tiger, Wall Face : IBoss 
     *      Reward(TRewardable~~ == e.g. Orb, ManaSeed)
     *      StoryAdvancement ~~
     *
     * Green Slime, Goblin    : IUnderling
     * Nitro Pumpkin, Spectre
     * Chest
     *      Drops(IConsumable)
     *      GivesExperience(int, ? whom ? )
     *      GivesMoney
     *
     * Candy, Chocolate, Royal Jam, Cup of Wishes, Herb : IConsumable
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
     *      Level -- property [enum --> references various things ... ]
     *
     *
     * Gaia's Navel, Dwarf Village, Gold City : .... dictionary items as strings... affects prices.. ?
     *
     */
}
