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
     * Randi, Purim, and Popoi : IPlayable, IFightable, IMerchant, ??IEquiappable??, IMoveable,  IAutomaticFight, IAutomaticFollow
     *
     * IPlayable
     *      Move(Direction)
     *      Press(Button) ~~ umm
     *
     * IFightable
     *      Attack( ~~ whom ? ~~ Collision ??? umm )
     *      Defend Chance ( ~~ property ~~ )
     *      BeHit (int damage)
     *      prop int HP { get; set; } --- umm... where should responsibility for damage reside? i suppose that depends on SoM's algorithms...
     *      https://gamefaqs.gamespot.com/boards/588646-secret-of-mana/69777977
     *          Rabite's defpower all cases = 0 * 0 / 80 = 0
     *      https://gist.github.com/alexbevi/2953220
     *          data is derivable from this table
     *          search for "---" for Weapons, Enemies, etc. ---
     *
     *
     * IMoveable
     *      prop Vector2 (f, f) position ... umm.. { get; set; } ... others can move you! ha! it's okay in an interface! 
     *
     * ??Equiappable??
     *      ~~ a weapon is "equippable" ~~...
     *      ~~ a head gear is "equippable" ~~...
     *      ~~ a armor is "equippable" ~~...
     *      ~~ a wristband is "equippable" ~~...
     *      but is this really an interface ???
     *
     *      on second thought.... characters need rules to follow certain types...
     *      but this clearly needs more thought...
     *      like Randy can where heavy armor, or the other two can wear lighter armor, or the girl can where the Tiger Bikini...
     *
     *
     * IAutomaticFight
     *      
     *
     *
     *
     * Purim, Popoi : IMagical
     *      Cast(TSpell)
     *      int MP;
     *
     * Undine, Gnome, Salamando, Syphlid, Luna, Lumina, Shade, Dryad : Elemental
     *      Animate() //lol sigh
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
     * Candy, Chocolate, Royal Jam, Cup of Wishes, Herb, Faerie Walnut, Barrel, Magic Rope, Midge Mallet, Flammie Drum : IConsumable
     *      Midge Mallet, Magic Rope, Flammie Drum --- override Consumable(false);
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
     * -----
     * low-lev implementation details
     *
     *
     * Gaia's Navel, Dwarf Village, Gold City : .... dictionary items as strings... affects prices.. ?
     *
     * Force, Agility, Constitution, Intelligence, Wisdom, Attack, %Hit, Defense, %Evade, MagicDef: Status fields...
     *
     * algorithms for attacking, defending, ... all the above...
     *
     *
     * Attack, Guard, Approach, Keep Away
     *
     *
     * Slow, Tangled, Sleep, Freeze, Petrify, Confuse, Stop, Mini, Barrel, Transform, Moogle, Poison, Burning : enum StatusEffects
     *
     */
}
