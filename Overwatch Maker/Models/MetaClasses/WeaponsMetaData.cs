using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Overwatch_Maker.Models
{
    public class WeaponsMetaData
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Range(0, 100)]
        public Nullable<byte> Ammo { get; set; }

        [Range(0, 10, ErrorMessage = "{0} must be between {1} and {2}.")]
        [Display(Name="Reload Time")]
        public Nullable<double> ReloadTime { get; set; }

        [Range(0, 500, ErrorMessage = "{0} must be between {1} and {2}.")]
        [Display(Name = "Damage/Heal")]
        public int Damage_Heal { get; set; }
    }

    [MetadataType(typeof(WeaponsMetaData))]
    public partial class Weapon
    {

    }
}