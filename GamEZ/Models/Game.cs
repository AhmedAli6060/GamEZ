//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamEZ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int NumberOfDownload { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public int categoryid { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
