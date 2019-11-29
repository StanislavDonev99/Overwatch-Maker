using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Overwatch_Maker.Models
{
    public class HeroMetaData
    {
        [Display(Name ="Weapon")]
        public int WeaponID { get; set; }

        [Display(Name = "Ability")]
        public int AbilityID { get; set; }

    }

    [MetadataType(typeof(HeroMetaData))]
    public partial class Hero
    {

    }
}