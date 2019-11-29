using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Overwatch_Maker.Models
{
    public class AbilityMetaData
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public Nullable<double> Duration { get; set; }

        [Required]
        public int Strenght { get; set; }
    }

    [MetadataType(typeof(AbilityMetaData))]
    public partial class Ability
    {

    }
}