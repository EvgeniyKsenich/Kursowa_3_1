//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KR.DbEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class zakaz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public zakaz()
        {
            this.difficulties = new HashSet<difficulties>();
            this.work = new HashSet<work>();
        }
    
        public int id { get; set; }
        public int designer_id { get; set; }
        public int land_id { get; set; }
        public int price { get; set; }
        public System.DateTime start_time { get; set; }
        public System.DateTime end_time { get; set; }
    
        public virtual designer designer { get; set; }
        public virtual land land { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<difficulties> difficulties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<work> work { get; set; }
    }
}
