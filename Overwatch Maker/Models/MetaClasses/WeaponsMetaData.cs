using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Overwatch_Maker.Models
{
    public class WeaponsMetaData
    {
        
        [StringLength(50)]
        public string Name { get; set; }

        [Range(0, 100)]
        public Nullable<byte> Ammo { get; set; }

        [Range(0, 10)]
        [Display(Name="Reload Time")]
        public Nullable<double> ReloadTime { get; set; }

        [Range(0, 500)]
        [Display(Name = "Damage/Heal")]
        public int Damage_Heal { get; set; }
    }

    [MetadataType(typeof(WeaponsMetaData))]
    public partial class Weapon
    {

    }
}