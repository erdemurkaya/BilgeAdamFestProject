using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Enums
{
    public enum Gender
    {
        Male = 1, Female, None

    }

    public class GenderClass
    {

        private Dictionary<Gender, string> genderDict = new Dictionary<Gender, string>
    {
        {Gender.Male,"Erkek" },
        {Gender.Female,"Kadın" },
        {Gender.None,"Belirtmek İstemiyorum" }
    };


    }

}
