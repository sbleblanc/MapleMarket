//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MapleMarket
{
    using System;
    using System.Collections.Generic;
    
    public partial class Price
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Price()
        {
            this.price_event = new HashSet<PriceEvent>();
        }
    
        public int id { get; set; }
        public int item_stats_id { get; set; }
        public long price1 { get; set; }
        public bool sold { get; set; }
        public string source { get; set; }
        public System.DateTime timestamp { get; set; }
    
        public virtual ItemStats item_stats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceEvent> price_event { get; set; }
    }
}
