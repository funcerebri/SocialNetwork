//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicWave.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FriendRelationship
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid FriendId { get; set; }
        public bool status { get; set; }
    }
}
