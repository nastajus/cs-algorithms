using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cs_expando_object.somtxt
{
    class SomTxtRdr
    {
        enum State { Weapon, Enemy, Spell, Equipment, Randi, Purim, Popoi, BossWeapon, Shop }

        //https://stackoverflow.com/questions/4938397/dynamically-adding-properties-to-an-expandoobject

        public static IDictionary<string, Object> data = new ExpandoObject() as IDictionary<string, Object>;

        private static State _state;

        public static void Init()
        {
            dynamic building = new ExpandoObject();  //stop compiler whining

            StreamReader r = File.OpenText(Path.Combine(Environment.CurrentDirectory, "somtxt/sombl.txt"));
            string line;

            while ((line = r.ReadLine()) != null)
            {
                //change parsing mode
                switch (line)
                {
                    case "--- Weapons ---":
                        _state = State.Weapon;
                        //data.Add(_state.ToString(), new List<dynamic>());
                        continue;
                    case "--- Enemies ---":
                        _state = State.Enemy;
                        continue;
                    case "--- Spells ---":
                        _state = State.Spell;
                        continue;
                    case "--- Equipment ---":
                        _state = State.Equipment;
                        continue;
                    case "--- Man stats ---":
                        _state = State.Randi;
                        continue;
                    case "--- Woman stats ---":
                        _state = State.Purim;
                        continue;
                    case "--- Child stats ---":
                        _state = State.Popoi;
                        continue;
                    case "--- Boss weapons ---":
                        goto next;
                    case "--- Shops ---":
                        goto next;

                }

                //perform actual parsing
                switch (_state)
                {
                    case State.Weapon:
                        var parts = line.Split(new string[] {": "}, StringSplitOptions.None);
                        if (parts[0] == string.Empty)
                        {
                            //completed. put in dictionary
                            //data[building]
                            int foo;
                        }
                        else if (parts.Length == 1)
                        {
                            building = new ExpandoObject();
                            building.Name = parts;
                        }
                        else
                        {
                            //if (data[parts[0]] == null)
                            //if (data.Contains(parts[0]) == null)
                            if (!data.TryGetValue(parts[0], out var item))
                            {
                                building.Add(_state.ToString(), string.Empty);
                            }
                            building.Add(parts[0], parts[1]);
                        }
                        break;
                }
                //data.Add();
            }
            next:
            Console.Read();
        }
    }
}
