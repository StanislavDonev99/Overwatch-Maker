//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Overwatch_Maker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hero
    {
        public int HeroID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int WeaponID { get; set; }
        public int AbilityID { get; set; }
        public int Health { get; set; }
        public string Image { get; set; }
    
        public virtual Ability Ability { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
