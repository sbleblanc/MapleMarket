using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

//earring / earrings
//overall armor/overall
//Shoes/jump/speed
//knuckler/knuckle

namespace MapleMarket.Converters
{
    class CategoryIdToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                    return "One-Handed Swords";
                case 1:
                    return "Two-Handed Swords";
                case 2:
                    return "One-Handed Axes";
                case 3:
                    return "One-Handed Blunt Weapons";
                case 4:
                    return "Two-Handed Axes";
                case 5:
                    return "Two-Handed Blunt Weapons";
                case 6:
                    return "Spears";
                case 7:
                    return "Polearms";
                case 8:
                    return "Wands";
                case 9:
                    return "Staves";
                case 10:
                    return "Bows";
                case 11:
                    return "Crossbows";
                case 12:
                    return "Claws";
                case 13:
                    return "Daggers";
                case 14:
                    return "Knucklers";
                case 15:
                    return "Guns";
                case 16:
                    return "Hats - Common";
                case 17:
                    return "Capes - Common";
                case 18:
                    return "Topwear - Common";
                case 19:
                    return "Gloves - Common";
                case 20:
                    return "Bottomwear - Common";
                case 21:
                    return "Overalls - Common";
                case 22:
                    return "Shields - Common";
                case 23:
                    return "Shoes - Common";
                case 24:
                    return "Hats - Warrior";
                case 25:
                    return "Topwear - Warrior";
                case 26:
                    return "Gloves - Warrior";
                case 27:
                    return "Bottomwear - Common";
                case 28:
                    return "Overalls - Warrior";
                case 29:
                    return "Shields - Warrior";
                case 30:
                    return "Shoes - Warrior";
                case 31:
                    return "Hats - Magician";
                case 32:
                    return "Topwear - Magician";
                case 33:
                    return "Gloves - Magician";
                case 34:
                    return "Bottomwear - Magician";
                case 35:
                    return "Overall - Magician";
                case 36:
                    return "Shields - Magician";
                case 37:
                    return "Shoes - Magician";
                case 38:
                    return "Hats - Bowman";
                case 39:
                    return "Topwear - Bowman";
                case 40:
                    return "Gloves - Bowman";
                case 41:
                    return "Bottomwear - Bowman";
                case 42:
                    return "Overalls - Bowman";
                case 43:
                    return "Shoes - Bowman";
                case 44:
                    return "Hats - Thief";
                case 45:
                    return "Topwear - Thief";
                case 46:
                    return "Gloves - Thief";
                case 47:
                    return "Bottomwear - Thief";
                case 48:
                    return "Overall - Thief";
                case 49:
                    return "Shields - Thief";
                case 50:
                    return "Shoes - Thief";
                case 51:
                    return "Hats - Pirate";
                case 52:
                    return "Gloves - Pirate";
                case 53:
                    return "Overalls - Pirate";
                case 54:
                    return "Shoes - Pirate";
                case 55:
                    return "Earrings - Common";
                case 56:
                    return "Eye Accessories";
                case 57:
                    return "Face Accessories";
                case 58:
                    return "Pendants";
                case 59:
                    return "Rings";
                case 60:
                    return "Potions";
                case 61:
                    return "Return Scrolls";
                case 62:
                    return "Useables";
                case 63:
                    return "Summoning";
                case 64:
                    return "Transforming";
                case 65:
                    return "Skill Books";
                case 66:
                    return "Scrolls - Helmet";
                case 67:
                    return "Scrolls - Others";
                case 68:
                    return "Scrolls - Face Accessories";
                case 69:
                    return "Scrolls - Eye Accessories";
                case 70:
                    return "Scrolls - Earrings";
                case 71:
                    return "Scrolls - Topwear";
                case 72:
                    return "Scrolls - Overalls";
                case 73:
                    return "Scrolls - Bottomwear";
                case 74:
                    return "Scrolls - Shoes";
                case 77:
                    return "Scrolls - Gloves";
                case 78:
                    return "Scrolls - Shields";
                case 79:
                    return "Scrolls - Capes";
                case 80:
                    return "Scrolls - One-Handed Swords";
                case 81:
                    return "Scrolls - One-Handed Axes";
                case 82:
                    return "Scrolls - One-Handed Blunt Weapons";
                case 83:
                    return "Scrolls - Dagger";
                case 84:
                    return "Scrolls - Wands";
                case 85:
                    return "Scrolls - Staff";
                case 86: // + 87
                    return "Scrolls - Two-Handed Sword";
                case 88: // +89
                    return "Scrolls - Two-Handed Axes";
                case 90: //+91
                    return "Scrolls - Two-Handed Blunt Weapons";
                case 92:
                    return "Scrolls - Spears";
                case 93: // +94
                    return "Scrolls - PoleArms";
                case 95:
                    return "Scrolls - Bows";
                case 96:
                    return "Scrolls - Crossbows";
                case 97:
                    return "Scrolls - Claws";
                case 98: //+99
                    return "Scrolls - Knucklers";
                case 100:
                    return "Scrolls - Guns";
                case 102:
                    return "Scrolls - Pet Equips";
                case 104:
                    return "Arrows";
                case 105:
                    return "Throwing Stars";
                case 106:
                    return "Bullets";
                case 107:
                    return "Others";
                default:
                    return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
